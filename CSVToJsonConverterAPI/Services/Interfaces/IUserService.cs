using System.Text.Json.Nodes;

namespace CSVToJsonConverterAPI.Services.Interfaces
{
    public interface IUserService
    {
        // TODO Add the implementation of GetUsers and GetUsersByLimit
        JsonArray GetUsersFromRepo();
    }
}
