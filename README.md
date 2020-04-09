# Project Title

BlogPost WebAPI

## Getting Started

These instructions will get you a copy of the project up and running on your local machine.

### Prerequisites

I was using MS SQL 2016 (EXPRESS) and in folder dbBackup there is SQL script and .bak file from same database.
You can use any of them.

For runing script You wil first have to create local database (DB name [BlogPost]) and than run that script.

When project is on your local machine you will need to change connection string to point on your database.

In DataAccessLayer there is class ConnectionString where you must change propertie ConStr.

```csharp
    namespace DataAccessLayer
{
    public static class ConnectionString
    {
        public static string ConStr { get { return "Data Source=YOUR-SERVER;Initial Catalog=BlogPost;User Id=YOUR-user;Password=YOUR-password;"; } }
    }
}
```
Run app and test it from postman