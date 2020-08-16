using BusinessLayer.DTOs.Decks;
using BusinessLayer.Facades;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace REST.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DeckController : ControllerBase
    {
        private readonly DeckFacade deckFacade;

        public DeckController(DeckFacade deckFacade)
        {
            this.deckFacade = deckFacade;
        }

        [HttpGet]
        public async Task<IList<DeckListDto>> GetAll()
        {
            return await deckFacade.GetAllAsync();
        }

        [HttpGet("User/{userId:guid}")]
        public async Task<IList<DeckListDto>> GetByUser(Guid userId)
        {
            return await deckFacade.GetByUserAsync(userId);
        }
    }
}