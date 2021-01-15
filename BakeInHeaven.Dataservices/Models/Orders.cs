using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Dataservices.Models
{
    public class Orders
    {   [Key]
        public int Id { get; set; }
        [Required]
        public int OrderId { get; set; }
        [Required]
        public int delicacyid { get; set; }
        [Required]
        public  string Customer { get; set; }
        [Required]
        public int quantity { get; set; }
        [Required]
        public float price { get; set; }
    }
}
