using Dapper;
using Microsoft.Data.SqlClient;
using Domain.Models;

namespace DataAccess.Repositories
{
    public class ProductRepository
    {
        private readonly string _connectionString;

        public ProductRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        // Fetch all products
        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            using var connection = new SqlConnection(_connectionString);
            const string query = "SELECT * FROM Products";
            return await connection.QueryAsync<Product>(query);
        }

        // Get a product by Id
        public async Task<Product> GetProductByIdAsync(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            const string query = "SELECT * FROM Products WHERE Id = @Id";
            return await connection.QueryFirstOrDefaultAsync<Product>(query, new { Id = id });
        }

        // Add a new product
        public async Task<int> AddProductAsync(Product product)
        {
            using var connection = new SqlConnection(_connectionString);
            const string query = "INSERT INTO Products (Name, Price) VALUES (@Name, @Price); SELECT CAST(SCOPE_IDENTITY() as int)";
            return await connection.QuerySingleAsync<int>(query, product);
        }

        // Update a product
        public async Task<int> UpdateProductAsync(Product product)
        {
            using var connection = new SqlConnection(_connectionString);
            const string query = "UPDATE Products SET Name = @Name, Price = @Price WHERE Id = @Id";
            return await connection.ExecuteAsync(query, product);
        }

        // Delete a product
        public async Task<int> DeleteProductAsync(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            const string query = "DELETE FROM Products WHERE Id = @Id";
            return await connection.ExecuteAsync(query, new { Id = id });
        }
    }
}
