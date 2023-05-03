using AgriculturePresentation.Models;
using Microsoft.AspNetCore.Mvc;

namespace AgriculturePresentation.Controllers
{
    public class ChartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ProductChart() 
        {
            List<ProductClass> productClasses= new List<ProductClass>();

            // Her bir veriyi tablodan çekmek yerine tek tek kendi elimle gieiyorum.

            productClasses.Add(new ProductClass()
            {
                productname = "Buğday",
                productvalue=850
                
 
            });

            productClasses.Add(new ProductClass()
            {
                productname = "Mercimek",
                productvalue = 480


            });
            productClasses.Add(new ProductClass()
            {
                productname = "Arpa",
                productvalue = 250


            });
            productClasses.Add(new ProductClass()
            {
                productname = "Pirinç",
                productvalue = 120


            });
            productClasses.Add(new ProductClass()
            {
                productname = "Domates",
                productvalue = 960


            });
            // Json bunları grafiğe aktarabilmem için gerekli metottur.

            return Json(new { jsonlist=productClasses });

        }

    }
}
