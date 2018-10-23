using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MikrotikAPIServer.Models
{
    public class Store
    {
        public string StoreID { get; set; }
        public string BrandID { get; set; }
        public string SecretKey { get; set; }
        public string Token { get; set; }
        public string DevicePassword { get; set; }
        public Store(string StoreID, string BrandID, string SecretKey, string Token, string DevicePassword)
        {
            this.StoreID = StoreID;
            this.BrandID = BrandID;
            this.SecretKey = SecretKey;
            this.Token = Token;
            this.DevicePassword = DevicePassword;

        }
    }
}