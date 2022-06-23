using C1.Web.Mvc;
using C1.Web.Mvc.Serialization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using wijimo.Model;
using wijimo.Services;
namespace wijimo.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ICarService _carService;

        public IndexModel(ICarService carService)
        {
            _carService = carService;
        }

        //public JsonResult OnGet()
        //{
        //    return new JsonResult(_carService.GetAll());
        //}
    }
}