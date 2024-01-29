using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Onyx.Client.Models;

namespace Onyx.Client.Controllers;

[Authorize]
public class ProductsController : Controller
{
    public ProductsController()
    {
    }

    public async Task<ActionResult> Index()
    {
        var info = await LogIdentityInformation();

        return View(new ProductsViewModel(info));
    }

    public async Task<string> LogIdentityInformation()
    {
        var identityToken = await HttpContext.GetTokenAsync(OpenIdConnectParameterNames.IdToken);

        var accessToken = await HttpContext.GetTokenAsync(OpenIdConnectParameterNames.AccessToken);

        return $"Identity token: \n{identityToken} \n\n\nAccess Token: \n{accessToken}";
    }
}

