using CardServiceApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace CardServiceApi.Controllers
{
    [ApiController]
    [Route("api/[Controller]/[action]")]
    public class CardController : Controller
    {
        private readonly ICard cards;
        public CardController(ICard card)
        {
            cards = card;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCard()
        {
            return Ok(await cards.GetCards());
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public  IActionResult GetById([FromRoute] Guid id)
        {
            var result = cards.GetCardById(id);
            if(result == null) return NotFound();

            return Ok(result);
        }

        [HttpPost]
        public ActionResult<Card> Create([FromBody] Card card)
        {
            card.Id = Guid.NewGuid();
            cards.AddCard(card);
            return Ok(card);
        }

        [HttpPut]
        public async Task<ActionResult<Card>> Update([FromBody] Card card)
        {
            var result = await cards.UpdateCard(card);

            if (result == null) return NotFound();

            return Ok(result);
        }

        [HttpDelete]
        [Route("{id:Guid}")]

        public async Task<ActionResult<Card>> Delete([FromRoute] Guid id)
        {
            var result = cards.DeleteCard(id);

            if(result == null) return NotFound();

            return Ok(result);
        }

    }
}
