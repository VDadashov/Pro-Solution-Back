using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProSolution.BL.Services.InternalServices.Abstractions;
using ProSolution.Business.DTOs.SEODTOs;
using ProSolution.Business.Services.InternalServices.Abstractions;

namespace ProSolution.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeoMetasController : ControllerBase
    {
        private readonly ISeoMetaService _seoMetaService;

        public SeoMetasController(ISeoMetaService seoMetaService)
        {
            _seoMetaService = seoMetaService;
        }

        // GET: api/seometas
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var seoMetas = await _seoMetaService.GetAllAsync();
            return Ok(seoMetas);
        }

        // GET: api/seometas/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            try
            {
                var seoMeta = await _seoMetaService.GetByIdAsync(new GetByIdSEOMetaDTO { Id = id });
                return Ok(seoMeta);
            }
            catch (Exception ex)
            {
                return NotFound(new { Message = ex.Message });
            }
        }

        // POST: api/seometas
        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] CreateSEOMetaDTO dto)
        {
            if (dto == null)
            {
                return BadRequest("SEO Meta data is required.");
            }

            try
            {
                var createdSeoMeta = await _seoMetaService.AddAsync(dto);
                return CreatedAtAction(nameof(GetByIdAsync), new { id = createdSeoMeta.Id }, createdSeoMeta);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        // PUT: api/seometas/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] UpdateSEOMetaDTO dto)
        {
            if (id != dto.Id)
            {
                return BadRequest("ID mismatch.");
            }

            try
            {
                var updatedSeoMeta = await _seoMetaService.UpdateAsync(dto);
                return Ok(updatedSeoMeta);
            }
            catch (Exception ex)
            {
                return NotFound(new { Message = ex.Message });
            }
        }

        // DELETE: api/seometas/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            try
            {
                var deletedSeoMeta = await _seoMetaService.DeleteAsync(new DeleteSEOMetaDTO { Id = id });
                return Ok(deletedSeoMeta);
            }
            catch (Exception ex)
            {
                return NotFound(new { Message = ex.Message });
            }
        }
    }
}
