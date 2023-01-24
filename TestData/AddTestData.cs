using dsd03Razor2020Assessment.Models;

using RolesForAssessment.Data;

using System.Text.Json;

namespace RolesForAssessment.TestData
{

    internal static class AddTestData
    {

        //import json array and add to context
        public static void AddMovieData(ApplicationDbContext context)
        {
            var jsonString = File.ReadAllText("testMoviedata.json");

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var list = JsonSerializer.Deserialize<Movie[]>(jsonString, options);
            {
                foreach (var item in list)
                {
                    context.Movie.Add(item);
                }
                //  context.SaveChanges();
            }

        }

        public static void AddCastData(ApplicationDbContext context)
        {
            var jsonString = File.ReadAllText("testCastdata.json");

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var list = JsonSerializer.Deserialize<List<Cast>>(jsonString, options);
            {
                foreach (var item in list)
                {
                    context.Cast.Add(item);
                }
                //  context.SaveChanges();
            }

        }


    }
}