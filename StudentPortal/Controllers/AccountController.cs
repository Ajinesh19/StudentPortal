using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

using StudentPortal.Models;

namespace StudentPortal.Controllers
{
    public class AccountController:Controller
    {
        [Route("signup")]
        public IActionResult SignUp()
        {
            return View();
        }
        
        [Route("signup")]
        [HttpPost]
        public IActionResult SignUp(SignUpUserModel signUpUser)
        {
            if (ModelState.IsValid)
            {
                //write your code
                ModelState.Clear();
            }
            return View();
        }
    }
}
