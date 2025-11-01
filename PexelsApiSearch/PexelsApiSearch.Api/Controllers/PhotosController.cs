using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PexelApiSearch.Application.PexelsServices.Interfaces;
using PexelApiSearch.Domain.Entities;
using System.Diagnostics;

namespace PexelsApiSearch.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PhotosController : ControllerBase
    {
        private readonly IPexelsSearchService _searchService;
        public PhotosController(IPexelsSearchService pexelsSearchService)
        {
            _searchService = pexelsSearchService;
        }

        [HttpGet("search")]
        public async Task<IActionResult> SearchAsync([FromQuery] string query, [FromQuery] int per_page = 5, [FromQuery] int page = 1)
        {

            try
            {
                var result = await _searchService.PhotoSearch(query, page, per_page);
                return Ok(result);

            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch(MissingFieldException ex)
            {
                return NotFound(ex.Message);
            }
            catch(Exception ex)
            {
                return BadRequest($"Ocorreu um erro interno: {ex.Message} ");
            }

        }
    }
}
