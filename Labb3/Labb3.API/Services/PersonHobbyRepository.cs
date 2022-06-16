using Labb3.API.Models;
using Labb3Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labb3.API.Services
{
    public class PersonHobbyRepository : IRepos<PersonHobby>
    {
        private DatabaseContext dbContext;

        public PersonHobbyRepository(DatabaseContext context)
        {
            dbContext = context;
        }
        public async Task<PersonHobby> Add(PersonHobby personHobby)
        {
            var newPersonHobby = await dbContext.PersonHobbies.AddAsync(personHobby);
            await dbContext.SaveChangesAsync();
            return newPersonHobby.Entity;

        }

        public async Task<IEnumerable<PersonHobby>> GetAll()
        {
            return await dbContext.PersonHobbies.ToListAsync();
        }

        public async Task<PersonHobby> GetSingle(int id)
        {
            return await dbContext.PersonHobbies
                .FirstOrDefaultAsync(p => p.PersonHobbyId == id);
        }


    }
}