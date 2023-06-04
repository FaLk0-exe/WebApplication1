using System;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;

namespace Pharm.DLL.Repositories
{
    public class StatusRep:IStatusRepository
    {
        private readonly SqliteConnection connection;

        public StatusRep(SqliteConnection connection)
        {
            this.connection = connection;
        }

        public void CreateStatus(OrderStatus orderStatus)
        {
            using (var command = new SqliteCommand("INSERT INTO OrderStatus (Name) VALUES (@Name)", connection))
            {
                command.Parameters.Add(new SqliteParameter("@PName", orderStatus.Name));

                command.ExecuteNonQuery();
            }

        }

        public void UpdateStatus(OrderStatus orderStatus)
        {
            using (var command = new SqliteCommand("UPDATE OrderStatus set Name = @Name WHERE Id = @Id", connection))
            {
                command.Parameters.Add(new SqliteParameter("@Id", orderStatus.Id));
                command.Parameters.Add(new SqliteParameter("@PName", orderStatus.Name));
                

                command.ExecuteNonQuery();
            }
        }

        public void DeleteStatus(long id)
        {
            using (var command = new SqliteCommand("DELETE FROM OrderStatus WHERE Id = @Id", connection))
            {
                command.Parameters.Add(new SqliteParameter("@Id", id));

                command.ExecuteNonQuery();
            }
        }

        public OrderStatus GetStatus(long id)
        {
            using (var command = new SqliteCommand("SELECT * FROM OrderStatus WHERE Id = @Id", connection))
            {
                command.Parameters.Add(new SqliteParameter("@Id", id));

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        var orderStatus = new OrderStatus
                        {
                            Id = (int)(long)reader["Id"],
                            Name = (string)reader["Name"]
                        };

                        return orderStatus;
                    }
                }
            }
            return null;
        }

        
        
    public class OrderStatus
        {
            public long Id { get; set; }
            public string Name { get; set; } = null!;
          
        }

    }
}
