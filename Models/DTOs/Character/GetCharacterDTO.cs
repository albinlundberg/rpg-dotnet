using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rpg_dotnet.DTOs.Character
{
    public class GetCharacterDTO
    {
         public int Id  { get; set; }
        public string Name { get; set; } = "Cair Sandre";
        public int HP { get; set; } = 100;
        public int Strength { get; set; } = 20;
        public int Defence { get; set; } = 20;
        public int Intelligence { get; set; } = 30;
        public RpgClass Class { get; set; } =  RpgClass.Knight;
    }
}