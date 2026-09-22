using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Recepten_bootcamp_AI.Model_Services;
using Recepten_bootcamp_AI.Models;

namespace Recepten_bootcamp_AI.Pages
{
    public class ReceptToevoegenModel : PageModel
    {
        private readonly ReceptService _receptService;

        [BindProperty]
        public Recept Recept { get; set; } = new();

        public ReceptToevoegenModel(ReceptService receptService)
        {
            _receptService = receptService;
        }

        public void OnGet()
        {
            Recept.Ingredienten.Add(new Ingredient());
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _receptService.VoegReceptToe(Recept);

            return RedirectToPage("/Recepten");
        }
    }
}