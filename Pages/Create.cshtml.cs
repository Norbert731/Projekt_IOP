using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static Projekt_IOP.Pages.IndexModel;

namespace Projekt_IOP.Pages;

    public class CreateModel : PageModel
    {
        public ClientInfo clientInfo = new ClientInfo();
        public String errorMassege = "";
        public String successMessage = "";
        public void OnGet()
        {
        }

        public void OnPost()
        {

			// Setting requaried fields
			clientInfo.first_name = Request.Form["first_name"];
			clientInfo.last_name = Request.Form["last_name"];
			clientInfo.email = Request.Form["email"];
			clientInfo.gender = Request.Form["gender"];
			clientInfo.country = Request.Form["country"];
			clientInfo.city = Request.Form["city"];

            if (clientInfo.first_name.Length == 0 || clientInfo.email.Length == 0 || clientInfo.email.Length == 0 || clientInfo.country.Length == 0 || clientInfo.gender.Length == 0 || clientInfo.city.Length == 0)
            {
                errorMassege = "Aby dodaæ kontakt musisz wype³niæ wszystkie pola";
                return;
            }

            // Save the new client into database

            clientInfo.first_name = ""; clientInfo.last_name = ""; clientInfo.email = ""; clientInfo.country = ""; clientInfo.gender = ""; clientInfo.city = "";
            successMessage = "Pomyœlnie dodano nowy kontakt.";

		}
    }

