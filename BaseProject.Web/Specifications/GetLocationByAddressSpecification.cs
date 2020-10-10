using Ardalis.Specification;
using BaseProject.Web.Models;
using BaseProject.Web.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseProject.Web.Specifications
{
    public class GetLocationByAddressSpecification : Specification<Location, LocationVM>
    {
        public GetLocationByAddressSpecification(string address)
        {
            Query.Where(x =>EF.Functions.Like(x.Address, $"%{address}%"));
            Query.OrderByDescending(m => m.LastUpdate);
            Query.Select(m => (LocationVM)m);
        }
    }
}
