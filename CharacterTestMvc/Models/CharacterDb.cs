using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CharacterTestMvc.Models
{
    public class CharacterDb : DbContext
    {
        public DbSet<Character> Characters { get; set; }
        public DbSet<Race> Races { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Trait> Traits { get; set; }
        public DbSet<Alignment> Alignments { get; set; }

    }
}