using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FruitAndVegApp;

namespace FruitAndVegApp
{
    public class ListModel : PageModel
    {
        private FiveADayService _service = default!;
        public IEnumerable<FiveADay> FruitAndVegList = new List<FiveADay>();

        public ListModel(FiveADayService fruitAndVegService)
        {
            _service = fruitAndVegService;
        }

        public void OnGet()
        {
            FruitAndVegList = _service.SelectAll();


        }


    }
}
