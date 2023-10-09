using Demo_02.API.DTOs;
using Demo_02.API.Mappers;
using Demo_02.BLL.CustomExceptions;
using Demo_02.BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Demo_02.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientController : ControllerBase
    {
        private readonly IIngredientService _IngredientService;

        public IngredientController(IIngredientService ingredientService)
        {
            _IngredientService = ingredientService;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof (IEnumerable<IngredientDTO>))]
        public IActionResult GetAll()
        {
            IEnumerable<IngredientDTO> result = _IngredientService.GetAll().Select(i => i.ToDTO());
            return Ok(result);
            //return StatusCode(StatusCodes.Status501NotImplemented);

        }

        [HttpGet("{ingredientId}")]
        [ProducesResponseType(200, Type = typeof (IngredientDTO))]
        [ProducesResponseType(404)]
        public IActionResult GetById([FromRoute] int ingredientId) 
        {
            IngredientDTO? result = _IngredientService.GetById(ingredientId)?.ToDTO();

            if(result is null)
            {
                return NotFound();
            }

            return Ok(result);
            //return StatusCode(StatusCodes.Status501NotImplemented);
        }

        [HttpPost]
        [ProducesResponseType(201, Type = typeof (IngredientDTO))]
        public IActionResult Insert([FromBody]IngredientDataDTO ingredient)
        {
            IngredientDTO result = _IngredientService.Insert(ingredient.ToModel()).ToDTO();
            
            //201 Created
            return CreatedAtAction(nameof(GetById), new { ingredientId = result.Id }, result);
            //return StatusCode(StatusCodes.Status501NotImplemented);

        }

        [HttpDelete("{ingredientId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404, Type = typeof(string))]
        [ProducesResponseType(409, Type = typeof(string))]
        [ProducesResponseType(400, Type = typeof(string))]
        public IActionResult Delete([FromRoute]int ingredientId)
        {
            bool deleted;
            try
            {
                deleted = _IngredientService.Delete(ingredientId);
            }
            catch (NotFoundException nFEx)
            {
                return NotFound("Ingredient not found");
            }
            catch(AlreadyUsedException aUEx)
            {
                return Conflict("Ingredient already used in a recipe");
            }
            catch(Exception ex)
            {
                // Toute autre Exception qui n'est ni NotFoundException, ni AlreadyUsedExeption
                // ! A mettre toujours en dernier catch
                return BadRequest(ex.Message);
            }

            return deleted ? NoContent() : NotFound("Ingredient not found");

            //return StatusCode(StatusCodes.Status501NotImplemented);
        }
    }
}
