using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZadarAPI.Contracts;
using ZadarAPI.Dto.Kvart;
using ZadarAPI.Models;

namespace ZadarAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KvartsController : ControllerBase
    {
        private readonly IKvartRepository _kvartRepository;
        private readonly IMapper _mapper;

        public KvartsController(IKvartRepository kvartRepository, IMapper mapper)
        {
            _kvartRepository = kvartRepository;
            _mapper = mapper;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetKvartDto>>> GetKvarts()
        {
            var kvarts = await _kvartRepository.GetAllAsync();
            var returningKvarts = _mapper.Map<List<GetKvartDto>>(kvarts);
            
            return returningKvarts;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<KvartDto>> GetKvart(int id)
        {
            var kvart = await _kvartRepository.GetAsync(id);
            if (kvart == null)
            {
                return NotFound();
            }
            
            var returningKvart = _mapper.Map<KvartDto>(kvart);
            
            return returningKvart;
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKvart(int id, UpdateKvartDto updateKvartDto)
        {
            if (id != updateKvartDto.Id)
            {
                return BadRequest();
            }

            var kvart = await _kvartRepository.GetAsync(id);
            if (kvart == null)
            {
                return NotFound();
            }

            _mapper.Map(updateKvartDto, kvart);

            try
            {
                await _kvartRepository.UpdateAsync(kvart);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await KvartExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }
        
        [HttpPost]
        public async Task<ActionResult<Kvart>> PostKvart(CreateKvartDto createKvartDto)
        {
            Kvart kvart = _mapper.Map<Kvart>(createKvartDto);
            _kvartRepository.AddAsync(kvart);

            return CreatedAtAction("GetKvart", new { id = kvart.Id }, kvart);
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKvart(int id)
        {
            var kvart = await _kvartRepository.GetAsync(id);
            if (kvart == null)
            {
                return NotFound();
            }

            _kvartRepository.DeleteAsync(id);

            return NoContent();
        }

        private async Task<bool> KvartExists(int id)
        {
            return await _kvartRepository.Exists(id);
        }
    }
}
