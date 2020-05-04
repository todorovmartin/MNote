using Microsoft.AspNetCore.Identity;
using MNote.Data;
using MNote.Data.Models;
using MNote.Web.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MNote.Web.Services
{
    public class UsersService : IUsersService
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly MNoteDbContext db;

        public UsersService(UserManager<ApplicationUser> userManager, MNoteDbContext db)
        {
            this.userManager = userManager;
            this.db = db;
        }

        public ApplicationUser GetUserByUsername(string username)
        {
            return this.userManager.FindByNameAsync(username).GetAwaiter().GetResult();
        }
    }
}
