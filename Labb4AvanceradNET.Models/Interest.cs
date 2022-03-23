using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Labb4AvanceradNET.Models
{
    public class Interest
    {
        [Key]
        public int Id { get; set; }
        public string InterestName { get; set; }
        public string Description { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }





    }
}
