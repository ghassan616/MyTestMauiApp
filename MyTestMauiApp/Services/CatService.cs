using MyTestMauiApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace MyTestMauiApp.Services
{
    public class CatService
    {
        HttpClient client;

        public CatService()
        {
            client = new HttpClient();
        }

        List<Cat> catList = new();

        public async Task<List<Cat>> GetCats()
        {
            // need try logic for Ditto implementation
            if (catList?.Count > 0)
            {
                return catList;
            }

            return null;
        }
    }
}
