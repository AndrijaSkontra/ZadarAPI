using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZadarAPI.Contracts;
using ZadarAPI.Dto.Street;
using ZadarAPI.Models;

namespace ZadarAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StreetController : ControllerBase
    {
        private readonly IStreetRepository _streetRepository;
        private readonly IMapper _mapper;

        public StreetController(IStreetRepository streetRepository, IMapper mapper)
        {
            _streetRepository = streetRepository;
            _mapper = mapper;
        }

        // GET: api/Street

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetStreetDto>>> GetStreets()
        {
            var streets =  await _streetRepository.GetAllAsync();
            return _mapper.Map<List<GetStreetDto>>(streets);
        }

        // GET: api/Street/5

        [HttpGet("{id}")]
        public async Task<ActionResult<StreetDto>> GetStreet(int id)
        {
            var street = await _streetRepository.GetAsync(id);

            if (street == null)
            {
                return NotFound();
            }

            return _mapper.Map<StreetDto>(street);
        }

        // PUT: api/Street/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStreet(int id, UpdateStreetDto updateStreetDto)
        {
            if (id != updateStreetDto.Id)
            {
                return BadRequest();
            }
            
            var street = await _streetRepository.GetAsync(id);
            if (street == null)
            {
                return NotFound();
            }

            _mapper.Map(updateStreetDto, street);
            
            try
            {
                await _streetRepository.UpdateAsync(street);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await StreetExists(id))
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

        // POST: api/Street
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Street>> PostStreet(CreateStreetDto createStreetDto)
        {
            var street = _mapper.Map<Street>(createStreetDto);
            await _streetRepository.AddAsync(street);

            return CreatedAtAction("GetStreet", new { id = street.Id }, street);
        }

        // DELETE: api/Street/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStreet(int id)
        {
            var street = await _streetRepository.GetAsync(id);
            if (street == null)
            {
                return NotFound();
            }

            await _streetRepository.DeleteAsync(id);

            return NoContent();
        }

        private async Task<bool> StreetExists(int id)
        {
            return await _streetRepository.Exists(id);
        }
    }
}
