using Common.Runtime;
using Entities.Production;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwBll.Interfaces.Production
{
    public interface ICategoryBll
    {
        Task<List<ProductCategory>> GetAll();
        Task<int> Create(string categoryName);
        Task<ProductCategory> GetById(int categoryId);
        Task<ExecutionResult> Save(string categoryName);
    }
}
