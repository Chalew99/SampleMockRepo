using HMACAuthenticationWebApi.Models;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;

namespace HMACAuthenticationWebApi.Controllers
{
    [RoutePrefix("api/Orders")]
    public class OrdersController : ApiController
    {
        [Route("")]
        [HMACAuthentication]
        public IHttpActionResult Get()
        {
            return Ok(Order.GetOrders());
        }

        [Route("")]
        [HMACAuthentication]
        public IHttpActionResult Post(Order order)
        {
            return Ok(order);
        }
    }
}