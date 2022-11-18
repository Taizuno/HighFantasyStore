using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HighFantasyStore.Server.Models
{
    public class Armor
    {
        [Key]
        public int Id { get; set; }
        public int Price { get; set; }
        public rarity Rarity { get; set; }
        public string Name { get; set; }
        public string properties { get; set; }
        [ForeignKey("Magic")]
        public int MagicID { get; set; }
        public int quantity { get; set; }
    }
}
