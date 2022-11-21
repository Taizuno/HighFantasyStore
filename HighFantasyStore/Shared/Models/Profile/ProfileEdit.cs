using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighFantasyStore.Shared.Models.Profile
{
    public class ProfileEdit
    {
        public int Id { get; set; }
        public int gold { get; set; }
        public List<Weapon> WeaponsOwned { get; set; }
        public List<Armor> ArmorOwned { get; set; }
    }
}
