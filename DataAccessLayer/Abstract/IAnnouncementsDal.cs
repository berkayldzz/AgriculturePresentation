using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IAnnouncementsDal:IGenericDal<Announcement>
    {
        // Aktif Pasif Yap İşlemleri

        // Bunları tanımladıktan sonra EfAnnouncementDal kısmında implement etmem gerekiyo. 
        void AnnouncementStatusToTrue(int id);
        void AnnouncementStatusToFalse(int id);
    }
}
