using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Dataservices.Dtos
{
    public class OrderCreateDtos
    {
        [Required]
        public int OrderId { get; set; }
        [Required]
        public int delicacyid { get; set; }
        [Required]
        public string Customer { get; set; }
        [Required]
        public int quantity { get; set; }
        [Required]
        public float price { get; set; }
    }
}
