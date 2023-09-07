using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using rpg_dotnet.Models;

namespace rpg_dotnet.Services.CharacterService
{
    public interface ICharacterService
    {
        Task<ServiceResponse<List<GetCharacterDTO>>> GetAllCharacters();
        Task<ServiceResponse<GetCharacterDTO>> GetCharacterById(int id);
        Task<ServiceResponse<List<GetCharacterDTO>>> AddCharacter(AddCharacterDTO newCharacter);
        Task<ServiceResponse<GetCharacterDTO>> EditCharacter(EditCharacterDTO editedCharacter);
    }
}