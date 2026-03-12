using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FruitAndVegApp
{
    public class DeleteModel : PageModel
    {
        private FiveADayService _service = default!;
        public DeleteModel(FiveADayService fiveADayService)
        {
            _service = fiveADayService;
        }
        public IActionResult OnPost(int id)
        {
            Console.WriteLine("Deleting " + id);


            _service.Delete(id);
            return RedirectToPage("Index");
        }
    }
}
