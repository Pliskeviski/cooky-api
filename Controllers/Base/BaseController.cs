using Cooky.API.Models;
using Cooky.API.Repositories.UserRepository;
using Microsoft.AspNetCore.Mvc;


namespace Cooky.API.Controllers.Base
{
    public class BaseController : ControllerBase
    {
        private IUserRepository _userRepository { get; set; }
        private User _user { get; set; } = null;
        public BaseController(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }

        public User CurrentUser
        {
            get
            {
                if (_user == null && !string.IsNullOrEmpty(User.Identity.Name))
                    _user = _userRepository.GetByIdAsync(User.Identity.Name).Result;
        
                return _user;
            }
            set { _user = value; }
        }
    }
}
