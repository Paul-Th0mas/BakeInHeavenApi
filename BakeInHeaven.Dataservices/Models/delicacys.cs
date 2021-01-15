using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Dataservices.Models
{
   public class delicacys
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public float Price { get; set; }
        [Required]
        public float weight { get; set; }
        [Required]
        public float nutri_engy { get; set; }
        [Required]
        public bool veg { get; set; }
        [Required]
        public bool Spl { get; set; }


    }
}
