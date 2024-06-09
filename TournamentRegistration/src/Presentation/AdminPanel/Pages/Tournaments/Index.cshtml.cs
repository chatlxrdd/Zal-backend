using Microsoft.AspNetCore.Mvc.RazorPages;
using AdminPanel.Services;
using Core.Entities; // Dodaj to
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdminPanel.Pages.Tournaments
{
    public class IndexModel : PageModel
    {
        private readonly SoapClient _soapClient;

        public IndexModel(SoapClient soapClient)
        {
            _soapClient = soapClient;
        }

        public List<Core.Entities.Tournament> Tournaments { get; set; }

        public async Task OnGetAsync()
        {
            Tournaments = await _soapClient.GetTournaments();
        }
    }
}
