
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using MySkills.Core.Interfaces.Services;
using MySkills.Core.Interfaces.IUnitOfWork;
using MySkills.Core.Entities;

namespace MySkills.Core.Services
{
    public class AspNetUsersService : IAspNetUsersService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AspNetUsersService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<AspNetUsers> GetAspNetUsers()
        {
            return _unitOfWork.AspNetUsersRepository.GetAll();
        }

    }
}