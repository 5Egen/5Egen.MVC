using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CharacterTestMvc.Models
{
    public class Character
    {
        public int CharacterId { get; set; }
        public string CharacterName { get; set; }
        public Race CharacterRace { get; set; }
        public Class CharacterClass { get; set; }
        public Alignment CharacterAlign { get; set; }
    }
}