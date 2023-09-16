using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FIT_Api_Examples.Helper.AutentifikacijaAutorizacija
{
    public class AutorizacijaAttribute : TypeFilterAttribute
    {
        public AutorizacijaAttribute(bool korisnik, bool konobar, bool administrator, bool dostavljac)
            : base(typeof(MyAuthorizeImpl))
        {
            Arguments = new object[] { korisnik, konobar, administrator, dostavljac };
        }
    }


    public class MyAuthorizeImpl : IActionFilter
    {
        private readonly bool _korisnik;
        private readonly bool _konobar;
        private readonly bool _administrator;
        private readonly bool _dostavljac;

        public MyAuthorizeImpl(bool korisnik, bool konobar, bool administrator, bool dostavljac)
        {
            _korisnik = korisnik;
            _konobar = konobar;
            _administrator = administrator;
            _dostavljac = dostavljac;
        }
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            KretanjePoSistemu.Save(filterContext.HttpContext);
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            MyAuthTokenExtension.LoginInformacije loginInfo = filterContext.HttpContext.GetLoginInfo();
            if (!loginInfo.isLogiran || loginInfo.korisnickiNalog == null)
            {
                filterContext.Result = new UnauthorizedResult();
                return;
            }

            if (!loginInfo.isLogiran)
            {
                //filterContext.Result = new UnauthorizedObjectResult("korisnik nije aktiviran - provjerite email poruke " + loginInfo.korisnickiNalog.email);

                //    //ponovo posalji email za aktivaciju
                //    if (loginInfo.korisnickiNalog.Korisnik!=null)
                //        EmailLog.noviNastavnik(loginInfo.korisnickiNalog.nastavnik, filterContext.HttpContext);
                //    return;
                //}


                //if (loginInfo.korisnickiNalog.isAdmin)
                //{
                //    if (loginInfo.autentifikacijaToken == null || !loginInfo.autentifikacijaToken.twoFJelOtkljucano)
                //    {
                //        filterContext.Result = new UnauthorizedObjectResult("potrebno je otkljucati login sa codom poslat na email " + loginInfo.korisnickiNalog.email);
                //        return;
                //    }

                //    return;//ok - ima pravo pristupa
                //}

                //if (loginInfo.korisnickiNalog.isNastavnik && _nastavnici)
                //{
                //    if (loginInfo.autentifikacijaToken == null || !loginInfo.autentifikacijaToken.twoFJelOtkljucano)
                //    {
                //        filterContext.Result = new UnauthorizedObjectResult("potrebno je otkljucati login sa codom poslat na email " + loginInfo.korisnickiNalog.email);
                //        return;
                //    }

                //    return;//ok - ima pravo pristupa
                //}
                //if (loginInfo.korisnickiNalog.isStudent && _studenti)
                //{
                //    return;//ok - ima pravo pristupa
                //}

                //if (loginInfo.korisnickiNalog.isDekan && _dekan)
                //{
                //    return;//ok - ima pravo pristupa
                //}

                //if ((loginInfo.korisnickiNalog.isProdekan || loginInfo.korisnickiNalog.isDekan) && _prodekan)
                //{
                //    return;//ok - ima pravo pristupa
                //}
                //if ((loginInfo.korisnickiNalog.isStudentskaSluzba || loginInfo.korisnickiNalog.isDekan || loginInfo.korisnickiNalog.isProdekan) && _studentskaSluzba)
                //{
                //    return;//ok - ima pravo pristupa
                //}


                ////else nema pravo pristupa
                //filterContext.Result = new UnauthorizedResult();
            }
        } 
    }
}
