using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PraxedesBackend.Models
{
    public class User
    {
        public User()
        {
            Relatives = new HashSet<Relative>();
        }

        public int Id { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string UserNames { get; set; }
        public string UserLastNames { get; set; }
        public string UserPlatformName { get; set; }
        public string UserPassword { get; set; }
        public string UserGender { get; set; }
        public int UserDocumentNumber { get; set; }

        public virtual ICollection<Relative> Relatives { get; set; }
    }
}
