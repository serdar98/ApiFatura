using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiFatura
{
    public class faturaModel
    {
        public int faturaID { get; set; }
        public int aboneID { get; set; }
        public decimal guncelBorc { get; set; }
        public DateTime sonOdemeTarihi { get; set; }
    }
}