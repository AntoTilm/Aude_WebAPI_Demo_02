using Demo_02.API.DTOs;
using Demo_02.API.Mappers;
using Demo_02.BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Demo_02.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        private readonly IRecipeService _RecipeService;
        public RecipeController(IRecipeService recipeService)
        {
            _RecipeService = recipeService;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<RecipeDTO>))]
        public IActionResult GetAll()
        {
            IEnumerable<RecipeDTO> result = _RecipeService.GetAll().Select(r => r.ToDTO());
            return Ok(result);
        }

        [HttpGet("{recipeId}")]
        [ProducesResponseType(404)]
        [ProducesResponseType(200, Type = typeof(RecipeFullDTO))]
        public IActionResult GetById([FromRoute] int recipeId)
        {
            RecipeFullDTO? result = _RecipeService.GetById(recipeId)?.ToFullDTO();

            if(result is null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}
