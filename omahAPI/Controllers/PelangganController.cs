using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HotelDataAccess;

namespace omahAPI.Controllers
{
    public class PelangganController : ApiController
    {
        public HttpResponseMessage Post([FromBody] pelanggan pel)
        {
            try
            {
                using (hotelEntities he = new hotelEntities())
                {
                    he.pelanggans.Add(pel);
                        he.SaveChanges();
                    var msg = Request.CreateResponse(HttpStatusCode.Created, pel);
                    msg.Headers.Location = new Uri(Request.RequestUri + pel.id.ToString());
                    return msg;

                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }


        }
    }
}
