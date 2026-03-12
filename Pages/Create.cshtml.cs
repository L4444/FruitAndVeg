using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace FruitAndVegApp
{

    public class CreateModel : PageModel
    {
        private FiveADayService _service = default!;
        [BindProperty]
        public FiveADay NewFiveADay { get; set; } = new();


        public CreateModel(FiveADayService fiveADayService)
        {


            _service = fiveADayService;

            Console.WriteLine("CreateModel constructer called");


        }

        public void OnGet()
        {
            Console.WriteLine("CreateModel OnGet() called");
        }

        public IActionResult OnPost()
        {

            Console.WriteLine("Lets see what's in ModelState");
            foreach (var entry in ModelState)
            {
                Console.WriteLine($"Key:\'{entry.Key}\' Value:\'{entry.Value.AttemptedValue}\'");
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }





            _service.Insert(NewFiveADay);
            return RedirectToPage("Index");

        }


    }
}
