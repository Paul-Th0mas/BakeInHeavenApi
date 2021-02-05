using System;
using System.Collections.Generic;
using System.Text;

namespace Dataservices.Dtos
{
    public class DelicacyReadDtos
    {
       
        public int Id { get; set; }
        
        public string Name { get; set; }
 
        public int Quantity { get; set; }
   
        public float Price { get; set; }
   
        public float weight { get; set; }
   
        public float nutri_engy { get; set; }
 
        public bool veg { get; set; }
        public bool spl { get; set; }
    }
}
