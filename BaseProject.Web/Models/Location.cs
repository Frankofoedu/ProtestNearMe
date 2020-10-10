using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseProject.Web.Models
{
    public class Location
    {
        public long Id { get; set; }
        public string Address { get; set; }
        public DateTime ProtestDate { get; set; }
        public int PostCount { get; set; }
        public DateTime LastUpdate { get; set; }
        public string TweeterId { get; set; }
    }
}
