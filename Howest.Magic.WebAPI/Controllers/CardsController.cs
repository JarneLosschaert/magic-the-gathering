using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Howest.MagicCards.DAL.Repositories;
using Howest.MagicCards.DAL.Models;

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
        public ActionResult<IEnumerable<Card>> GetCards()
        {
            return Ok(_cardRepo.GetAllCards());
        }

        [HttpGet("{id}")]
        public ActionResult<Card> GetCard(int id)
        {
            return Ok(_cardRepo.GetCardbyId(id));
        }

        [HttpGet]
        public ActionResult<IEnumerable<Card>> GetCardsbyFilter([FromQuery] string filter)
        {
            return Ok();
        }
    }
}
