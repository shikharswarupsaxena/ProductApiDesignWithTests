Created the Web api project

using the nuget package Microsoft.EntityFrameworkCore.SqlServer
using the nuget package Microsoft.EntityFrameworkCore.Tools


Database name is ProductDb

 "ConnectionStrings": {
   "DefaultConnection": "Server=IE4LLTFHJHXD3\\SQLEXPRESS; Database=ProductDb;Trusted_connection=true;TrustServerCertificate=true;"
 }


 
You need to change the connection string according to your need 
 
 command to run in Package manager console
 
 add-migration "initial migration"
 
 update-database
 
 
 
 using xunit for testing
 and fluent assertion nuget package
 Microsoft.EntityFrameworkCore.InMemory for inmemomry database
 
 
 
 
 
 Extract the Assignment.zip 
 Open the folder Assignment 
 Open the folder Carl_Zeiss_Assignment
 
open the file Carl_Zeiss_Assignment.sln
