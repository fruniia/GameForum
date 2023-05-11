using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GamersParadiseAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MainCategoryController : ControllerBase
    {
        private static List<MainCategory> _mainCategories;

        




        [HttpGet]
        public async Task<List<MainCategory>> GetMainCategories()
        {
            if (_mainCategories is null)
            {
                //TODO: Ta bort!
                _mainCategories = new List<MainCategory>
                {
                    new MainCategory { Id = 1, Name = "Playstation", SubCategories = null },
                    new MainCategory { Id = 2, Name = "Xbox", SubCategories = null }
                };
            }
            return _mainCategories;
        }

        [HttpGet("{id}")]
        public async Task<MainCategory> GetOneMainCategory(int id)
        {
            if (_mainCategories is null)
            {
                _mainCategories = await GetMainCategories();
            }
            var category = _mainCategories.Where(x => x.Id == id).FirstOrDefault();

            return category;
        }

        [HttpPost]
        public async Task CreateMainCategory([FromBody] MainCategory subCategory)
        {
            if (_mainCategories is null)
            {
                _mainCategories = await GetMainCategories();
            }
            subCategory.Id = _mainCategories.TakeLast(1).Select(x => x.Id).FirstOrDefault() + 1;
            subCategory.SubCategories = null;
            _mainCategories.Add(subCategory);
        }

        [HttpPut("{id}")]
        public async Task UpdateSubCategory([FromBody] MainCategory subCategory, int id)
        {
            if (_mainCategories is null)
            {
                _mainCategories = await GetMainCategories();
            }

            var category = _mainCategories.Where(x => x.Id == id).FirstOrDefault();
            if (category is not null)
            {
                category.Name = subCategory.Name;
            }

        }

        [HttpDelete("{id}")]
        public async Task DeleteSubCategory(int id)
        {
            if (_mainCategories is null)
            {
                _mainCategories = await GetMainCategories();
            }

            await GetMainCategories();
            if (id <= _mainCategories.Count)
            {
                var deleteCategory = _mainCategories.Where(x => x.Id == id).FirstOrDefault();
                _mainCategories.Remove(deleteCategory);
            }
        }


    }
}
