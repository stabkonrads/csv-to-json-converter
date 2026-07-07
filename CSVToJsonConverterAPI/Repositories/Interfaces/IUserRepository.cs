using System.Text.Json.Nodes;

namespace CSVToJsonConverterAPI.Repositories.Interfaces
{
    public interface IUserRepository
    {
        JsonArray GetUsers();
        JsonArray GetLimitedUsers(int limit);
    }
}
