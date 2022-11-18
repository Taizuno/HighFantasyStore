using Humanizer;
using System.ComponentModel.DataAnnotations;
using static System.Net.Mime.MediaTypeNames;


namespace HighFantasyStore.Server.Models
{
    public class WeaponsEntity
    {
        [Key]
        public int Id { get; set; }

        public int Price { get; set; }

        public enum Rarity { }

        public string Name { get; set; }

        public string Properties { get; set; }
        
        public int Magic { get; set; }

        public int quantity { get; set; }

    }
}
