using MNote.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MNote.Web.Services.Interfaces
{
    public interface IUsersService
    {
        ApplicationUser GetUserByUsername(string username);
    }
}
