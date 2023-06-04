using Microsoft.Data.Sqlite;
using Pharm.DLL.Interfaces;
using Pharm.DAL.entity;
using System.Collections.Generic;


namespace Pharm.DLL.Repositories
{
    public class ProductRep:IProductRepository
    {
        private readonly SqliteConnection connection;

        public ProductRep(SqliteConnection connection)
        {
            this.connection = connection;
        }


        public void CreateProduct(Product product)
        {
            connection.Open();
            using (var command = new SqliteCommand("INSERT INTO Product (PName, Price, Quantity,Description) VALUES (@PName, @Price, @Quantity,@Description,@IsActive)", connection))
            {
                command.Parameters.Add(new SqliteParameter("@PName", product.Pname));
                command.Parameters.Add(new SqliteParameter("@Price", product.Price));
                command.Parameters.Add(new SqliteParameter("@Quantity", product.Quantity));
                command.Parameters.Add(new SqliteParameter("@Description",product.Description));
                command.Parameters.Add(new SqliteParameter("@IsActive", true));
                command.ExecuteNonQuery();
            }
            connection.Close();
        }

        public void UpdateProduct(Product product)
        {
            using (var command = new SqliteCommand("UPDATE Product set IsActive = @IsActive, PName = @PName, Price = @Price, Quantity = @Quantity,Description=@Description WHERE Id = @Id", connection))
            {
                command.Parameters.Add(new SqliteParameter("@Id", product.Id));
                command.Parameters.Add(new SqliteParameter("@IsActive", product.IsActive));
                command.Parameters.Add(new SqliteParameter("@PName", product.Pname));
                command.Parameters.Add(new SqliteParameter("@Price", product.Price));
                command.Parameters.Add(new SqliteParameter("@Quantity", product.Quantity));
                command.Parameters.Add(new SqliteParameter("@Description", product.Description));

                command.ExecuteNonQuery();
            }
        }

        public void DeleteProduct(long id)
        {
            using (var command = new SqliteCommand("DELETE FROM Product WHERE Id = @Id", connection))
            {
                command.Parameters.Add(new SqliteParameter("@Id", id));

                command.ExecuteNonQuery();
            }
        }

        public Product GetProduct(long id)
        {
            connection.Open();
            using (var command = new SqliteCommand("SELECT * FROM Product WHERE Id = @Id", connection))
            {
                command.Parameters.Add(new SqliteParameter("@Id", id));

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        var product = new Product
                        {
                            Id = (long)reader["Id"],
                            Pname = (string)reader["PName"],
                            Price = (double)reader["Price"],
                            Quantity = (long)reader["Quantity"],
                            Description = (string)reader["Description"],
                            IsActive = (bool)reader["IsActive"]
                        };
                        
                        return product;
                    }
                }
            }
            connection.Close();
            return null;
        }

        public List<Product> GetAllProducts()
        {
            connection.Open();
            var products = new List<Product>();

            using (var command = new SqliteCommand("SELECT * FROM Product", connection))
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var product = new Product
                        {
                            Id = (long)reader["Id"],
                            Pname = (string)reader["PName"],
                            Price = (double)reader["Price"],
                            Quantity = (long)reader["Quantity"],
                            Description = (string)reader["Description"],
                            IsActive = (bool)reader["IsActive"]
                        };

                        products.Add(product);
                    }
                }
            }
            connection.Close();

            return products;
           
        }

        public List<Product> GetList()
        {
            connection.Open();
            var products = new List<Product>();

            using (var command = new SqliteCommand("SELECT * FROM Product", connection))
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var product = new Product
                        {
                            Pname = (string)reader["PName"],
                            Price = (double)reader["Price"],
                            Quantity = (long)reader["Quantity"],
                            Description = (string)reader["Description"],
                            IsActive = (bool)reader["IsActive"]
                        };

                        products.Add(product);
                    }
                }
            }
            connection.Close();

            return products;

        }


    }
}
