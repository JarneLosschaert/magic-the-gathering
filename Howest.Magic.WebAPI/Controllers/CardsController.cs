using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Howest.MagicCards.DAL.Repositories;

namespace Howest.MagicCards.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardsController : ControllerBase
    {
        private readonly CardRepository _cardRepo;

        public CardsController()
        {
            _cardRepo = new CardRepository();
        }

        [HttpGet]
        public IActionResult GetCards()
        {
            return Ok(_cardRepo.GetAllCards());
        }

        [HttpGet("{id}")]
        public IActionResult GetCard(int id)
        {
            return Ok(_cardRepo.GetCardbyId(id));
        }
    }
}
