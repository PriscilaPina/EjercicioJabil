using JabilEjercicio.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace JabilEjercicio.Controllers
{
    public class DetailsController : Controller
    {
        private MaterialsContext context;

        public DetailsController(MaterialsContext context )
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            return View(GetDetailList());
        }

        public List<Detail> GetDetailList() {
            List<Detail> list = new List<Detail>();
            var partNumberActive = context.PartNumbers.Include(x=>x.FkcustomerNavigation).ThenInclude(x=>x.FkbuildingNavigation).Where(x=>x.Available).ToList();
            foreach (var part in partNumberActive) {
                list.Add(new Detail
                {
                    Building = part.FkcustomerNavigation.FkbuildingNavigation.Building1,
                    Customer = part.FkcustomerNavigation.Customer1,
                    PartNumber = part.PartNumber1
                });
            }
            return list;
        }
    }
}
