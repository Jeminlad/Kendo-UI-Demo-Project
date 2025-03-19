using System.Diagnostics;
using KendoDemo;
using KendoDemo.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;
using MVC.Models;

namespace MVC.Controllers;

public class HomeController : Controller
{
    private readonly IUserInterface _userRepo;
    public HomeController(IUserInterface userRepo)
    {
        _userRepo = userRepo;
    }

    #region Login Method
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(vm_Login login)
    {
        t_User UserData = await _userRepo.Login(login);
        if (ModelState.IsValid)
        {
            if (UserData.c_UserId != 0)
            {
                HttpContext.Session.SetInt32("UserId", UserData.c_UserId);
                HttpContext.Session.SetString("UserName", UserData.c_UserName);
                return new JsonResult(new { success = true });
            }
        }
        else
        {
            return new JsonResult(new { success = false, message = "Username or password incorrect" });
        }
        return View(login);
    }
    #endregion






    #region Register Method
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register(t_User user)
    {
        if (ModelState.IsValid)
        {
            if (user.ProfilePicture != null && user.ProfilePicture.Length > 0)
            {
                var fileName = user.c_Email + Path.GetExtension(user.ProfilePicture.FileName);
                var filePath = Path.Combine("../MVC/wwwroot/profile_images", fileName);
                // Directory.CreateDirectory(Path.Combine("../MVC/wwwroot/profile_images"));
                // user.c_Image = fileName;
                // using (var stream = new FileStream(filePath, FileMode.Create))
                // {
                //     user.ProfilePicture.CopyTo(stream);
                // }
            }
            // Console.WriteLine("user.c_fname: " + user.c_UserName);
            var status = await _userRepo.Register(user);
            if (status == 1)
            {
                return new JsonResult(new { success = true, message = "Register Successfully" });
            }
            else if (status == 0)
            {
                return new JsonResult(new { success = false, message = "Username Already Register" });
            }
            else
            {
                return new JsonResult(new { success = false, message = "Error in registration" });
            }
        }
        else
        {
            return BadRequest(ModelState); // Return validation errors
        }
    }
    #endregion






    #region Logout Method
    public async Task<ActionResult> Logout()
    {
        HttpContext.Session.Clear();
        if (HttpContext.Session.GetInt32("UserId") != null)
        {
            return RedirectToAction("KendoIndex", "ContactSingle");
        }
        else
        {
            return RedirectToAction("Login", "Home");
        }
    }

    #endregion
}