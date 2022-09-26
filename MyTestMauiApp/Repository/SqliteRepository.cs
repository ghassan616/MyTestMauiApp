using MyTestMauiApp.Model;
using SQLite;
using System;

namespace MyTestMauiApp.Repository
{
    public static class SqliteRepository<T> where T : new()
    {
        private static SQLiteAsyncConnection db;

        static async Task Init()
        {
            if (db != null)
                return;

            var dbPath = Path.Combine(FileSystem.AppDataDirectory, "CatData.db");
            db = new SQLiteAsyncConnection(dbPath);

            await db.CreateTableAsync<Cat>();
        }

        public static async Task AddData(T item)
        {
            await Init();
            await db.InsertAsync(item);
        }

        public static async Task RemoveData(int id)
        {
            await Init();
            await db.DeleteAsync<T>(id);
        }

        public static async Task<IEnumerable<T>> GetData()
        {
            await Init();

            return await db.Table<T>().ToListAsync();
        }
    }
}