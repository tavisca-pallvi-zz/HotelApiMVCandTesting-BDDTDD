using HotelApplicationss.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement
{
    public static class HotelApiCaller
    {
        private static RestClient client = new RestClient("http://localhost:56469/api/hotel");//checking for black box test
        public static List<Hotel>AddHotel(Hotel hotel)
        {
            var request = new RestRequest("Hotel", Method.POST);
            string json = JsonConvert.SerializeObject(hotel);
            request.AddParameter("application/json", json, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            var content = response.Content;
            return JsonConvert.DeserializeObject<List<Hotel>>(content);

        }
        /*
        public static List<Hotel> AddHotel(Hotel hotel)
        {
            var request = new RestRequest("Hotel", Method.POST);
            string json = JsonConvert.SerializeObject(hotel);
            request.AddParameter("application/json", json, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            var content = response.Content;
            return JsonConvert.DeserializeObject<List<Hotel>>(content);

        }
        */


    }
}
