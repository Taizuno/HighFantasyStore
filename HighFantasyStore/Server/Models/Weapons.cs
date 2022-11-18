using Humanizer;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Net.Mime.MediaTypeNames;


namespace HighFantasyStore.Server.Models
{
    public class Weapons
    {
        [Key]
        public int Id { get; set; }

        public int Price { get; set; }

        public enum Rarity { }

        public string Name { get; set; }

        public string Properties { get; set; }
        [ForeignKey("magic")]
        public int Magicid { get; set; }

        public int quantity { get; set; }

    }
}
