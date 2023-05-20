using AwBll.Interfaces.Production;
using AwDal.Production;
using Common.Runtime;
using Entities.Production;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwBll.Implementations.Production
{
    public class CategoryBll : ICategoryBll
    {
        private readonly IConfiguration _configuration;
        private readonly ProductCategoryDal dbCategory;
        public CategoryBll(IConfiguration configuration)
        {
            _configuration = configuration;
            string connectionString = _configuration.GetConnectionString(name: "AwConnectionString");
            dbCategory = new ProductCategoryDal(connectionString);
        }

        public Task<int> Create(string categoryName)
        {
            return dbCategory.Create(categoryName);
        }

        public async Task<List<ProductCategory>> GetAll()
        {
           return dbCategory.GetAll();
        }

        public async Task<ProductCategory> GetById(int categoryId)
        {
            return await dbCategory.GetById(categoryId); 
        }

        public Task<ExecutionResult> Save(string categoryName)
        {
            return dbCategory.Save(categoryName);
        }
    }
}
