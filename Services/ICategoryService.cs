using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using marpha.Data;

namespace marpha.Services
{
    internal interface ICategoryService
    {
        Task<bool> AddCategoryAsync(Category category);
        Task SaveCategoryAsync(List<Category> category);
        Task<List<Category>> GetAllCategoriesAsync();
    }
}
