using DataAccessLayer.Context;

using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgriculturePresentation.ViewComponents
{
    public class _DashboardOverviewPartial : ViewComponent
    {
        AgricultureContext c = new AgricultureContext();
        public IViewComponentResult Invoke()
        {
            // İstatistik kısmı

            ViewBag.teamCount = c.Teams.Count(); // Teamsdeki üye sayısı
            ViewBag.serviceCount = c.Services.Count(); // Hizmet sayısı 
            ViewBag.messageCount = c.Contacts.Count();  // Toplam mesaj sayısı
            ViewBag.currentMonthMessage = c.Contacts.Where(x => x.Date.Month == DateTime.Now.Month).Count();   // İçinde bulunduğumuz ay neyse o ayın mesaj sayısını tutma

            ViewBag.announcementTrue = c.Announcements.Where(x => x.Status == true).Count(); // Aktif duyuru sayısı
            ViewBag.announcementFalse = c.Announcements.Where(x => x.Status == false).Count();  // Pasif duyuru sayısı

            ViewBag.urunPazarlama = c.Teams.Where(x => x.Title == "Ürün Pazarlama").Select(y => y.PersonName).FirstOrDefault();
            ViewBag.bakliyatYonetimi = c.Teams.Where(x => x.Title == "Bakliyat Yönetimi").Select(y => y.PersonName).FirstOrDefault();
            ViewBag.sutUretici = c.Teams.Where(x => x.Title == "Süt Üreticisi").Select(y => y.PersonName).FirstOrDefault();
            ViewBag.gubreYonetimi = c.Teams.Where(x => x.Title == "Gübre Yönetimi").Select(y => y.PersonName).FirstOrDefault();
            return View();
        }
    }
}
