﻿using Microsoft.Data.Sqlite;
using Pharm.DAL.entity;
using Pharm.DLL.Interfaces;
using System;
using System.Collections.Generic;

namespace Pharm.DLL.Repositories
{
    public class UserRep : IUserRepository
    {
        private readonly SqliteConnection connection;

        public UserRep(SqliteConnection connection)
        {
            this.connection = connection;
        }

        public void CreateUser(User user)
        {
            using (var command = new SqliteCommand("INSERT INTO Users (Name, Password, BirthDate,Address,Number) VALUES (@Name, @Password, @BirthDate,@Address,@Number)", connection))
            {
                command.Parameters.Add(new SqliteParameter("@Name", user.Name));
                command.Parameters.Add(new SqliteParameter("@Password", user.Password));
                command.Parameters.Add(new SqliteParameter("@BirthDate", user.BirthDate));
                command.Parameters.Add(new SqliteParameter("@Address", user.Address));
                command.Parameters.Add(new SqliteParameter("@Number", user.Number));

                command.ExecuteNonQuery();
            }
        }

        public void UpdateUser(User user)
        {
            using (var command = new SqliteCommand("UPDATE Users SET Name = @Name, Password = @Password, BirthDate = @BirthDate, Address = @Address, Number = @Number WHERE Id = @Id", connection))
            {
                command.Parameters.Add(new SqliteParameter("@Id", user.Id));
                command.Parameters.Add(new SqliteParameter("@Name", user.Name));
                command.Parameters.Add(new SqliteParameter("@Password", user.Password));
                command.Parameters.Add(new SqliteParameter("@BirthDate", user.BirthDate));
                command.Parameters.Add(new SqliteParameter("@Address", user.Address));
                command.Parameters.Add(new SqliteParameter("@Number", user.Number));

                command.ExecuteNonQuery();
            }
        }

        public void DeleteUser(long id)
        {
            using (var command = new SqliteCommand("DELETE FROM Users WHERE Id = @Id", connection))
            {
                command.Parameters.Add(new SqliteParameter("@Id", id));

                command.ExecuteNonQuery();
            }
        }

        public User GetUserById(long id)
        {
            using (var command = new SqliteCommand("SELECT * FROM Users WHERE Id = @Id", connection))
            {
                command.Parameters.Add(new SqliteParameter("@Id", id));

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        var user = new User
                        {
                            Id = (long)reader["Id"],
                            Name = (string)reader["Name"],
                            Password = (string)reader["Password"],
                            BirthDate = (DateTime)reader["BirthDate"],
                            Address = (string)reader["Address"],
                            Number = (string)reader["Number"]
                        };

                        return user;
                    }
                }
            }

            return null;
        }

        public List<User> GetAllUsers()
        {
            var users = new List<User>();

            using (var command = new SqliteCommand("SELECT * FROM Users", connection))
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var user = new User
                        {
                            Id = (long)reader["Id"],
                            Name = (string)reader["Name"],
                            Password = (string)reader["Password"],
                            BirthDate = (DateTime)reader["BirthDate"],
                            Address = (string)reader["Address"],
                            Number = (string)reader["Number"]
                        };

                        users.Add(user);
                    }
                }
            }

            return users;
        }

    }

    
}
