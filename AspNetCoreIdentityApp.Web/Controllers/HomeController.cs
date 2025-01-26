using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AspNetCoreIdentityApp.Web.Models;
using AspNetCoreIdentityApp.Web.ViewModel;
using Microsoft.AspNetCore.Identity;

namespace AspNetCoreIdentityApp.Web.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    private readonly UserManager<AppUser> _userManager;

    public HomeController(ILogger<HomeController> logger, UserManager<AppUser> userManager)
    {
        _logger = logger;
        _userManager = userManager;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult SignUp()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> SignUp(SignUpViewModel request)
    {
        var identityResult = await _userManager.CreateAsync(new()
        {
            UserName = request.UserName,
            Email = request.Email,
            PhoneNumber = request.Phone
        }, request.Password);

        if (identityResult.Succeeded)
        {
            TempData["SuccessMessage"] = "Member registration has been completed successfully.";
            //framework taraf?ndan cookiede tek seferlik tasinir.
            return RedirectToAction(nameof(HomeController.SignUp));
        }

        foreach (IdentityError item in identityResult.Errors)
        {
            ModelState.AddModelError(string.Empty, item.Description);
        }
        return View();

    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
