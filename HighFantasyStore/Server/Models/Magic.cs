using System.ComponentModel.DataAnnotations;
using static System.Net.Mime.MediaTypeNames;

namespace HighFantasyStore.Server.Models
{
    public class Magic
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }
    }
    }
