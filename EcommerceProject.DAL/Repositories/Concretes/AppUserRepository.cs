using EcommerceProject.DAL.Context;
using EcommerceProject.DAL.Repositories.Abstracts;
using EcommerceProject.ENTITIES.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceProject.DAL.Repositories.Concretes
{
    public class AppUserRepository : BaseRepository<AppUser>, IAppUserRepository
    {
        UserManager<AppUser> _userManager;
        public AppUserRepository(MyContext db,UserManager<AppUser> userManager) : base(db)
        {
            _userManager = userManager;
        }

        public async Task<bool> AddUser(AppUser item)
        {
            IdentityResult result = await _userManager.CreateAsync(item,item.PasswordHash);
            if (result.Succeeded) return true;
            return false;
        }
    }
}
