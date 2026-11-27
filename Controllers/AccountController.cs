using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace web_robotics.Controllers;

[Route("quan-tri-noi-bo")]
public class AccountController(IConfiguration configuration) : Controller
{
    [HttpGet("dang-nhap")]
    public IActionResult Login(string? returnUrl = null)
    {
        if (User.Identity?.IsAuthenticated == true && User.IsInRole("Admin"))
        {
            return RedirectToAction("Index", "Admin");
        }

        ViewBag.ReturnUrl = returnUrl;
        return View();
    }

    [HttpPost("dang-nhap")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(string username, string password, string? returnUrl = null)
    {
        var expectedUser = configuration["AdminAuth:Username"] ?? "admin";
        var expectedPass = configuration["AdminAuth:Password"] ?? "Admin@123";

        if (string.Equals(username?.Trim(), expectedUser, StringComparison.OrdinalIgnoreCase) &&
            string.Equals(password, expectedPass, StringComparison.Ordinal))
        {
            var claims = new List<Claim>
            {
                new(ClaimTypes.Name, expectedUser),
                new(ClaimTypes.Role, "Admin")
            };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                principal,
                new AuthenticationProperties { IsPersistent = true });

            if (!string.IsNullOrWhiteSpace(returnUrl) && Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }

            return RedirectToAction("Index", "Admin");
        }

        ViewBag.Error = "Tên đăng nhập hoặc mật khẩu quản trị chưa đúng.";
        ViewBag.ReturnUrl = returnUrl;
        return View();
    }

    [HttpPost("dang-xuat")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return RedirectToAction("Index", "Home");
    }

    [HttpGet("tu-choi")]
    public IActionResult AccessDenied()
    {
        return View();
    }
}
