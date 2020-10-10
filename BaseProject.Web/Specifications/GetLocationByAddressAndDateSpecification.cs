using Ardalis.Specification;
using BaseProject.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseProject.Web.Specifications
{
    public class GetLocationByAddressAndDateSpecification : Specification<Location>
    {
        public GetLocationByAddressAndDateSpecification(string address, DateTime date)
        {
            Query.Where(x => x.Address == address && x.ProtestDate == date.Date);
        }
    }
}
