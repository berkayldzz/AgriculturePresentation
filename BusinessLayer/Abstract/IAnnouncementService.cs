using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IAnnouncementService:IGenericService<Announcement>
    {
        // Tanımladığım metotlarımı çağırdım.Ve manager kısmında implement ederek ilgili işlemlerini yaptım.
        void AnnouncementStatusToTrue(int id);
        void AnnouncementStatusToFalse(int   id);

    }
}
