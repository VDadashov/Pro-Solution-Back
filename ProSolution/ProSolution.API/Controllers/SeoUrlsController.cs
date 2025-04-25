using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProSolution.BL.Services.InternalServices.Abstractions;
using ProSolution.Business.DTOs.SEOUrlDTOs;
using ProSolution.Business.Services.InternalServices.Abstractions;

namespace ProSolution.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeoUrlsController : ControllerBase
    {
        private readonly ISeoUrlService _seoUrlService;

        public SeoUrlsController(ISeoUrlService seoUrlService)
        {
            _seoUrlService = seoUrlService;
        }

        // GET: api/seourls
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var seoUrls = await _seoUrlService.GetAllAsync();
            return Ok(seoUrls);
        }

        // GET: api/seourls/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            try
            {
                var seoUrl = await _seoUrlService.GetByIdAsync(new GetByIdSEOUrlDTO { Id = id });
                return Ok(seoUrl);
            }
            catch (Exception ex)
            {
                return NotFound(new { Message = ex.Message });
            }
        }

        // POST: api/seourls
        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] CreateSEOUrlDTO dto)
        {
            if (dto == null)
            {
                return BadRequest("SEO URL data is required.");
            }

            try
            {
                var createdSeoUrl = await _seoUrlService.AddAsync(dto);
                return CreatedAtAction(nameof(GetByIdAsync), new { id = createdSeoUrl.Id }, createdSeoUrl);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        // PUT: api/seourls/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] UpdateSEOUrlDTO dto)
        {
            if (id != dto.Id)
            {
                return BadRequest("ID mismatch.");
            }

            try
            {
                var updatedSeoUrl = await _seoUrlService.UpdateAsync(dto);
                return Ok(updatedSeoUrl);
            }
            catch (Exception ex)
            {
                return NotFound(new { Message = ex.Message });
            }
        }

        // DELETE: api/seourls/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            try
            {
                var deletedSeoUrl = await _seoUrlService.DeleteAsync(new DeleteSEOUrlDTO { Id = id });
                return Ok(deletedSeoUrl);
            }
            catch (Exception ex)
            {
                return NotFound(new { Message = ex.Message });
            }
        }
    }
}
