# CSVToJsonConverter

# Dependencies
This application uses .NET 10 and SwaggerUI

# How to build the application
Can be built from either terminal or VisualStudio.
From the terminal, navigate to the folder CSVToJsonConverterAPI and run dotnet build.

From VisualStudio open solutionfile and hit the playbutton, this will build and launch the application. The SwaggerUI will open in browser to easaly test the endpoint.

# How to run the API
Can be launched from either terminal or VisualStudio.
From the terminal, navigate to the folder CSVToJsonConverterAPI and run dotnet run. This will launch the server and allow to test the endpoint.
Then enter http://localhost:5041/swagger in the browser to test the endpoint.

From VisualStudio open solutionfile and hit the playbutton, this will build and launch the application. The SwaggerUI will open in browser to easaly test the endpoint.

# How to use the endpoint with example.
This endpoint returns a JSONarray with all avalible userobjects.
http://localhost:5041/api/users/

This endpoint returns a JSONarray with 10 user objects.
http://localhost:5041/api/users?limit=10

Example file to test the API is found in CSVToJsonConverterAPI.http.

# Example on how the CSV-format is structured.
1;Alice;8;alice@example.com  
2;Bea;12;bea@example.com  
3;Cesar;56;cesar@example.com  
4;David;3;david@example.com  
5;Erik;67;erik@example.com  
6;Fredrik;27;fredrik@example.com  
7;Gustav;32;gustav@example.com  
8;Henrik;43;henrik@example.com  
9;Ivar;55;ivar@example.com  
10;Johan;68;johan@example.com  
11;Karl;72;karl@example.com  
12;Lennart;89;lennart@example.com  
13;Martin;26;martin@example.com  
14;Niklas;17;niklas@example.com  
15;Olov;40;olov@example.com  
