using eRestaurant.Authentication.Models;

namespace eRestaurant.Helper
{
    public class EmailLog
    {
        public static void uspjesnoLogiranKorisnik(AuthenticationToken token, HttpContext httpContext)
        {
            var logiraniKorisnik = token.korisnickiNalog;
                var poruka = $"Hello <b>{logiraniKorisnik.Username}</b>, <br> " +
                              $"2 factor authentication code to access the application is: " +
                              $"<b>{token.TwoFCode}</b><br><br>" +
                              $"Enjoy the pleasure of using our services. <br>" +
                              $"<b>eRestaurant Team</b> <br><br>" +
                              $"Login time: {DateTime.Now}";


                EmailSender.Posalji(logiraniKorisnik.Email, "2 factor authentication code", poruka, true);
        }
    }
}
