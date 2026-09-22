using Microsoft.AspNetCore.Mvc.RazorPages;
using Recepten_bootcamp_AI.Models;
using Recepten_bootcamp_AI.Model_Services;

namespace Recepten_bootcamp_AI.Pages
{
    public class ReceptenModel : PageModel
    {
        private readonly ReceptService _receptService;

        public List<Recept> Recepten { get; set; } = new();

        public ReceptenModel(ReceptService receptService)
        {
            _receptService = receptService;
        }

        public void OnGet()
        {
            Recepten = _receptService.HaalReceptenOp();
        }
    }
}