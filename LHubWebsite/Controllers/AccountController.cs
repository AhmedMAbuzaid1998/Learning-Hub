using Microsoft.AspNetCore.Mvc;

public class AccountController : Controller
{
    private readonly RegistrationService _regService;
    public AccountController(RegistrationService regService) => _regService = regService;

    [HttpGet]
    public IActionResult Register() => View();

    [HttpPost]
    public async Task<IActionResult> Register(User user)
    {
        if (ModelState.IsValid)
        {
            if (await _regService.Register(user))
                return RedirectToAction("Login"); // Redirect on success
            ModelState.AddModelError("", "Invalid data (username/email may exist)");
        }
        return View(user); // Show errors
    }
}