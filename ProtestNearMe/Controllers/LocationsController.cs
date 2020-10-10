using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaseProject.Shared;
using BaseProject.Web;
using BaseProject.Web.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProtestNearMe.Interfaces;

namespace ProtestNearMe.Controllers
{
    public class LocationsController : BaseController
    {
        private readonly ILocationService _locationService;
        public LocationsController(ILocationService locationService)
        {
            _locationService = locationService;
        }


        [HttpPost("PostLocation")]
        [ProducesResponseType(typeof(ApiResponse<string>), 200)]
        public async Task<IActionResult> PostLocation(LocationUpdateVM model)
        {
            if (!ModelState.IsValid)
            {
                return ApiResponse(ListModelErrors, codes: ApiResponseCodes.INVALID_REQUEST);
            }
            try
            {
                var data = await _locationService.AddUpdateLocation(model);

                if (data.HasError)
                {
                    return ApiResponse<object>(errors: data.ErrorMessages.ToArray());
                }
                return ApiResponse<object>(message: "Successful", codes: ApiResponseCodes.OK, data: data.Data);
            }
            catch (Exception ex)
            {
                return HandleError(ex);
            }
        }

        [HttpGet("GetRecent")]
        [ProducesResponseType(typeof(ApiResponse<object>), 200)]
        public async Task<IActionResult> GetRecent()
        {
            if (!ModelState.IsValid)
            {
                return ApiResponse(ListModelErrors, codes: ApiResponseCodes.INVALID_REQUEST);
            }
            try
            {
                var data = await _locationService.GetMostRecentLocations();

                if (data.HasError)
                {
                    return ApiResponse<object>(errors: data.ErrorMessages.ToArray());
                }
                return ApiResponse<object>(message: "Successful", codes: ApiResponseCodes.OK, data: data.Data);
            }
            catch (Exception ex)
            {
                return HandleError(ex);
            }
        }

        [HttpGet("Search")]
        [ProducesResponseType(typeof(ApiResponse<object>), 200)]
        public async Task<IActionResult> SearchLocation([FromQuery]string address)
        {
            if (!ModelState.IsValid)
            {
                return ApiResponse(ListModelErrors, codes: ApiResponseCodes.INVALID_REQUEST);
            }
            try
            {
                var data = await _locationService.GetLocations(address);

                if (data.HasError)
                {
                    return ApiResponse<object>(errors: data.ErrorMessages.ToArray());
                }
                return ApiResponse<object>(message: "Successful", codes: ApiResponseCodes.OK, data: data.Data);
            }
            catch (Exception ex)
            {
                return HandleError(ex);
            }
        }

    }
}
