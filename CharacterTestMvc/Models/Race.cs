using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CharacterTestMvc.Models
{
    public class Race
    {
        public int RaceId { get; set; }
        public string RaceName { get; set; }
        public string RaceDescription { get; set; }
        public int RaceSpeed { get; set; }
        public char RaceSize { get; set; }
        public ICollection<Trait> RaceTraits { get; set; }
        public ICollection<Language> RaceLanguages { get; set; }
    }
}