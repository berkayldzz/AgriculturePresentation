using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace AgriculturePresentation.ViewComponents
{
	public class _TopAddressPartial:ViewComponent
	{
		// Sqlde tuttuğum adres tablomdaki bazı bilgilerimi burda çağırabilirim
		// Controllerda yaptığım gibi constructor oluşturup listeleme komutumu yazıcam.

		private readonly IAddressService _addressService;

		public _TopAddressPartial(IAddressService addressService)
		{
			_addressService = addressService;
		}

		public IViewComponentResult Invoke()
		{
			var values = _addressService.GetListAll();
			return View(values);
		}

	}
}
