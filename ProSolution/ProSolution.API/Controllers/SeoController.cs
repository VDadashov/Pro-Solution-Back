using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProSolution.BL.Services.InternalServices.Abstractions;
using ProSolution.Business.DTOs.SEODTOs;
using ProSolution.Business.Services.InternalServices.Abstractions;

namespace ProSolution.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeoController : ControllerBase
    {
        private readonly ISeoService _seoService;

        public SeoController(ISeoService seoService)
        {
            _seoService = seoService;
        }

        // GET: api/seo
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var seoEntries = await _seoService.GetAllAsync();
            return Ok(seoEntries);
        }

        // GET: api/seo/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            try
            {
                var seoEntry = await _seoService.GetByIdAsync(new GetByIdSEODTO { Id = id });
                return Ok(seoEntry);
            }
            catch (Exception ex)
            {
                return NotFound(new { Message = ex.Message });
            }
        }

        // POST: api/seo
        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] CreateSEODTO dto)
        {
            if (dto == null)
            {
                return BadRequest("SEO data is required.");
            }

            var seoEntry = await _seoService.AddAsync(dto);
            return CreatedAtAction(nameof(GetByIdAsync), new { id = seoEntry.Id }, seoEntry);
        }

        // PUT: api/seo/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] UpdateSEODTO dto)
        {
            if (id != dto.Id)
            {
                return BadRequest("ID mismatch.");
            }

            try
            {
                var updatedSeoEntry = await _seoService.UpdateAsync(dto);
                return Ok(updatedSeoEntry);
            }
            catch (Exception ex)
            {
                return NotFound(new { Message = ex.Message });
            }
        }

        // DELETE: api/seo/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            try
            {
                var deletedSeoEntry = await _seoService.DeleteAsync(new DeleteSEODTO { Id = id });
                return Ok(deletedSeoEntry);
            }
            catch (Exception ex)
            {
                return NotFound(new { Message = ex.Message });
            }
        }
    }
}
