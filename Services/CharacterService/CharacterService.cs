namespace dotnet_rpg.Services.CharacterService
{
    public class CharacterService : ICharacterService
    {
        private static List<Character> characters = new List<Character>() {
            new Character(),
            new Character { Id = 1, Name = "Sam" }
        };
        private readonly IMapper _mapper;

        public CharacterService(IMapper mapper)
        {
            this._mapper = mapper;

        }

        public async Task<ServiceResponse<List<GetCharacterResponse>>> AddCharacter(AddCharacterRequest newCharacter)
        {
            var res = new ServiceResponse<List<GetCharacterResponse>>();
            var character = _mapper.Map<Character>(newCharacter);
            character.Id = characters.Max(c => c.Id) + 1;
            characters.Add(character);

            res.Data = characters.Select(c => _mapper.Map<GetCharacterResponse>(c)).ToList();
            return res;
        }

        public async Task<ServiceResponse<List<GetCharacterResponse>>> DeleteCharacter(int id)
        {
            var res = new ServiceResponse<List<GetCharacterResponse>>();
            try
            {
                var character = characters.First(c => c.Id == id)
                    ?? throw new Exception($"Character with Id:'{id}' not found.");
                characters.Remove(character);
                res.Data = characters.Select(c => _mapper.Map<GetCharacterResponse>(c)).ToList();
            }
            catch (Exception e)
            {
                res.Success = false;
                res.Message = e.Message;
            }

            return res;
        }

        public async Task<ServiceResponse<List<GetCharacterResponse>>> GetAllCharacters()
        {
            var res = new ServiceResponse<List<GetCharacterResponse>>();
            res.Data = characters.Select(c => _mapper.Map<GetCharacterResponse>(c)).ToList();
            return res;
        }

        public async Task<ServiceResponse<GetCharacterResponse>> GetCharacterById(int id)
        {
            var res = new ServiceResponse<GetCharacterResponse>();
            var character = characters.FirstOrDefault(c => c.Id == id);
            res.Data = _mapper.Map<GetCharacterResponse>(character);
            return res;
        }

        public async Task<ServiceResponse<GetCharacterResponse>> UpdateCharacter(UpdateCharacterRequest updatedCharacter)
        {
            var res = new ServiceResponse<GetCharacterResponse>();
            try
            {
                var character = characters.FirstOrDefault(c => c.Id == updatedCharacter.Id)
                    ?? throw new Exception($"Character with Id:'{updatedCharacter.Id}' not found.");
                _mapper.Map(updatedCharacter, character);
                res.Data = _mapper.Map<GetCharacterResponse>(character);
            }
            catch (Exception e)
            {
                res.Success = false;
                res.Message = e.Message;
            }

            return res;
        }
    }
}