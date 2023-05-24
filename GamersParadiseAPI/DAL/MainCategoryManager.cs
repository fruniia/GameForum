using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace GamersParadiseAPI.DAL
{
    public class MainCategoryManager
    {
        private readonly ForumDbContext _context;
        public MainCategoryManager(ForumDbContext context)
        {
            _context = context;
        }

        public async Task<List<MainCategory>> GetMainCategories()
        {
            List<MainCategory> mainCategories = await _context.MainCategories.ToListAsync();

            return mainCategories;
        }

        public async Task AddMainCategory(MainCategory mainCategory)
        {
            await _context.MainCategories.AddAsync(mainCategory);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateMainCategory(MainCategory mainCategory, int id)
        {
            var mainCategoryToUpdate = _context.MainCategories.FirstOrDefault(c => c.Id == id);

            if (mainCategoryToUpdate != null)
            {
                mainCategoryToUpdate.Name = mainCategory.Name;
            }
            await _context.SaveChangesAsync();
        }

        public async Task DeleteMainCategory(int id)
        {
            var deleteMainCategory = _context.MainCategories.FirstOrDefault(x => x.Id == id);

            if (deleteMainCategory != null)
            {
                _context.MainCategories.Remove(deleteMainCategory);
                await _context.SaveChangesAsync();
            }
        }
    }
}
