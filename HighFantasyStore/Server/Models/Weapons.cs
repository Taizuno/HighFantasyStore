using Humanizer;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Net.Mime.MediaTypeNames;


namespace HighFantasyStore.Server.Models
{
    public class Weapon
    {
        [Key]
        public int Id { get; set; }

        public int Price { get; set; }

        public rarity Rarity { get; set; }

        public string Name { get; set; }

        public string properties { get; set; }
        [ForeignKey("magic")]
        public int MagicId { get; set; }

        public int quantity { get; set; }

    }
}
