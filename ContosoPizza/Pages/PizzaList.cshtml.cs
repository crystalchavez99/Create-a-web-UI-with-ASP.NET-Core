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
    public IList<Pizza> PizzaList { get;set; } = default!;

    public PizzaListModel(PizzaService service)
    {
        _service = service;
    }

    public void OnGet()
    {
        PizzaList = _service.GetPizzas();
    }
}
}
