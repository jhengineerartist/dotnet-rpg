namespace dotnet_rpg.Services.CharacterService
{
    public interface ICharacterService
    {
        Task<ServiceResponse<List<GetCharacterResponse>>> GetAllCharacters();
        Task<ServiceResponse<GetCharacterResponse>> GetCharacterById(int id);
        Task<ServiceResponse<List<GetCharacterResponse>>> AddCharacter(AddCharacterRequest newCharacter);
        Task<ServiceResponse<GetCharacterResponse>> UpdateCharacter(UpdateCharacterRequest updatedCharacter);
        Task<ServiceResponse<List<GetCharacterResponse>>> DeleteCharacter(int id);
    }
}