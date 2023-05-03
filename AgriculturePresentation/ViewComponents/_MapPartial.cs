using DataAccessLayer.Context;
using Microsoft.AspNetCore.Mvc;

namespace AgriculturePresentation.ViewComponents
{
	public class _MapPartial:ViewComponent
	{

		public IViewComponentResult Invoke()
		{
			AgricultureContext agricultureContext =new AgricultureContext();
			var values=agricultureContext.Addresses.Select(x=>x.Mapinfo).FirstOrDefault();

			ViewBag.v=values;
			
			return View();
		}



	}
}
