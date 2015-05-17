using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CharacterTestMvc.Models
{
    public class Alignment
    {
        public int AlignmentId { get; set; }
        public string AlignmentName { get; set; }
        public string AlignmentDescription { get; set; }
    }
}