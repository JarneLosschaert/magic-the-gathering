using AutoMapper;
using AutoMapper.QueryableExtensions;
using Howest.MagicCards.DAL.Repositories;
using Howest.MagicCards.Shared.DTO;
using Howest.MagicCards.WebAPI.Wrappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace Howest.MagicCards.WebAPI.Controllers
{
    [ApiVersion("1.1")]
    [ApiVersion("1.5")]
    [Route("api/[controller]")]
    [ApiController]
    public class RaritiesController : Controller
    {
        private const string _cacheKey = "AllRarities";
        private readonly IMemoryCache _cache;
        private readonly IRarityRepository _rarityRepo;
        private readonly IMapper _mapper;

        public RaritiesController(IRarityRepository rarityRepository, IMapper mapper, IMemoryCache memoryCache)
        {
            _rarityRepo = rarityRepository;
            _mapper = mapper;
            _cache = memoryCache;
        }

        [HttpGet]
        [ProducesResponseType(typeof(Response<IEnumerable<RarityReadDTO>>), 200)]
        [ProducesResponseType(typeof(string), 500)]
        public async Task<ActionResult<Response<IEnumerable<RarityReadDTO>>>> GetRarities()
        {
            if (!_cache.TryGetValue(_cacheKey, out IEnumerable<RarityReadDTO> cachedResult))
            {
                cachedResult = await _rarityRepo.GetAllRarities()
                                             .ProjectTo<RarityReadDTO>(_mapper.ConfigurationProvider)
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
