using AutoMapper;
using AutoMapper.QueryableExtensions;
using Howest.MagicCards.DAL.Models;
using Howest.MagicCards.DAL.Repositories;
using Howest.MagicCards.Shared.DTO;
using Howest.MagicCards.Shared.Filters;
using Howest.MagicCards.WebAPI.Wrappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace Howest.MagicCards.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SetsController : Controller
    {
        private const string _cacheKey = "Allsets";
        private readonly IMemoryCache _cache;
        private readonly ISetRepository _setRepo;
        private readonly IMapper _mapper;

        public SetsController(ISetRepository setRepository, IMapper mapper, IMemoryCache memoryCache)
        {
            _setRepo = setRepository;
            _mapper = mapper;
            _cache = memoryCache;
        }

        [HttpGet]
        [ProducesResponseType(typeof(Response<IEnumerable<SetReadDTO>>), 200)]
        [ProducesResponseType(typeof(string), 500)]
        public async Task<ActionResult<Response<IEnumerable<SetReadDTO>>>> GetSets()
        {
            if (!_cache.TryGetValue(_cacheKey, out IEnumerable<SetReadDTO> cachedResult))
            {
                cachedResult = await _setRepo.GetAllSets()
                                             .ProjectTo<SetReadDTO>(_mapper.ConfigurationProvider)
                                             .ToListAsync();

                MemoryCacheEntryOptions cacheOptions = new MemoryCacheEntryOptions()
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(30)
                };

                _cache.Set(_cacheKey, cachedResult, cacheOptions);
            }

            return Ok(cachedResult);
        }
    }
}
