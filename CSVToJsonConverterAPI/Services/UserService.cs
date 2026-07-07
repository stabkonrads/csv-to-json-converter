using CSVToJsonConverterAPI.Repositories.Interfaces;
using CSVToJsonConverterAPI.Services.Interfaces;
using System.Text.Json.Nodes;

namespace CSVToJsonConverterAPI.Services
{
    public class UserService : IUserService
    {
        IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public JsonArray GetUsersFromRepo(int limit)
        {
            if (limit == 0)
                return _userRepository.GetUsers();
            else
                return _userRepository.GetLimitedUsers(limit);
        }
    }
}
