using AwDal.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Production;
using System.Data.SqlClient;
using System.Data;
using Common.Runtime;

namespace AwDal.Production
{
    public class ProductCategoryDal : AwBaseDal
    {
        public ProductCategoryDal(string connectionString) : base(connectionString)
        {
        }
        public List<ProductCategory> GetAll()
        {
            SqlConnection conn = GetConnection();
            conn.Open();
            SqlCommand command = new()
            {
                Connection = conn,
                CommandText = "Production.uspGetCategories",
                CommandType = CommandType.StoredProcedure
            };

            DataTable dt = new();
            SqlDataAdapter adapter = new(command);
            adapter.Fill(dt);

            var query = dt.AsEnumerable().Select(x => new ProductCategory
            {
                ProductCategoryID = Convert.ToInt32(x["ProductCategoryID"]),
                Name = Convert.ToString(x["Name"]),
                rowguid = new Guid(Convert.ToString(x["rowguid"])),
                ModifiedDate = Convert.ToDateTime(x["ModifiedDate"])
            });

            return query.ToList();
        }
        public async Task<ProductCategory> GetById(int categoryId)
        {
            SqlConnection conn = GetConnection();
            conn.Open();
            SqlCommand command = new()
            {
                Connection = conn,
                CommandText = "Production.uspGetCategories",
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("@ProductCategoryID", categoryId);

            SqlDataReader reader = await command.ExecuteReaderAsync();
            ProductCategory category = new();
            if (reader.Read())
            {
                category.ProductCategoryID = reader.GetInt32("ProductCategoryID");
                category.Name = reader.GetString("Name");
                category.rowguid = reader.GetGuid("rowguid");
                category.ModifiedDate = reader.GetDateTime("ModifiedDate");
            }
            return category;
        }
        public async Task<int> Create(string categoryName)
        {
            SqlConnection conn = GetConnection();
            conn.Open();
            SqlParameter parameter = new()
            {
                ParameterName = "@Name",
                Value = categoryName
            };
            SqlCommand command = new()
            {
                Connection = conn,
                CommandText = "Production.uspCreateCategory",
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.Add(parameter);
            return await command.ExecuteNonQueryAsync();
        }

        public async Task<ExecutionResult> Save(string categoryName)
        {
            ExecutionResult result = new ();
            try
            {
                SqlConnection conn = GetConnection();
                conn.Open();
                SqlParameter parameter = new()
                {
                    ParameterName = "@Name",
                    Value = categoryName
                };
                SqlCommand command = new()
                {
                    Connection = conn,
                    CommandText = "Production.uspSaveCategory",
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.Add(parameter);
                SqlDataReader reader = await command.ExecuteReaderAsync();
                if (reader.Read())
                {
                    result.Outcome = reader.GetBoolean("Outcome");
                    result.Id = reader.GetInt32("Id");
                    result.Message = reader.GetString("Message");
                }
                else
                {
                    result = new ExecutionResult { Outcome = false, Message = "No se obtuvo respuesta desde la base de datos." };
                }
            }
            catch (Exception ex)
            {

                result = new ExecutionResult { Outcome = false, Message = ex.Message };
            }
            return result;
        }
    }
}
