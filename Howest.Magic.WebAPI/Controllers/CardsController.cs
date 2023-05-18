﻿using Microsoft.AspNetCore.Mvc;
using Howest.MagicCards.DAL.Repositories;
using Howest.MagicCards.DAL.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Howest.MagicCards.Shared.DTO;
using Microsoft.EntityFrameworkCore;
using Howest.MagicCards.WebAPI.Wrappers;
using Howest.MagicCards.Shared.Filters;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Caching.Distributed;

namespace Howest.MagicCards.WebAPI.Controllers
{
    [ApiVersion("1.1")]
    [ApiVersion("1.5")]
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

        [MapToApiVersion("1.5")]
        [HttpGet]
        [ProducesResponseType(typeof(PagedResponse<IEnumerable<CardDetailReadDTO>>), 200)]
        [ProducesResponseType(typeof(string), 404)]
        [ProducesResponseType(typeof(string), 500)]
        public async Task<ActionResult<PagedResponse<IEnumerable<CardDetailReadDTO>>>> GetCardsSorted([FromQuery] CardFilter filter, [FromQuery] CardSorter sorter)
        {
            try
            {
                return (_cardRepo.GetAllCards() is IQueryable<Card> allCards)
                    ? Ok(await allCards
                            .Where(c => c.Set.Name.Contains(filter.SetName) && c.Artist.FullName.Contains(filter.ArtistName) && c.Rarity.Name.Contains(filter.RarityName))
                            .Where(c => c.Type.Contains(filter.CardType) && c.Name.Contains(filter.CardName) && c.Text.Contains(filter.CardText))
                            .OrderBy(c => sorter.OrderByNameAscending ? c.Name : null)
                            .ThenByDescending(c => sorter.OrderByNameAscending ? null : c.Name)
                            .Skip((filter.PageNumber - 1) * filter.PageSize)
                            .Take(filter.PageSize)
                            .ProjectTo<CardDetailReadDTO>(_mapper.ConfigurationProvider)
                            .ToListAsync())
                    : NotFound(new Response<CardDetailReadDTO>()
                    {
                        Succeeded = false,
                        Errors = new string[] { $"Status code: {StatusCodes.Status404NotFound}" },
                        Message = $"No cards found"
                    });

            }
            catch (Exception error)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new Response<CardDetailReadDTO>()
                    {
                        Succeeded = false,
                        Errors = new string[] { $"Status code: {StatusCodes.Status500InternalServerError}" },
                        Message = $"({error.Message}) "
                    });
            }
        }

        [MapToApiVersion("1.1")]
        [HttpGet]
        [ProducesResponseType(typeof(PagedResponse<IEnumerable<CardDetailReadDTO>>), 200)]
        [ProducesResponseType(typeof(string), 404)]
        [ProducesResponseType(typeof(string), 500)]
        public async Task<ActionResult<PagedResponse<IEnumerable<CardReadDTO>>>> GetCards([FromQuery] PaginationFilter paginationFilter, [FromQuery] CardFilter filter)
        {
            try
            {
                return (_cardRepo.GetAllCards() is IQueryable<Card> allCards)
                    ? Ok(await allCards
                            .Where(c => c.Set.Name.Contains(filter.SetName) && c.Artist.FullName.Contains(filter.ArtistName) && c.Rarity.Name.Contains(filter.RarityName))
                            .Where(c => c.Type.Contains(filter.CardType) && c.Name.Contains(filter.CardName) && c.Text.Contains(filter.CardText))
                            .Skip((paginationFilter.PageNumber - 1) * paginationFilter.PageSize)
                            .Take(paginationFilter.PageSize)
                            .ProjectTo<CardDetailReadDTO>(_mapper.ConfigurationProvider)
                            .ToListAsync())
                    : NotFound(new Response<CardDetailReadDTO>()
                    {
                        Succeeded = false,
                        Errors = new string[] { $"Status code: {StatusCodes.Status404NotFound}" },
                        Message = $"No cards found"
                    });

            }
            catch (Exception error)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new Response<CardDetailReadDTO>()
                    {
                        Succeeded = false,
                        Errors = new string[] { $"Status code: {StatusCodes.Status500InternalServerError}" },
                        Message = $"({error.Message}) "
                    });
            }
        }

        [HttpGet("{id:int}", Name = "GetCardById")]
        [ProducesResponseType(typeof(CardReadDTO), 200)]
        [ProducesResponseType(typeof(string), 404)]
        [ProducesResponseType(typeof(string), 500)]
        public async Task<ActionResult<CardReadDTO>> GetCard(int id)
        {
            try
            {
                return (await _cardRepo.GetCardbyIdAsync(id) is Card foundCard)
                    ? Ok(_mapper.Map<CardReadDTO>(foundCard))
                    : NotFound(new Response<CardReadDTO>()
                    {
                        Succeeded = false,
                        Errors = new string[] { $"Status code: {StatusCodes.Status404NotFound}" },
                        Message = $"Card with id {id} was not found"
                    });
            }
            catch (Exception error)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new Response<CardDetailReadDTO>()
                    {
                        Succeeded = false,
                        Errors = new string[] { $"Status code: {StatusCodes.Status500InternalServerError}" },
                        Message = $"({error.Message}) "
                    });
            }
        }
    }
}
