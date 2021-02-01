using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Dataservices.Models
{
     public class Sessions
    {   [Key]
       public int id { get; set; }
        [Required]
        public String dateTime { get; set; }
        [Required]
        public String token { get; set; }
        [ForeignKey("Admins")]
        public int AdminRefId { get; set; }
        public  Admins Admin { get; set; }

    }
}
