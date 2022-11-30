using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ITI.Ecommerce.Presenation.Controllers
{
    public class RoleController : Controller
    {
        RoleManager<IdentityRole> RoleManager;
        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            RoleManager = roleManager;
        }


        [HttpGet]
        public IActionResult Add()
        {

            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Add(RoleCreateModel model)
        {

            if (ModelState.IsValid == false)
                return View();
            else
            {
                var result =
                await RoleManager.CreateAsync(
                    new IdentityRole
                    {
                        Name = model.Name
                    });
                if (result.Succeeded == false)
                {
                    result.Errors.ToList().ForEach(i =>
                    {
                        ModelState.AddModelError("", i.Description);
                    });
                    return View();
                }
                else
                {
                    return RedirectToAction("SignUp", "UserMang");
                }

            }
        }
    }
}
