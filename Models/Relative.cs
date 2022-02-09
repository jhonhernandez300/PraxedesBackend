using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PraxedesBackend.Models
{
    public class Relative
    {
        public int Id { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string RelativeNames { get; set; }
        public string RelativeLastNames { get; set; }        
        public string RelativeGender { get; set; }
        public int RelativeDocumentNumber { get; set; }
        public string InLaw { get; set; }
        public int RelativeAge { get; set; }


        public int? UserId { get; set; }
        public virtual User User { get; set; }
    }
}
