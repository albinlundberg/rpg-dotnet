global using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
        private readonly IMapper _mapper;

        public CharacterService(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<ServiceResponse<List<GetCharacterDTO>>> AddCharacter(AddCharacterDTO newCharacter)
        {
            var ServiceResponse = new ServiceResponse<List<GetCharacterDTO>>();
            var character = _mapper.Map<Character>(newCharacter);
            character.Id = characters.Max(c => c.Id) + 1;
            characters.Add(character);
            ServiceResponse.Data = characters.Select(c => _mapper.Map<GetCharacterDTO>(c)).ToList();
            return ServiceResponse;
        }

        public async Task<ServiceResponse<List<GetCharacterDTO>>> GetAllCharacters()
        {
            var ServiceResponse = new ServiceResponse<List<GetCharacterDTO>>();
            ServiceResponse.Data = characters.Select(c => _mapper.Map<GetCharacterDTO>(c)).ToList();
            return ServiceResponse;
        }

        public async Task<ServiceResponse<GetCharacterDTO>> GetCharacterById(int id)
        {
            var serviceResponse = new ServiceResponse<GetCharacterDTO>();
            var character= characters.FirstOrDefault(c => c.Id == id);
            serviceResponse.Data = _mapper.Map<GetCharacterDTO>(character);
            return serviceResponse;
            
        }

        public async Task<ServiceResponse<GetCharacterDTO>> EditCharacter(EditCharacterDTO editedCharacter)
        {
            var serviceResponse = new ServiceResponse<GetCharacterDTO>();
            try
            {
                var character= characters.FirstOrDefault(c => c.Id == editedCharacter.Id);
                if(character is null)
                    throw new Exception($"Character with Id '{editedCharacter.Id}' not found");

                

                character.Name = editedCharacter.Name;
                character.HP = editedCharacter.HP;
                character.Strength = editedCharacter.Strength;
                character.Defence = editedCharacter.Defence;
                character.Intelligence = editedCharacter.Intelligence;
                character.Class = editedCharacter.Class;

                serviceResponse.Data = _mapper.Map<GetCharacterDTO>(character);
            } 
            catch (Exception ex) 
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
                
            }
            return serviceResponse;
            
        }

        public async Task<ServiceResponse<List<GetCharacterDTO>>> DeleteCharacter(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetCharacterDTO>>();
            try
            {
                //var character= characters.First(c => c.Id == id);
                var character= characters.FirstOrDefault(c => c.Id == id);
                if(character is null)
                    throw new Exception($"Character with Id '{id}' not found");

                

                characters.Remove(character);

                serviceResponse.Data = characters.Select(c => _mapper.Map<GetCharacterDTO>(c)).ToList();
            } 
            catch (Exception ex) 
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
                
            }
            return serviceResponse;
        }
    }
}