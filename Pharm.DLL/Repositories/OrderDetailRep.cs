
using Microsoft.Data.Sqlite;
using Pharm.DLL.Interfaces;

namespace Pharm.DLL.Repositories
{
    public class OrderDetailsRep: IOrderDetailsRepository
    { 
        private readonly SqliteConnection connection;

        public OrderDetailsRep(SqliteConnection connection)
        {
            this.connection = connection;
        }

        public void CreateOrderDetails(OrderDetail orderDetail)
        {
            using (var command = new SqliteCommand("INSERT INTO OrderDetails (ProductId, Quantity, TotalPrice, ProductPrice) VALUES (@ProductId, @Quantity, @TotalPrice, @ProductPrice)", connection))
            {
                command.Parameters.Add(new SqliteParameter("@ProductId", orderDetail.ProductId));
                command.Parameters.Add(new SqliteParameter("@Quantity", orderDetail.Quantity));
                command.Parameters.Add(new SqliteParameter("@TotalPrice", orderDetail.TotalPrice));
                command.Parameters.Add(new SqliteParameter("@ProductPrice", orderDetail.ProductPrice));

                command.ExecuteNonQuery();
            }
        }

        public void UpdateOrderDetails(OrderDetail orderDetail)
        {
            using (var command = new SqliteCommand("UPDATE OrderDetails set ProductId = @ProductId, Quantity = @Quantity,TotalPrice = @TotalPrice,ProductPrice = @ProductPrice WHERE Id = @Id", connection))
            {
                command.Parameters.Add(new SqliteParameter("@Id", orderDetail.Id));
                command.Parameters.Add(new SqliteParameter("@ProductId", orderDetail.ProductId));
                command.Parameters.Add(new SqliteParameter("@Quantity", orderDetail.Quantity));
                command.Parameters.Add(new SqliteParameter("@TotalPrice", orderDetail.TotalPrice));
                command.Parameters.Add(new SqliteParameter("@ProductPrice", orderDetail.ProductPrice));

                command.ExecuteNonQuery();
            }
        }

        public void DeleteOrderDetails(long id)
        {
            using (var command = new SqliteCommand("DELETE FROM OrderDetails WHERE Id = @Id", connection))
            {
                command.Parameters.Add(new SqliteParameter("@Id", id));

                command.ExecuteNonQuery();
            }
        }

        public OrderDetail GetOrderDetails(long id)
        {

            using (var command = new SqliteCommand(
                       "SELECT od.Id, od.ProductId, od.Quantity, od.TotalPrice, od.ProductPrice " +
                       "FROM OrderDetails od " +
                       "INNER JOIN Products p ON od.ProductId = p.Id AND od.ProductPrice = p.Price" +
                       "WHERE od.Id = @Id", connection))
            {
                command.Parameters.Add(new SqliteParameter("@Id",id));
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

                        return orderDetail;
                    }
                }
            }
            return null;

        }

        public List<OrderDetail> GetAllOrderDetails()
        {
            var orderDetails = new List<OrderDetail>();
            using (var command = new SqliteCommand(
                       "SELECT od.Id, od.ProductId, od.Quantity, od.TotalPrice, od.ProductPrice " +
                       "FROM OrderDetails od " +
                       "INNER JOIN Products p ON od.ProductId = p.Id AND od.ProductPrice = p.Price", connection))
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
                            ProductPrice = (double)reader["ProductPrice"]
                        };
                        orderDetails.Add(orderDetail);
                    }
                }
            }
            return orderDetails;
        }

        public class OrderDetail
        {
            public long Id { get; set; }

            public long ProductId { get; set; }

            public long Quantity { get; set; }

            public double TotalPrice { get; set; }

            public double ProductPrice { get; set; }
        }

    }
}
