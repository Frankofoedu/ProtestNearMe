using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseProject.Web.ViewModels
{
    public class LocationUpdateVM
    {
        [Required]
        public string Address { get; set; }
        public DateTime ProtestDate { get; set; }
    }
}
