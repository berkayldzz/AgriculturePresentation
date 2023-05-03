using Microsoft.AspNetCore.Mvc;

namespace AgriculturePresentation.ViewCompenents
{
	public class _HeadPartial : ViewComponent
	{
		// Partial view bizim ihtiyacımızı karşılamadığı için ViewComponent kullanıyoruz.

		// Controller tarafında IActionResult olarak tanımladığımız yapıyı burda IViewComponentResult olarak tanımlıyoruz.
		// Invoke varsayılan olarak verdiği isim

		// Asp.Net Core ViewComponents içersinde tanımlanmış olan sınıflara bağlı olan viewleri shared içersinde tanımladığım components klasörü içerisinde arıyor.
		// Components içinde tanımladığım klasörün ismi çağıracağımız view in ismiyle aynı olmalı.

		// Yani Invoke üzerinde add view yapamıyorum ama Components içinde tanımladığım _HeadPartial isimli klasörün üstünden oluşturacağım.
		public IViewComponentResult Invoke()
		{
			return View();
		}


	}
}
