using Microsoft.AspNetCore.Mvc;
using ProSolution.BL.DTOs.CatagoryDTOs;
using ProSolution.BL.DTOs.ReviewDTOs;
using ProSolution.BL.Services.InternalServices.Abstractions;
using ProSolution.BL.Services.InternalServices.Implementations;
using ProSolution.Core.Entities;

namespace ProSolution.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService _reviewService;
        public ReviewController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }
        [HttpGet]
        public async Task<ICollection<Review>> GetAll()
        {
            return await _reviewService.GetAllAsync();
        }
        [HttpGet("Deleted")]
        public async Task<ICollection<Review>> GetAllDeleted()
        {
            return await _reviewService.GetAllDeletedAsync();
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] ReviewDTO catagoryDto)
        {
            try
            {
                return StatusCode(StatusCodes.Status201Created, await _reviewService.CreateAsync(catagoryDto));

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);

            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, await _reviewService.GetByIdAsync(id));

            }

            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }
        [HttpDelete("{id}Soft")]
        public async Task<IActionResult> SoftDelete(int id)
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, await _reviewService.SoftDeleteAsync(id));

            }

            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }
        [HttpDelete("{id}Hard")]
        public async Task<IActionResult> HardDelete(int id)
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, await _reviewService.HardDeleteAsync(id));
            }

            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ReviewDTO catagoryDto)
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, await _reviewService.UpdateAsync(id, catagoryDto));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }
        [HttpPut("{id}Restore")]
        public async Task<IActionResult> Restore(int id)
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, await _reviewService.RestoreAsync(id));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }
        [HttpGet("{id}/Reviews")]
        public async Task<IActionResult> GetReviewsByBlogId(int id)
        {
            try
            {
                var reviews = await _reviewService.GetReviewsByBlogIdAsync(id);
                return StatusCode(StatusCodes.Status200OK, reviews);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }

    }
}
