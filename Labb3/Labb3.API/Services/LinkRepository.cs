using Labb3.API.Models;
using Labb3Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labb3.API.Services
{
    public class LinkRepository : IRepos<Link>
    {
        private DatabaseContext dbContext;

        public LinkRepository(DatabaseContext context)
        {
            dbContext = context;
        }

        public async Task<Link> Add(Link newEntity)
        {
            var newLink = await dbContext.Links.AddAsync(newEntity);
            await dbContext.SaveChangesAsync();
            return newLink.Entity;
        }

        public async Task<IEnumerable<Link>> GetAll()
        {
            return await dbContext.Links.ToListAsync();
        }

        public async Task<Link> GetSingle(int id)
        {
            return await dbContext.Links
                .FirstOrDefaultAsync(l => l.LinkId == id);
        }
    }
}