using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity; 
using QuizCreation.Entities.Concrete.Identity;
namespace QuizCreation.UI.Controllers
{
   
    public class AccountController : Controller
    {
        private readonly IConfiguration configuration;
        UserManager<ApplicationUser> UserManager;
        SignInManager<ApplicationUser> SignInManager;
        RoleManager<ApplicationRole> RoleManager;
        IWebHostEnvironment env;

        public AccountController(
            UserManager<ApplicationUser> UserManager,
            SignInManager<ApplicationUser> SignInManager,
            RoleManager<ApplicationRole> RoleManager, IConfiguration configuration, IWebHostEnvironment env)
        {
            this.configuration = configuration;
            this.RoleManager = RoleManager;
            this.UserManager = UserManager;
            this.SignInManager = SignInManager;
            this.env = env;
        }
        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            ViewBag.returnUrl = returnUrl;
            return View();
        }
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(string username, string password, string returnUrl)
        {
            try
            {
                ApplicationUser user = await UserManager.FindByNameAsync(username);
                if (user != null)
                {
                    var res = await SignInManager.PasswordSignInAsync(username, password, true, false);
                    if (res.Succeeded)
                    {
                        if (!string.IsNullOrEmpty(returnUrl))
                            return Redirect(returnUrl);
                        else
                            return LocalRedirect("/");

                    }
                    ViewBag.ErrorMessage = "Kullanıcı Adınız veya Şifreniz Hatalı!";
                    ViewBag.UserName = username;
                    return View();
                }
                else
                {
                    ViewBag.ErrorMessage = "Kullanıcı Adınız veya Şifreniz Hatalı!";
                    ViewBag.UserName = username;
                    return View();

                }
            }
            catch (Exception e)
            {
                ViewBag.UserName = username;
                ViewBag.ErrorMessage = "Maalesef, bilinmeyen bir hata oluştu.Lütfen Tekrar Deneyiniz!";
                return View();
            }
        }
        [HttpGet]
        public  IActionResult SignOut()
        {
             SignInManager.SignOutAsync();
            return LocalRedirect("/");
        }

        #region Şuan İçin kullanıcı işlemlerinin kayıt ol vs. gerekli olmadığından ilk kullanıcı bu şekilde oluşturuldu 
        //[HttpGet]
        //public async Task<IActionResult> Create()
        //{
        //    //await RoleManager.CreateAsync(new ApplicationRole
        //    //{ Name = "admin"
        //    //});

        //    //var res = await UserManager.CreateAsync(new ApplicationUser
        //    //{
        //    //    UserName = "admin",
        //    //    Email = "abdullahtunc.t@gmail.com",
        //    //}, "Admin.123***");


        //    var user = await UserManager.FindByNameAsync("admin");
        //    await UserManager.AddToRoleAsync(user, "admin");
        //    return RedirectToAction("login");
        //}
        #endregion

    }
}
