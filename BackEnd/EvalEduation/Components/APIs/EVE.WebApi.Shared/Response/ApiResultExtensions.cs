using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EVE.WebApi.Shared.Response
{
    public static class ApiResultExtensions
    {
        public static HttpResponseMessage ErrorResult(this ApiController controller,
                                                      Error error)
        {
            BaseResponse<object> response = new BaseResponse<object>(null);
            response.UpdateMessageError(error);
            return controller.Request.CreateResponse(HttpStatusCode.OK, response);
        }

        public static HttpResponseMessage ErrorResult(this ApiController controller,
                                                      List<Error> errors)
        {
            BaseResponse<string> response = new BaseResponse<string>(string.Empty);
            response.UpdateMessageError(errors);
            return controller.Request.CreateResponse(HttpStatusCode.OK, response);
        }

        public static HttpResponseMessage OkResult<T>(this ApiController controller,
                                                      T result)
        {
            BaseResponse<T> response = new BaseResponse<T>(result);
            return controller.Request.CreateResponse(HttpStatusCode.OK, response);
        }

        public static HttpResponseMessage OkResult(this ApiController controller)
        {
            return controller.Request.CreateResponse<object>(HttpStatusCode.OK, new BaseResponse<object>(null));
        }

        public static HttpResponseMessage OkResult(this ApiController controller,
                                                   object result)
        {
            return controller.Request.CreateResponse(HttpStatusCode.OK, new BaseResponse<object>(result));
        }
    }
}
