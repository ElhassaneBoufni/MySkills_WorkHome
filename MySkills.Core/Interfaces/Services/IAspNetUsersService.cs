
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using MySkills.Core.Entities;

namespace MySkills.Core.Interfaces.Services
{
    public interface IAspNetUsersService
    {
        IEnumerable<AspNetUsers> GetAspNetUsers();
    }
}