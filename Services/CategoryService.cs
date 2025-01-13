using marpha.Data;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace marpha.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly string categories_file_path = Path.Combine(AppContext.BaseDirectory, "Categories.json");
        public async Task<bool> AddCategoryAsync(Category category)
        {
            try
            {
                var categories = await GetAllCategoriesAsync();
                if (categories.Any(c => c.CategoryId == category.CategoryId))
                {
                    return false;
                }

                categories.Add(category);
                await SaveCategoryAsync(categories);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"CATEGORY ADDING ERROR: {ex.Message}");
                return false;
            }
        }

        public async Task<List<Category>> GetAllCategoriesAsync()
        {
            var categories = new List<Category>();

            if (!File.Exists(categories_file_path))
            {
                return categories;
            }

            var json = await File.ReadAllTextAsync(categories_file_path);
            return string.IsNullOrEmpty(json) ? categories : JsonSerializer.Deserialize<List<Category>>(json) ?? categories;
        }

        public async Task SaveCategoryAsync(List<Category> category)
        {
            var json = JsonSerializer.Serialize(category);
            await File.WriteAllTextAsync(categories_file_path, json);
        }
    }
}
