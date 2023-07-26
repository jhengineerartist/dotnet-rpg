namespace dotnet_rpg
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Character, GetCharacterResponse>();
            CreateMap<AddCharacterRequest, Character>();
            CreateMap<UpdateCharacterRequest, Character>();
        }
    }
}