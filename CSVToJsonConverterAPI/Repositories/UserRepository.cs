using CSVToJsonConverterAPI.Exceptions;
using CSVToJsonConverterAPI.Models;
using CSVToJsonConverterAPI.Repositories.Interfaces;
using System.Text.Json.Nodes;

namespace CSVToJsonConverterAPI.Repositories
{
    public class UserRepository : IUserRepository
    {
        
        public JsonArray GetUsers()
        {
            return LoadData();
        }

        private JsonArray LoadData()
        {
            string filePath = "Data\\exampledata.csv";
            try
            {
                if (File.Exists(filePath))
                {
                    string[] dataSource = File.ReadAllLines(filePath);

                    if (dataSource.Length == 0)
                        throw new FileIsEmptyException();

                    return ConvertCSVToJSON(dataSource);
                }
                else
                {
                    throw new FileNotFoundException("The datasource does not exist.");
                }
                
            }
            catch (FileIsEmptyException)
            {
                throw;
            }
            catch (FileNotFoundException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private JsonArray ConvertCSVToJSON(string[] dataSource)
        {
            JsonArray jsonArray = new JsonArray();

            foreach(string row in dataSource)
            {
                string[] strings = row.Split(";");
                User user = new User(
                    Convert.ToInt32(strings[0]),    // Id
                    strings[1],                     // Name
                    Convert.ToInt32(strings[2]),    // Age
                    strings[3]);                    // Email

                jsonArray.Add(user);
            }

            return jsonArray;
        }
    }
}
