using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ThoemusBike.WebApp.Pages;

public class LogoutModel : PageModel
{
    public async Task OnGetAsync()
    {
        await HttpContext.SignOutAsync();
        Response.Redirect("/");
    }
}
