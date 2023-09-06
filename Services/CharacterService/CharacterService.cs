using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using rpg_dotnet.Models;

namespace rpg_dotnet.Services.CharacterService
{
    public class CharacterService : ICharacterService

    {
        private static List<Character> characters = new List<Character>{
            new Character(),
            new Character { Id = 1, Name = "Roy" }
            
        };
        public async Task<ServiceResponse<List<AddCharacterDTO>>> AddCharacter(AddCharacterDTO newCharacter)
        {
            var ServiceResponse = new ServiceResponse<List<AddCharacterDTO>>();
            characters.Add(newCharacter);
            ServiceResponse.Data = characters;
            return ServiceResponse;
        }

        public async Task<ServiceResponse<List<GetCharacterDTO>>> GetAllCharacters()
        {
            var ServiceResponse = new ServiceResponse<List<GetCharacterDTO>>();
            ServiceResponse.Data = characters;
            return ServiceResponse;
        }

        public async Task<ServiceResponse<Character>> GetCharacterById(int id)
        {
            var ServiceResponse = new ServiceResponse<Character>();
            var character= characters.FirstOrDefault(c => c.Id == id);
            ServiceResponse.Data = character;
            return ServiceResponse;
        }
    }
}