using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HotelApplicationss.Models;
//using JavaScriptSerializer;

namespace HotelApplicationss.Controllers
{

    public class HotelController : ApiController
    {
        static int c = 0;
        static List<Hotel> hotel = new List<Hotel>()
        {
          new Hotel
          {
              Name="Novotel",Hotelid=1,Address="PuneNagar",Rooms=100,Airportcode="PNQ"

          },
         new Hotel
          {
              Name="Hyatt",Hotelid=2,Address="Viman NagarPune",Rooms=100,Airportcode="PNQ"

          },
         new Hotel
          {
              Name="Taj",Hotelid=3,Address="Mumbai",Rooms=100,Airportcode="BOM"},
          };

        public List<Hotel> GetHotels()
        {
            return hotel;
        }
        public  HttpResponseMessage PostHotels(Hotel h)//
        {
            ApiResponse ob =GetValueByid(h.Hotelid);
            c++;
            h.Hotelid = c;
            hotel.Add(h);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, hotel);
            return response;
        }
        [HttpPut]
        public ApiResponse BookAFlight(int id, [FromBody]int rooms)
        {

            Hotel desiredHotel = null;
            desiredHotel = hotel.Find(x => x.Hotelid == id);
            if (desiredHotel != null)
            {
                if (desiredHotel.Rooms >= rooms)
                {
                    desiredHotel.Rooms = desiredHotel.Rooms - rooms;
                    return new ApiResponse()
                    {

                        errorCode = 200,
                        status = Status.Success,
                        hotel = desiredHotel,
                        errorMsg = "Rooms available",

                      };


                }
                else
                {
                  return new ApiResponse()
                  {     errorCode = 404,
                        status = Status.Failure,
                        hotel = desiredHotel,
                        errorMsg = "Rooms not available",

            };

                }
            }

            return new ApiResponse()
            {
                errorCode = 400,
                status = Status.Failure,
                hotel = desiredHotel,
                errorMsg = "Hotel not available",
    };
        }
        
        public ApiResponse GetValueByid(int id)
        {


            Hotel desiredHotel = null;
            desiredHotel = hotel.Find(x => x.Hotelid == id);
            if (desiredHotel != null)
            {
                return new ApiResponse()
                {

                    errorCode = 200,
                    status = Status.Success,
                    hotel = desiredHotel,
                    errorMsg = "Hotel found",

            };
            }
            return new ApiResponse()
            {
                errorCode = 400,
                status = Status.Failure,
                errorMsg = "Hotel not found",

            };

        }
        public HttpResponseMessage DeleteById([FromBody]int id)
        {
            Hotel desiredHotel = null;
            HttpResponseMessage response=null;

            response = Request.CreateResponse(HttpStatusCode.BadRequest, hotel);
          
            try
            {
                desiredHotel = hotel.Find(x => x.Hotelid == id);

                if (desiredHotel != null)
                {
                    hotel.Remove(desiredHotel);
                    response = Request.CreateResponse(HttpStatusCode.OK, hotel);
                    return response;
                }
                else
                {
                    response = Request.CreateResponse(HttpStatusCode.BadRequest, hotel);
                    return response;

                }

                }
                catch (Exception ex)
                {

                    Console.WriteLine(Json(ex.Message));
                }

           return response;
        }
     
    }
}
