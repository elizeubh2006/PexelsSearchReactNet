using AutoMapper;
using PexelApiSearch.Application.PexelsServices.Interfaces;
using PexelApiSearch.Domain.Entities;
using System.Diagnostics;

namespace PexelApiSearch.Application.PexelsServices.Implementations
{
    public class PexelsSearchService : IPexelsSearchService
    {
        private readonly IPexelsExternalService _pexelsService;
        private readonly IMapper _mapper;

        public PexelsSearchService(IPexelsExternalService pexelsService, IMapper mapper)
        {
            _pexelsService = pexelsService;
            _mapper = mapper;

        }

        public async Task<IEnumerable<PexelsSearchResult>> PhotoSearch(string query, int page, int per_page)
        {
            if (string.IsNullOrWhiteSpace(query))
                throw new ArgumentException("O parâmetro 'query' é obrigatório.");

            var stopwatch = Stopwatch.StartNew();

            var response = await _pexelsService.SearchPhotosAsync(query, per_page, page);

            stopwatch.Stop();

            if (response == null || response.Photos == null || !response.Photos.Any())
                throw new MissingFieldException("Nenhum resultado encontrado.");


            var result = _mapper.Map<IEnumerable<PexelsSearchResult>>(response.Photos);

            foreach (var item in result)
                item.ElapsedSeconds = Math.Round(stopwatch.Elapsed.TotalSeconds, 3);

            return result;
        }
    }
}
