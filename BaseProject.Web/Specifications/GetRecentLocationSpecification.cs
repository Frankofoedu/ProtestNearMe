using Ardalis.Specification;
using BaseProject.Web.Models;
using BaseProject.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseProject.Web.Specifications
{
    public class GetRecentLocationSpecification: Specification<Location, LocationVM>
    {
        public GetRecentLocationSpecification(int takeCount)
        {
            Query.OrderByDescending(m=>m.LastUpdate);
            Query.Take(takeCount);
            Query.Select(m => (LocationVM)m);
        }
    }
}
