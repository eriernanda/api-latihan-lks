using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HotelDataAccess;

namespace omahAPI.Controllers
{
    public class KamarController : ApiController
    {
        public HttpResponseMessage get(string tipe_kamar = "All")
        {
            using (hotelEntities ent = new hotelEntities())
            {
                switch (tipe_kamar.ToLower())
                {
                    case "all":
                        return Request.CreateResponse(HttpStatusCode.OK, ent.kamars.ToList());
                    case "c":
                        return Request.CreateResponse(HttpStatusCode.OK,
                            ent.kamars.Where(e => e.tipe_kamar.ToLower() == "c").ToList());
                    case "b":
                        return Request.CreateResponse(HttpStatusCode.OK,
                            ent.kamars.Where(e => e.tipe_kamar.ToLower() == "b").ToList());
                    default:
                        return Request.CreateResponse(HttpStatusCode.BadRequest,
                            "Tipe Kamar Tidak Diketahui");
                }
            }
        }
        public HttpResponseMessage Post([FromBody] pemesanan pem)
        {
            try
            {
                using (hotelEntities he = new hotelEntities())
                {
                    he.pemesanans.Add(pem);
                    he.SaveChanges();
                    var msg = Request.CreateResponse(HttpStatusCode.Created, pem);
                    msg.Headers.Location = new Uri(Request.RequestUri + pem.no_reservasi.ToString());
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
