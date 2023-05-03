using BusinessLayer.Abstract;
using BusinessLayer.ValidationRules;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace AgriculturePresentation.Controllers
{
    public class TeamController : Controller
    {
        // Constructor kullanarak işlemlerimi yapıcam.

        private readonly ITeamService _teamService;

        public TeamController(ITeamService teamService)
        {
            _teamService = teamService;
        }

        public IActionResult Index()
        {
            var values=_teamService.GetListAll();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddTeam() 
        {
            return View();

        }
        [HttpPost]
        public IActionResult AddTeam(Team team)
        {

            TeamValidator validationRules = new TeamValidator();
            ValidationResult result = validationRules.Validate(team);  // teamdan gelen değerleri kontrol et.
            if(result.IsValid)
            {
                _teamService.Insert(team);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
           
        }

        public IActionResult DeleteTeam(int id)
        {
            var value = _teamService.GetById(id);
            _teamService.Delete(value);
            return RedirectToAction("Index");

        }
        [HttpGet]

        public IActionResult EditTeam(int id)
        {
            var value = _teamService.GetById(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult EditTeam(Team team)
        {
            // Validation(doğrulama) kuralları burada da geçerli olacak.

            TeamValidator validationRules = new TeamValidator();
            ValidationResult result = validationRules.Validate(team);  // teamdan gelen değerleri kontrol et.
            if (result.IsValid)
            {
                _teamService.Update(team);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();

        }
    }
}
