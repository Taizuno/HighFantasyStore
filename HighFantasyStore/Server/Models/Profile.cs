using Humanizer;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HighFantasyStore.Server.Models
{
    public class Profile
    {
        [Key]
        public int id { get; set; }
        [ForeignKey("owner")]
        public string ownerId { get; set; }
        public int gold { get; set; }
        [ForeignKey("Weapons")]
        public List<Weapon> WeaponsOwned { get; set; }
        [ForeignKey("Armors")]
        public List<Armor> ArmorOwned { get; set; }

    }
}
