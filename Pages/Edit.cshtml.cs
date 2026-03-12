using FruitAndVegApp;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyApp.Namespace
{

    public class EditModel : PageModel
    {
        private FiveADayService _service = default!;
        [BindProperty]
        public FiveADay Five { get; set; } = new();

        public void OnGet(int id)
        {
            Console.WriteLine($"EditModel OnGet() called with id={id}");

            Five = _service.Select(id);
        }

        public EditModel(FiveADayService fiveADayService)
        {
            _service = fiveADayService;
        }


        public IActionResult OnPost()
        {
            Console.WriteLine("EditModel OnPost() called");

            if (!ModelState.IsValid)
            {
                return Page();
            }

            _service.Update(Five);
            return RedirectToPage("Index");

        }

    }
}
