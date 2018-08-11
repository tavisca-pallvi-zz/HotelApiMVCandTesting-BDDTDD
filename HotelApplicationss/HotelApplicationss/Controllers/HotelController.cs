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
        static int c = 3;
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

        public ApiResponse GetHotels()
        {

        }
        public ApiResponse PostHotels(Hotel h)//
        {

            c++;
            Hotel existHotel = hotel.Find(p => p.Hotelid == c);
            if (existHotel != null)
            {
                h.Hotelid = c;
                hotel.Add(h);

                return new ApiResponse
                {

                    errorCode = 404,
                    status = Status.Failure,

                    errorMsg = "Hotel Exists",
                };
               
            }


            return new ApiResponse
            {

                errorCode = 200,
                status = Status.Success,
                hotel = h,
                errorMsg = "Hotel Added Succesfully",

            };
        }


       
        [HttpPut]
        public ApiResponse BookAFlight(int id, [FromBody]int rooms)
        {

            Hotel desiredHotel = null;
            desiredHotel = hotel.Find(x => x.Hotelid == id);
            
            if (desiredHotel != null)
            {
                if (rooms <= 0)
                {

                    return new ApiResponse()
                    {

                        errorCode = 200,
                        status = Status.Success,
                        hotel = desiredHotel,
                        errorMsg = "Bad Request",
                   
                    };


                }
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
