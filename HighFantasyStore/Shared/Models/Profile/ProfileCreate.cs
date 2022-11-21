using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighFantasyStore.Shared.Models.profiles
{
    public class ProfileCreate
    {
        [Required]
        public int id { get; set; }
        [Required]
        public int Ownerid { get; set; }
        public int gold { get; set; }
    }
}
