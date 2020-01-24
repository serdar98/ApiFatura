using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace ApiFatura.Controllers
{
    public class FaturaController : ApiController
    {
        faturaDAL fDal = new faturaDAL();

        [HttpGet]
        public DataTable FaturaBilgi(string id)
        {
            return fDal.faturaBilgi(id);
        }

        [HttpGet]
        public bool FaturaOde(string id)
        {
            return fDal.FaturaOde(id);
        }
    }
}