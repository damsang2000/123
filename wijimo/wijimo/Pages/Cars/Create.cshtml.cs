using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using wijimo.Data;
using wijimo.Entity;
using wijimo.Model;
using wijimo.Services;

namespace wijimo.Pages.Cars
{
    public class CreateModel : PageModel
    {
        private readonly ICarService carService;

        public CreateModel(ICarService carService)
        {
            this.carService = carService;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Car Car { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            //if (!ModelState.IsValid || _context.Car == null || Car == null)
            //{
            //    return Page();
            //}

            //_context.Car.Add(Car);
            //await _context.SaveChangesAsync();

            if (ModelState.IsValid)
            {
                await carService.Save(Car);
            }
            return Page();
            //return RedirectToPage("./Index");
        }
    }
}
