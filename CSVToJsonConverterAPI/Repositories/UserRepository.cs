using CSVToJsonConverterAPI.Exceptions;
using CSVToJsonConverterAPI.Models;
using CSVToJsonConverterAPI.Repositories.Interfaces;
using System.Text.Json.Nodes;

namespace CSVToJsonConverterAPI.Repositories
{
    public class UserRepository : IUserRepository
    {
        const string DataSourceFilePath = "Data\\exampledata.csv";
        
        /// <summary>
        /// The method fetches and returns a JsonArray with all the users
        /// </summary>
        /// <returns>A JsonArray with Users.</returns>
        public JsonArray GetUsers()
        {
            return GetUsersJson();
        }

        /// <summary>
        /// The method fetches and returns a JsonArray with users by limit.
        /// </summary>
        /// <param name="limit">Number of users to get.</param>
        /// <returns>A JsonArray with Users.</returns>
        public JsonArray GetLimitedUsers(int limit)
        {
            return GetUsersJson(limit);
        }

        /// <summary>
        /// The method returns a JsonArray with users that has been converted from a CSV file.
        /// </summary>
        /// <returns>JsonArray with Users.</returns>
        private JsonArray GetUsersJson()
        {
            try
            {
                return ConvertCSVToJSON(GetDataSource());
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// The method returns a JsonArray with users that has been converted from a CSV file.
        /// </summary>
        /// <param name="limit">Number of users to return.</param>
        /// <returns>JsonArray with Users.</returns>
        private JsonArray GetUsersJson(int limit)
        {
            try
            {
                return ConvertCSVToJSONByLimit(GetDataSource(), limit);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Loads the csv file from a given path and returns a string array with the result.
        /// </summary>
        /// <returns>A string array with read lines from datasource.</returns>
        private string[] GetDataSource()
        {
            try
            {
                if (File.Exists(DataSourceFilePath))
                {
                    string[] dataSource = File.ReadAllLines(DataSourceFilePath);

                    if (dataSource.Length == 0)
                        throw new FileIsEmptyException("The datasource does not contain any data.");

                    return dataSource;
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

        /// <summary>
        /// Convert the lines from datasource to users and adds them to a JsonArray.
        /// </summary>
        /// <param name="dataSource">The stringarray to iterate through.</param>
        /// <returns>A JsonArray with converted user data.</returns>
        private JsonArray ConvertCSVToJSON(string[] dataSource)
        {
            JsonArray jsonArray = new JsonArray();

            foreach(string row in dataSource)
            {
                string[] strings = row.Split(";");

                User user = CreateUser(strings);

                jsonArray.Add(user);
            }

            return jsonArray;
        }

        /// <summary>
        /// Convert the lines from datasource to users and adds them to a JsonArray.
        /// </summary>
        /// <param name="dataSource">The stringarray to iterate through.</param>
        /// <param name="limit">Number of times to iterate through.</param>
        /// <returns>A JsonArray with converted user data.</returns>
        private JsonArray ConvertCSVToJSONByLimit(string[] dataSource, int limit)
        {
            JsonArray jsonArray = new JsonArray();

            for(int i = 0; i < limit; i++)
            {
                string[] strings = dataSource[i].Split(";");

                User user = CreateUser(strings);

                jsonArray.Add(user);
            }
            return jsonArray;
        }

        /// <summary>
        /// Create and return a new user by given properties.
        /// </summary>
        /// <param name="properties">Properties for the user.</param>
        /// <returns>A newly created user.</returns>
        private User CreateUser(string[] properties)
        {
            return new User(
                    Convert.ToInt32(properties[0]),    // Id
                    properties[1],                     // Name
                    Convert.ToInt32(properties[2]),    // Age
                    properties[3]);                    // Email
        }
    }
}