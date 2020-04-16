using System;
using System.Collections.Generic;
using System.Text;

namespace DataBaseLayer.Models
{
    public class Loginlog
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public bool? LoginStatus { get; set; }
        public DateTime? LoginDate { get; set; }
        public string StatusInformation { get; set; }
    }
}
