using System;
using Microsoft.Data.Sqlite;
        
namespace Create
{
    class Create
    {
        static void Main(string[] args)
        {
            using (var connection = new SqliteConnection("Data Source=user.db"))
            {
                connection.Open();

                SqliteCommand command = new SqliteCommand();
                command.Connection = connection;

                command.CommandText = "CREATE TABLE IF NOT EXISTS OrderStatus (" +
                                      " Id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE," +
                                      " Name TEXT NOT NULL)";

                command.ExecuteNonQuery();

                command.CommandText = "CREATE TABLE IF NOT EXISTS Users(" +
                    " Id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE," +
                    " Name TEXT NOT NULL," +
                    " Password INTEGER NOT NULL," +
                    " BirthDate DATETIME NOT NULL);";

                command.ExecuteNonQuery();

                command.CommandText = "CREATE TABLE IF NOT EXISTS Products (" +
                    " Id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE," +
                    " PName TEXT NOT NULL," +
                    " Price REAL NOT NULL," +
                    " Description TEXT NOT NULL," +
                    " Quantity INTEGER NOT NULL);";

                command.ExecuteNonQuery();

                command.CommandText = "CREATE TABLE IF NOT EXISTS UserOrders (" +
                   "Id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE," +
                   " UserId INTEGER NOT NULL," +
                   " Price REAL NOT NULL," +
                   " OrderDate DATETIME NOT NULL," +
                   " StatusId INTEGER NOT NULL," +
                   " FOREIGN KEY(StatusId) REFERENCES OrderStatus(Id)," +
                   " FOREIGN KEY(Price) REFERENCES OrderDetails(TotalPrice)," +
                   " FOREIGN KEY(UserId) REFERENCES Users(Id));";

                command.ExecuteNonQuery();

                command.CommandText = "CREATE TABLE IF NOT EXISTS OrderDetails(" +
                    " Id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE," +
                    " ProductId INTEGER NOT NULL," +
                    " Quantity INTEGER NOT NULL," +
                    " ProductPrice REAL NOT NULL," +
                    " TotalPrice REAL NOT NULL," +
                    " FOREIGN KEY(ProductId) REFERENCES Products(Id)," +
                    "FOREIGN KEY(ProductPrice) REFERENCES Products(Price));";

                command.ExecuteNonQuery();

                
            }
            Console.Read(); 
        }
    }
}