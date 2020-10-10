using BaseProject.Shared;
using BaseProject.Web.Models;
using BaseProject.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProtestNearMe.Interfaces
{
    public interface ILocationService
    {
        Task<ResultModel<List<LocationVM>>> GetLocations(string Address);

        Task<ResultModel<List<LocationVM>>> GetMostRecentLocations();

        Task<ResultModel<string>> AddUpdateLocation(LocationUpdateVM model);
    }
}
