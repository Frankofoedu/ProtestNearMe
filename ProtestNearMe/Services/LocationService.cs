using BaseProject.Shared;
using BaseProject.Web.Interfaces;
using BaseProject.Web.Models;
using BaseProject.Web.Specifications;
using BaseProject.Web.ViewModels;
using ProtestNearMe.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProtestNearMe.Services
{
    public class LocationService : ILocationService
    {
        public readonly IAsyncRepository<Location> _locationRepo;
        public LocationService(IAsyncRepository<Location> locationRepo)
        {
            _locationRepo = locationRepo;
        }

        public async Task<ResultModel<string>> AddUpdateLocation(LocationUpdateVM model)
        {
            var specification = new GetLocationByAddressAndDateSpecification(model.Address, model.ProtestDate);
            var location = await _locationRepo.GetBySpecAsync(specification);

            if (location == null)
            {
                location = new Location()
                {
                    Address = model.Address,
                    ProtestDate = model.ProtestDate.Date,
                    LastUpdate = DateTime.Now,
                    PostCount = 1,
                };

                await _locationRepo.AddAsync(location);
            }
            else
            {
                location.LastUpdate = DateTime.Now;
                location.PostCount += 1;

                await _locationRepo.UpdateAsync(location);
            }

            var result = new ResultModel<string>();
            result.Data = "Saved Succesfully";

            return result;
        }

        public async Task<ResultModel<List<LocationVM>>> GetLocations(string Address)
        {
            var specification = new GetLocationByAddressSpecification(Address);
            var locations = await _locationRepo.ListAsyncSelect(specification);

            var result = new ResultModel<List<LocationVM>>
            {
                Data = locations.ToList()
            };

            return result;
        }

        public async Task<ResultModel<List<LocationVM>>> GetMostRecentLocations()
        {
            var specification = new GetRecentLocationSpecification(30);
            var locations = await _locationRepo.ListAsyncSelect(specification);

            var result = new ResultModel<List<LocationVM>>();
            result.Data = locations.ToList();

            return result;
        }
    }
}
