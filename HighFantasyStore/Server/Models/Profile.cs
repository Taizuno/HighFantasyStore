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
        public int ownerId { get; set; }
        public int gold { get; set; }
        public List<Weapon> WeaponsOwned { get; set; }
        public List<Armor> ArmorOwned { get; set; }

    }
}
