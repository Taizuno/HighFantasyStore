using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighFantasyStore.Shared.Models.Magics
{
    public class MagicListItem
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Description { get; set; }
        public DateTimeOffset dateTimeOffset { get; set; }
    }
}
