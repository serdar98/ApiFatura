using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiFatura
{
    public class bilgiModel
    {
        public int bilgiID { get; set; }
        public decimal odenen { get; set; }
        public DateTime odenenTarih { get; set; }
        public string bilgiNo { get; set; }
    }
}