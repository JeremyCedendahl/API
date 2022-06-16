using Labb3.API.Models;
using Labb3Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labb3.API.Services
{
    public class PersonRepository : IPersonRepository<Person>
    {
        private DatabaseContext dbContext;

        public PersonRepository(DatabaseContext context)
        {
            dbContext = context;
        }
        public async Task<IEnumerable<Person>> GetAll()
        {
            return await dbContext.Persons.ToListAsync();
        }

        public async Task<Person> GetInterests(int id)
        {
            var person = GetSingle(id);
            if (person != null)
            {
                var hobbies = await dbContext.Persons
                    .Include(i => i.PersonHobbies)
                    .ThenInclude(n => n.Hobby)
                    .FirstOrDefaultAsync(p => p.PersonId == id);
                return hobbies;
            }
            return null;
        }

        public async Task<Person> GetLinks(int id)
        {
            var person = GetSingle(id);
            if (person != null)
            {
                var links = await dbContext.Persons
                    .Include(i => i.Links)
                    .ThenInclude(n => n.Hobby)
                    .FirstOrDefaultAsync(p => p.PersonId == id);
                return links;
            }
            return null;
        }

        public async Task<Person> GetSingle(int id)
        {
            return await dbContext.Persons
                .FirstOrDefaultAsync(p => p.PersonId == id);
        }
    }
}