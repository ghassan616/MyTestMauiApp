using MyTestMauiApp.Model;
using MyTestMauiApp.Repository;

namespace MyTestMauiApp.Services
{
    public class CatService
    {
        public IEnumerable<Cat> catList;

        public async Task<IEnumerable<Cat>> GetCats()
        {
            if (catList.Count() > 0)
            {
                return catList;
            }

            catList = await SqliteRepository<Cat>.GetData();

            return catList;
        }

        public async void AddCat(Cat cat)
        {
            if (cat != null)
            {
                await SqliteRepository<Cat>.AddData(cat);
            }
        }

        public async void DeleteCat(Cat cat)
        {
            await SqliteRepository<Cat>.RemoveData(cat.Id);
        }
    }
}