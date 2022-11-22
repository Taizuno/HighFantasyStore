using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighFantasyStore.Shared.Models.Profiles
{
    public class ProfileListItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ownerId { get; set; }
        public int gold { get; set; }
        
    }
}
