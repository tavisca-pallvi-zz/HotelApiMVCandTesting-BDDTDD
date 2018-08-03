using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelApplicationss.Models
{
    public enum Status{
        Success,
        Failure,
        Warning,
    }
    
    public class ApiResponse
    {
        public Status status;
        public int errorCode;
        public Hotel hotel;
        public string errorMsg;
        public ApiResponse(){


            }

    }
    
    
}