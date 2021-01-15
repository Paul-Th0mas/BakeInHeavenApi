using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Dataservices.Models
{
    public class delicacy_Schedules
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int Delicacy_id { get; set; }
        [Required]
        public string Date { get; set; }

        public List<delicacys> Delicacies { get; set; }


    }
}
