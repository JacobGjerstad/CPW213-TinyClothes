using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TinyClothes.Models;

namespace TinyClothes.Data
{
    /// <summary>
    /// Contains DB helper methods for <see cref="Models.Clothing"/>
    /// </summary>
    public static class ClothingDb
    {
        /// <summary>
        /// Returns the total number of Clothing items
        /// </summary>
        public async static Task<int> GetNumClothing(StoreContext context)
        {
            return await context.Clothing.CountAsync();

            // Alternative way with query syntax
            // return await (from c in context.Clothing
            //               select c).CountAsync();
        }

        /// <summary>
        /// Returns a specific page of clothing items sorted by ItemId in ascending order
        /// </summary>
        /// <param name="pageNum">The number of the page selected by the user</param>
        /// <param name="pageSize">Number of Clothing items per page</param>
        public async static Task<List<Clothing>> GetClothingByPage(StoreContext context, int pageNum, int pageSize)
        {
            // If you wanted page 1, we wouldn't skip any rows, so we must offset by 1
            const int PageOffset = 1;
            // LINQ Method Syntax
            List<Clothing> clothes = await context.Clothing
                                                  .OrderBy(c => c.ItemId)
                                                  .Skip(pageSize * (pageNum - PageOffset)) // Skip must be before Take
                                                  .Take(pageSize)
                                                  .ToListAsync();


            // LINQ Query Syntax - Same as above - keeping for notes
            // ************
            //List<Clothing> clothes2 = await (from c in context.Clothing
            //                                 orderby c.ItemId ascending
            //                                 select c).Skip(pageNum * (pageSize - PageOffset))
            //                                          .Take(pageSize)
            //                                          .ToListAsync();

            return clothes;
        }
        
        /// <summary>
        /// Adds a clothing boject to the database.
        /// Returns the object with the Id populated
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static async Task<Clothing> Add(Clothing c, StoreContext context)
        {
            await context.AddAsync(c); // prepares INSERT query
            await context.SaveChangesAsync(); // execute INSERT query

            return c;
        }
    }
}
