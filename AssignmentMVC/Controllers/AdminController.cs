using AssignmentMVC.Repositories;
using Microsoft.AspNetCore.Mvc;
using AssignmentMVC.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using AssignmentMVC.ViewModel;

namespace AssignmentMVC.Controllers
{
    public class AdminController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        
        
        public AdminController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;

        }
        public async Task<IActionResult> DisplayUsers()
        {
            //var users = await _userManager.Users.ToListAsync();
            AdminRepository adminRepository = new AdminRepository();
            List<AppUser> user = adminRepository.GetAllUsers();

            List<UserRoleViewModel> userRoleViewModel = user.Select(async u => new UserRoleViewModel
            {
                Firstname = u.Firstname,
                Lastname = u.Lastname,
                Email = u.Email,
                City = u.City,
                StreetName = u.StreetName,
                PostalCode = u.PostalCode,
                Roles = await _userManager.GetRolesAsync(u)
            }).Select(t => t.Result).ToList();
            

            return View(userRoleViewModel);
        }
    }
}
