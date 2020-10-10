using BaseProject.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseProject.Web.ViewModels
{
    public class LocationVM
    {
        public string Address { get; set; }
        public DateTime ProtestDate { get; set; }
        public int PostCount { get; set; }
        public DateTime LastUpdate { get; set; }

        public static implicit operator LocationVM(Location model)
        {
            return model == null ? null : new LocationVM
            {
                Address = model.Address,
                ProtestDate = model.ProtestDate,
                PostCount = model.PostCount,
                LastUpdate = model.LastUpdate,
            };
        }
    }
}
