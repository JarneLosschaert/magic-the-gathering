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
    public class ArtistsController : Controller
    {
        private const string _cacheKey = "AllArtists";
        private readonly IMemoryCache _cache;
        private readonly IArtistRepository _artistRepo;
        private readonly IMapper _mapper;

        public ArtistsController(IArtistRepository artistRepository, IMapper mapper, IMemoryCache memoryCache)
        {
            _artistRepo = artistRepository;
            _mapper = mapper;
            _cache = memoryCache;
        }

        [HttpGet]
        [ProducesResponseType(typeof(Response<IEnumerable<ArtistReadDTO>>), 200)]
        [ProducesResponseType(typeof(string), 500)]
        public async Task<ActionResult<Response<IEnumerable<ArtistReadDTO>>>> GetArtists()
        {
            if (!_cache.TryGetValue(_cacheKey, out IEnumerable<ArtistReadDTO> cachedResult))
            {
                cachedResult = await _artistRepo.GetAllArtists()
                                             .ProjectTo<ArtistReadDTO>(_mapper.ConfigurationProvider)
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
