using System.Web.Mvc;
using System.Web.WebPages;

namespace Scaffolding.Controllers
{
    public class ViewSwitcherController : Controller
    {
        public RedirectResult SwitchView(bool userRequestedMobileState, string returnUrl) {
            //--- Redirect to Mobile or Desktop based on device detection-----
            if (Request.Browser.IsMobileDevice == userRequestedMobileState)
            {
                //--- We are a "mobile device" and "userRequestedMobileState"=true ----
                HttpContext.ClearOverriddenBrowser();
            }
            else
            {
                //--- We are NOT a "mobile device"----
                if (userRequestedMobileState == true)
                {
                    //--- We are NOT a "mobile device" and "userRequestedMobileState"=true ----
                    HttpContext.SetOverriddenBrowser(BrowserOverride.Mobile);
                }
                else
                {
                    //--- We are NOT a "mobile device" and "userRequestedMobileState"=false ----
                    HttpContext.SetOverriddenBrowser(BrowserOverride.Desktop);
                }
            }

            //---Redirect To View--------
            return Redirect(returnUrl);
        }
    }
}
