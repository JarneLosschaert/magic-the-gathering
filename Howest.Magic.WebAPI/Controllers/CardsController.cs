using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Howest.MagicCards.DAL.Repositories;
using Howest.MagicCards.DAL.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Howest.MagicCards.Shared.DTO;
using Microsoft.EntityFrameworkCore;

namespace Howest.MagicCards.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardsController : ControllerBase
    {
        private readonly ICardRepository _cardRepo;
        private readonly IMapper _mapper;
   

        public CardsController(ICardRepository cardRepository, IMapper mapper)
        {
            _cardRepo = cardRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CardDetailReadDTO>>> GetCards()
        {
            return (_cardRepo.GetAllCards() is IQueryable<Card> allCards)
                    ? Ok(await allCards
                            .ProjectTo<CardDetailReadDTO>(_mapper.ConfigurationProvider)
                            .ToListAsync())
                    : NotFound("No cards found");
        }

        [HttpGet("{id:int}", Name = "GetCardById")]
        public async Task<ActionResult<CardReadDTO>> GetCard(int id)
        {
            return (await _cardRepo.GetCardbyIdAsync(id) is Card foundCard)
                    ? Ok(_mapper.Map<CardReadDTO>(foundCard))
                    : NotFound($"No card found with id {id}");
        }
    }
}
