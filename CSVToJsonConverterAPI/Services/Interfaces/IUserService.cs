using System.Text.Json.Nodes;

namespace CSVToJsonConverterAPI.Services.Interfaces
{
    public interface IUserService
    {
        JsonArray GetUsersFromRepo(int limit);
    }
}
