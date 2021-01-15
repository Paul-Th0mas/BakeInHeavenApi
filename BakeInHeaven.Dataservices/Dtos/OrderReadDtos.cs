using System;
using System.Collections.Generic;
using System.Text;

namespace Dataservices.Dtos
{
    public class OrderReadDtos
    {
        
        public int OrderId { get; set; }
        
        public int Delicacyid { get; set; }
        public string DelicacyName { get; set; }
        
        public string Customer { get; set; }
        
        public int quantity { get; set; }
        
        public float price { get; set; }
    }
}
