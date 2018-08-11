using FluentAssertions;
using HotelApplicationss.Models;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace HotelManagement
{
    [Binding]
    public class AddHotelSteps
    {
        private Hotel hotel = new Hotel();
        private List<Hotel> hotelsResponse = new List<Hotel>();

        [Given(@"User provided valid Id '(.*)' and '(.*)' for hotel")]
        public void GivenUserProvidedValidIdAndForHotel(int id, string name)
        {
            hotel.Hotelid = id;
            hotel.Name = name;
        }
        
        [Given(@"User has added required details for hotel")]
        public void GivenUserHasAddedRequiredDetailsForHotel()
        {
            SetHotelBasicDetails();

        }
        
        [When(@"User callers AddHotel api")]
        public void WhenUserCallersAddHotelApi()
        {

            hotelsResponse =HotelApiCaller.AddHotel(hotel);
        }
        
        [Then(@"Hotel with id '(.*)' should be present in the response")]
        public void ThenHotelWithIdShouldBePresentInTheResponse(int id)
        {
            hotel = hotelsResponse.Find(ht => ht.Hotelid == id);
            hotel.Should().NotBeNull(string.Format("hOTEL wITH id {0} not found in response", id));
          
 

        }
        private void SetHotelBasicDetails()
        {
            hotel.Rooms = 30;
            hotel.Airportcode = "PNQ";
            hotel.Address = "Pune,Viman Nagar";
        }

    }
}
