using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
// These statements import the Pizza and PizzaService types you'll use in the page.


using ContosoPizza.Models;
using ContosoPizza.Services;

namespace ContosoPizza.Pages
{
    public class PizzaListModel : PageModel
    {
        private readonly PizzaService _service;
        public IList<Pizza> PizzaList { get; set; } = default!;
        // BindProperty attribute is used to bind the NewPizza property to the Razor Page
        [BindProperty]
        // The default! keyword is used to initialize the NewPizza property to null.
        // This prevents the compiler from generating a warning about the NewPizza property being uninitialized.
        public Pizza NewPizza { get; set; } = default!;

        public PizzaListModel(PizzaService service)
        {
            _service = service;
        }

        public void OnGet()
        {
            PizzaList = _service.GetPizzas();
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid || NewPizza == null)
            {
                return Page();
            }

            _service.AddPizza(NewPizza);

            return RedirectToAction("Get");
        }
        public IActionResult OnPostDelete(int id)
        {
            _service.DeletePizza(id);

            return RedirectToAction("Get");
        }
    }

}
