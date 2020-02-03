using System.Web.Http;
using Autofac.Extras.DynamicProxy;
using AutoMapper;

namespace EVE.WebApi.Catalog.Controllers
{
    //[Intercept("log-calls")]
    public class BaseController : ApiController
    {
        protected IMapper Mapper;

        public BaseController(IMapper mapper)
        {
            Mapper = mapper;
        }
    }
}
