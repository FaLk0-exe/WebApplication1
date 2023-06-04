﻿using System;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;
using Pharm.DLL.Interfaces;


namespace Pharm.DLL.Repositories
{
    public class UserOrderRep: IUserOrderRepository
    {
        private readonly SqliteConnection connection;

        public UserOrderRep(SqliteConnection connection)
        {
            this.connection = connection;
        }

        public void CreateUserOrder(UserOrder userOrder)
        {
            using (var command = new SqliteCommand("INSERT INTO UserOrders (UserId, OrderDate, Price, StatusId) VALUES (@UserId, @OrderDate, @Price, @StatusId)", connection))
            {
                command.Parameters.Add(new SqliteParameter("@UserId", userOrder.UserId));
                command.Parameters.Add(new SqliteParameter("@OrderDate", userOrder.OrderDate));
                command.Parameters.Add(new SqliteParameter("@Price", userOrder.Price));
                command.Parameters.Add(new SqliteParameter("@StatusId", userOrder.StatusId));

                command.ExecuteNonQuery();
            }
        }

        public void UpdateUserOrder(UserOrder userOrder)
        {
            using (var command = new SqliteCommand("UPDATE UserOrders SET UserId = @UserId, OrderDate = @OrderDate, Price = @Price, StatusId = @StatusId WHERE Id = @Id", connection))
            {
                command.Parameters.Add(new SqliteParameter("@Id", userOrder.Id));
                command.Parameters.Add(new SqliteParameter("@UserId", userOrder.UserId));
                command.Parameters.Add(new SqliteParameter("@OrderDate", userOrder.OrderDate));
                command.Parameters.Add(new SqliteParameter("@Price", userOrder.Price));
                command.Parameters.Add(new SqliteParameter("@StatusId", userOrder.StatusId));

                command.ExecuteNonQuery();
            }
        }

        public void DeleteUserOrder(long id)
        {
            using (var command = new SqliteCommand("DELETE FROM UserOrders WHERE Id = @Id", connection))
            {
                command.Parameters.Add(new SqliteParameter("@Id", id));

                command.ExecuteNonQuery();
            }
        }

        public UserOrder GetUserOrder(long id)
        {
            using (var command = new SqliteCommand(
                "SELECT uo.Id, uo.UserId, uo.StatusId, uo.Price, uo.OrderDate " +
                "FROM UserOrders uo " +
                "INNER JOIN Users u ON uo.UserId = u.Id " +
                "INNER JOIN OrderStatus os ON uo.StatusId = os.Id " +
                "WHERE uo.Id = @Id", connection))
            {
                command.Parameters.Add(new SqliteParameter("@Id", id));
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        var userOrder = new UserOrder
                        {
                            Id = (long)reader["Id"],
                            UserId = (long)reader["UserId"],
                            StatusId = (long)reader["StatusId"],
                            Price = (double)reader["Price"],
                            OrderDate = (DateTime)reader["OrderDate"]
                        };

                        return userOrder;
                    }
                }
            }
            return null;
        }

        public List<UserOrder> GetAllUserOrders()
        {
            var userOrders = new List<UserOrder>();
            using (var command = new SqliteCommand(
                "SELECT uo.Id, uo.UserId, uo.StatusId, uo.Price, uo.OrderDate " +
                "FROM UserOrders uo " +
                "INNER JOIN Users u ON uo.UserId = u.Id " +
                "INNER JOIN OrderStatus os ON uo.StatusId = os.Id", connection))
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var userOrder = new UserOrder
                        {
                            Id = (long)reader["Id"],
                            UserId = (long)reader["UserId"],
                            StatusId = (long)reader["StatusId"],
                            Price = (double)reader["Price"],
                            OrderDate = (DateTime)reader["OrderDate"]
                        };
                        userOrders.Add(userOrder);
                    }
                }
            }
            return userOrders;
        }

        public partial class UserOrder
        {
            public long Id { get; set; }

            public long UserId { get; set; }

            public double Price { get; set; }

            public DateTime OrderDate { get; set; }

            public long StatusId { get; set; }

        }
    }
}