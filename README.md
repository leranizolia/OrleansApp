# OrleansApp

The application was written as part of an independent study of Microsoft Orleans using the lessons https://www.youtube.com/watch?v=D2aD4ftLs14&list=PLdvI3YlPDGgcRoetJI64aDM2sNNYxNF_j&index=1

Unlike the author of the tutorial, I was not a dynamic database from Amazon, but MySql. Useful resources:

https://dotnet.github.io/orleans/docs/grains/grain_persistence/relational_storage.html (you should carefully do everything step by step: be sure to run sql scripts in the database you created for the project (via CREATE DATABASE <database name>;) , register the invariant "MySql.Data.MySqlClient" according to the example and the connection string (example for MySql: "Server = localhost; user = root; Database = Orleans").
https://bartwullems.blogspot.com/2019/05/microsoft-orleans-grain-persistence.html - in particular, from this source I learned how to register the storage - register the [StorageProvider (ProviderName = "OrleansStorage")] attribute before grain, otherwise the "BadGrainStorageConfigException" error occurred.
