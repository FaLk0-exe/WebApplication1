
using Microsoft.Data.Sqlite;
using Pharm.DAL.entity;
using Pharm.DLL.Interfaces;

namespace Pharm.DLL.Repositories
{
    public class OrderDetailsRep: IOrderDetailsRepository
    { 
        private SqliteConnection connection;

        public OrderDetailsRep(SqliteConnection connection)
        {
            this.connection = connection;
        }

        public void CreateOrderDetails(OrderDetail orderDetail)
        {
            connection.Open();
            using (var command = new SqliteCommand("INSERT INTO OrderDetails (ProductId, Quantity, TotalPrice,ProductPrice, UserOrderId) VALUES (@ProductId, @Quantity, @TotalPrice, @ProductPrice, @UserOrderId)", connection))
            {
                command.Parameters.Add(new SqliteParameter("@ProductId", orderDetail.ProductId));
                command.Parameters.Add(new SqliteParameter("@Quantity", orderDetail.Quantity));
                command.Parameters.Add(new SqliteParameter("@TotalPrice", orderDetail.TotalPrice));
                command.Parameters.Add(new SqliteParameter("@ProductPrice", orderDetail.ProductPrice));
                command.Parameters.Add(new SqliteParameter("@UserOrderId", orderDetail.UserOrderId));

                command.ExecuteNonQuery();
            }
            connection.Close();
        }

        public void UpdateOrderDetails(OrderDetail orderDetail)
        {
            connection.Open();
            using (var command = new SqliteCommand("UPDATE OrderDetails set ProductId = @ProductId, Quantity = @Quantity,TotalPrice = @TotalPrice,ProductPrice = @ProductPrice WHERE Id = @Id", connection))
            {
                command.Parameters.Add(new SqliteParameter("@Id", orderDetail.Id));
                command.Parameters.Add(new SqliteParameter("@ProductId", orderDetail.ProductId));
                command.Parameters.Add(new SqliteParameter("@Quantity", orderDetail.Quantity));
                command.Parameters.Add(new SqliteParameter("@TotalPrice", orderDetail.TotalPrice));
                command.Parameters.Add(new SqliteParameter("@ProductPrice", orderDetail.ProductPrice));



                command.ExecuteNonQuery();
            }
            connection.Close();
        }

        public void DeleteOrderDetails(long id)
        {
            connection.Open();
            using (var command = new SqliteCommand("DELETE FROM OrderDetails WHERE Id = @Id", connection))
            {
                command.Parameters.Add(new SqliteParameter("@Id", id));

                command.ExecuteNonQuery();
            }
            connection.Close();
        }

        public OrderDetail GetOrderDetails(long id)
        {
            connection.Open();
            using (var command = new SqliteCommand(
                       "SELECT Id, ProductId, Quantity, TotalPrice, ProductPrice,UserOrderId " +
                       "FROM OrderDetails" +
                       "WHERE Id = @Id", connection))
            {
                command.Parameters.Add(new SqliteParameter("@Id", id));
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        var orderDetail = new OrderDetail
                        {
                            Id = (long)reader["Id"],
                            ProductId = (long)reader["ProductId"],
                            Quantity = (long)reader["Quantity"],
                            TotalPrice = (double)reader["TotalPrice"],
                            ProductPrice = (double)reader["ProductPrice"]
                            
                        };
                        connection.Close();
                        return orderDetail;
                    }
                }
            }
            connection.Close();
            return null;

        }

        public List<OrderDetail> GetAllOrderDetails()
        {
            connection.Open();
            var orderDetails = new List<OrderDetail>();
            using (var command = new SqliteCommand(
                       "SELECT Id, ProductId, Quantity, TotalPrice, ProductPrice,UserOrderId " +
                       "FROM OrderDetails", connection))
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var orderDetail = new OrderDetail
                        {
                            Id = (long)reader["Id"],
                            ProductId = (long)reader["ProductId"],
                            Quantity = (long)reader["Quantity"],
                            TotalPrice = (double)reader["TotalPrice"],
                            ProductPrice = (double)reader["ProductPrice"],
                            UserOrderId = (long)reader["UserOrderId"]
                        };
                        orderDetails.Add(orderDetail);
                    }
                }
            }
            connection.Close();
            return orderDetails;
        }

    }
}
