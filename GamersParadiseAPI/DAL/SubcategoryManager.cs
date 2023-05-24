namespace GamersParadiseAPI.DAL;
public class SubCategoryManager
{
    private readonly ForumDbContext _context;
    public SubCategoryManager(ForumDbContext context)
    {
        _context = context;
    }

    public async Task<List<SubCategory>> GetSubCategories()
    {
        List<SubCategory> subCategories = await _context.SubCategories.ToListAsync();
        return subCategories;
    }

    public async Task<SubCategory> GetOneSubCategory(int id)
    {
        var subCategories = await GetSubCategories();
        var subCategory = subCategories.FirstOrDefault(x => x.Id == id);
        return subCategory;
    }

    public async Task AddSubCategory(SubCategory subCategory)
    {
        await _context.SubCategories.AddAsync(subCategory);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateSubCategory(SubCategory subCategory, int id)
    {
        var subCategoryToUpdate = _context.SubCategories.FirstOrDefault(c => c.Id == id);

        if (subCategoryToUpdate != null)
        {
            subCategoryToUpdate.Name = subCategory.Name;
        }
        await _context.SaveChangesAsync();
    }

    public async Task DeleteSubCategory(int id)
    {
        var deleteSubCategory = _context.SubCategories.FirstOrDefault(x => x.Id == id);

        if (deleteSubCategory != null)
        {
            _context.SubCategories.Remove(deleteSubCategory);
            await _context.SaveChangesAsync();
        }
    }

}
