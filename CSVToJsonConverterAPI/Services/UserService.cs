using CSVToJsonConverterAPI.Repositories.Interfaces;
using CSVToJsonConverterAPI.Services.Interfaces;

namespace CSVToJsonConverterAPI.Services
{
    public class UserService : IUserService
    {
        IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
    }
}
