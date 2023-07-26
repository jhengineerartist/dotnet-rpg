using Microsoft.AspNetCore.Mvc;

namespace dotnet_rpg.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CharacterController : ControllerBase
    {
        private readonly ICharacterService _characterService;

        public CharacterController(ICharacterService characterService)
        {
            this._characterService = characterService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<GetCharacterResponse>>>> Get()
        {
            return Ok(await _characterService.GetAllCharacters());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetCharacterResponse>>> GetSingle(int id)
        {
            return Ok(await _characterService.GetCharacterById(id));
        }
        [HttpPost]
        public async Task<ActionResult<List<ServiceResponse<GetCharacterResponse>>>> AddCharacter(AddCharacterRequest newCharacter)
        {
            return Ok(await _characterService.AddCharacter(newCharacter));
        }
        [HttpPut]
        public async Task<ActionResult<List<ServiceResponse<GetCharacterResponse>>>> UpdateCharacter(UpdateCharacterRequest updatedCharacter)
        {
            var res = await _characterService.UpdateCharacter(updatedCharacter);
            if (res.Data is null)
            {
                return NotFound(res);
            }
            else
            {
                return Ok(res);
            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<GetCharacterResponse>>> DeleteCharacter(int id)
        {
            var res = await _characterService.DeleteCharacter(id);
            if (res.Data is null)
            {
                return NotFound(res);
            }
            else
            {
                return Ok(res);
            }
        }
    }
}