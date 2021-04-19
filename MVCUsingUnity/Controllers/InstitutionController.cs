using ServicesCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCUsingUnity.Controllers
{
    public class InstitutionController : Controller
    {
        
            private IInstitutionService institutionService;
            public InstitutionController(IInstitutionService institutionService)
            {
                this.institutionService = institutionService;
            }
        
            // GET: Institution    
            public ActionResult Index()
            {
                return View(this.institutionService.GetInstitutionByID(1));
            }
     
    }
}