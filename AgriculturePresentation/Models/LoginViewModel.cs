using System.ComponentModel.DataAnnotations;

namespace AgriculturePresentation.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="Lütfen kullanıcı adını girin!")]
        public string username { get; set; }
        
        [Required(ErrorMessage = "Lütfen şifrenizi girin!")]
        public string password { get; set; }


    }
}
