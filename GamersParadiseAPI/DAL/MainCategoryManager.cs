namespace GamersParadiseAPI.DAL
{
    public static class MainCategoryManager
    {
        public static List<MainCategory> MainCategory { get; set; }

        public static async Task<List<MainCategory>> GetMainCategories()
        {
            var mainCategories = new List<MainCategory>();

            if (MainCategory is null)
            {
                MainCategory = new List<MainCategory>();
                //mainCategories.Add(new MainCategory { Id = 1, Name = "Playstation" });
                //mainCategories.Add(new MainCategory { Id = 2, Name = "XBOX" });
            }

            MainCategory.AddRange(mainCategories);

            return MainCategory;
        }
    }
}
