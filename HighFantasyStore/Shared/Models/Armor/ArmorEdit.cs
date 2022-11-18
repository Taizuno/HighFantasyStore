using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighFantasyStore.Shared.Models.Armor
{
    internal class ArmorEdit
    {
        public int Id { get; set; }
        public int Price { get; set; }
        public rarity Rarity { get; set; }
        public string Name { get; set; }
        public string properties { get; set; }
        public int MagicID { get; set; }
        public int quantity { get; set; }
    }
}
