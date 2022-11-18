using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighFantasyStore.Shared.Models.profile
{
    internal class ProfileCreate
    {
        [Required]
        public int id { get; set; }
        required
        public int Ownerid
        { get; set; }
        public int gold { get; set; }
        public List<Weapons> WeaponsOwned { get; set; }
        public List<Armor> ArmorOwned { get; set; }
    }
}
