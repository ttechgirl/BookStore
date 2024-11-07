﻿using Microsoft.AspNetCore.Mvc;
using Shared.Enums;
using BookStore.ViewModel;

namespace BookStore.Controllers
{
    public class BaseController :ControllerBase
    {
        /// <returns></returns>
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult EmptyPayloadResponse()
        {
            return this.ApiResponse("", "Payload cannot be empty", ApiResponseCodes.INVALID_REQUEST);
        }

        /// <summary>
        /// </summary>
        /// <param name="data"></param>
        /// <param name="messages"></param>
        /// <param name="codes"></param>
        /// <param name="dataCount"></param>
        /// <param name="totalCount"></param>
        /// <param name="totalPage"></param>
        /// <returns></returns>
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult ApiResponse(dynamic? data = default(object), string[] messages = null ,
            ApiResponseCodes codes = ApiResponseCodes.OK, int? dataCount = 0, int? totalCount = 0, int? totalPage = 0)
        {
            if (codes == ApiResponseCodes.OK)
            {
                ApiResponse<dynamic> response = new ApiResponse<dynamic>
                {
                    Payload = data,
                    Code = codes,
                    Description = messages.FirstOrDefault()
                };

                response.DataCount = dataCount ?? 0;
                response.TotalCount = totalCount ?? 0;
                response.TotalPages = totalPage ?? 0;
                return ReturnHttpMessage(codes, response);
            }
            else
            {
                ApiResponse<dynamic> response = new ApiResponse<dynamic>
                {
                    Payload = data,
                    Code = codes,
                    Errors = messages.ToList(),
                    Description = messages.FirstOrDefault()
                };

                response.DataCount = dataCount ?? 0;
                response.TotalCount = totalCount ?? 0;
                response.TotalPages = totalPage ?? 0;
                return ReturnHttpMessage(codes, response);
            }
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult ApiResponse(dynamic? data = default(object), string message = "", ApiResponseCodes codes = ApiResponseCodes.OK,
           int? dataCount = 0, int? totalCount = 0, int? totalPage = 0)
        {
            return ApiResponse(data, new string[] { message }, codes, dataCount, totalCount, totalPage);
        }

        private IActionResult ReturnHttpMessage<T>(ApiResponseCodes codes, ApiResponse<T> response) where T : class
        {
            switch (codes)
            {
                case ApiResponseCodes.EXCEPTION:
                    return this.StatusCode(StatusCodes.Status500InternalServerError, response);
                case ApiResponseCodes.UNAUTHORIZED:
                    return this.StatusCode(StatusCodes.Status401Unauthorized, response);
                case ApiResponseCodes.NOT_FOUND:
                case ApiResponseCodes.INVALID_REQUEST:
                case ApiResponseCodes.ERROR:
                    return this.StatusCode(StatusCodes.Status400BadRequest, response);
                case ApiResponseCodes.OK:
                default:
                    return Ok(response);
            }
        }

        protected ApiResponse<IEnumerable<string>> GetModelStateValidationErrorsAsList()
        {
            var response = new ApiResponse<IEnumerable<string>>
            {
                Code = ApiResponseCodes.ERROR
            };
            var message = ModelState.Values.SelectMany(a => a.Errors).Select(e => e.ErrorMessage);
            var list = new List<string>();
            list.AddRange(message);
            response.Payload = list;
            return response;
        }

        protected string GetModelStateValidationErrors()
        {
            string message = string.Join("; ", ModelState.Values
                                    .SelectMany(a => a.Errors)
                                    .Select(e => e.ErrorMessage));
            return message;
        }

        protected string GetModelStateValidationError()
        {
            string message = ModelState.Values.FirstOrDefault().Errors.FirstOrDefault().ErrorMessage;
            return message;
        }
    }
}
