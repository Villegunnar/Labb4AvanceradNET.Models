using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Labb4AvanceradNET.Models
{
    public class Webbsite
    {
        [Key]
        public int Id { get; set; }
        public string WebbsiteName { get; set; }
        public string WebbsiteAdress { get; set; }
        public int FInterestId { get; set; }

        public  Interest interest { get; set; }

    }
}
