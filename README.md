# OrleansApp

Приложение написано в рамках самостоятельного изучения Microsoft Orleans по урокам https://www.youtube.com/watch?v=D2aD4ftLs14&list=PLdvI3YlPDGgcRoetJI64aDM2sNNYxNF_j&index=1

В отличие от автора туториала мною была использована не Dynamic DB от Амазона, а MySql. Полезные ресурсы:

1) https://dotnet.github.io/orleans/docs/grains/grain_persistence/relational_storage.html (стоит внимательно пошагово всё сделать: обязательно запустить скрипты sql в созданной вами базе данных для проекта (через CREATE DATABASE <имя базы данных>;), прописать Invariant "MySql.Data.MySqlClient" по примеру и connection string (пример для MySql: "Server=localhost;user=root; Database=Orleans").
2) https://bartwullems.blogspot.com/2019/05/microsoft-orleans-grain-persistence.html - в частности, из этого источника узнала, как необходимо регистрировать storage - прописывать атрибут [StorageProvider(ProviderName = "OrleansStorage")] перед грэйном, иначе возникала ошибка "BadGrainStorageConfigException".
