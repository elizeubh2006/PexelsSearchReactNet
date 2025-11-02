using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PexelApiSearch.Application.PexelsServices.Interfaces;
using PexelApiSearch.Application.SearchHistoryServices.Interfaces;
using PexelApiSearch.Domain.Entities;
using System.Diagnostics;

namespace PexelsApiSearch.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PhotosController : ControllerBase
    {
        private readonly IPexelsSearchService _searchService;
        private readonly ICreateSearchHistoryHandler _createSearchHistoryHandler;
        public PhotosController(IPexelsSearchService pexelsSearchService, ICreateSearchHistoryHandler createHistHandler)
        {
            _searchService = pexelsSearchService;
            _createSearchHistoryHandler = createHistHandler;
        }

        [HttpGet("search")]
        public async Task<IActionResult> SearchAsync([FromQuery] string query, [FromQuery] int per_page = 5, [FromQuery] int page = 1)
        {

            try
            {
                var result = await _searchService.PhotoSearch(query, page, per_page);
                bool resultOk = await _createSearchHistoryHandler.CreateHandleAsync(query);
                if (resultOk)
                {
                    //salvar um log
                }
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
