using one.Application.Contracts;
using one.Domain;
using one.EntityFrameworkCore;
using one.Infrastructure.Repositories;
using System;
using System.Text;
using System.Threading.Tasks;

namespace one.Application
{
    public class PersonService : IPersonService
    {
        private readonly OneDbContext _context;

        public PersonService(OneDbContext context)
        {
            _context = context;
        }

        public async Task<PersonDTO> GenerateRandomPersonAsync()
        {
            var newPerson = new Person
            {
                FirstName = RandomString(10),
                LastName = RandomString(15),
                Age = RandomNumber(5, 15)
            };
            GenericEFCoreRepository<Person, Guid> repo = new(_context);

            await repo.InsertAsync(newPerson);
            await _context.SaveChangesAsync();

            var newPersonDTO = new PersonDTO()
            {
                Id = newPerson.Id,
                FirstName = newPerson.FirstName,
                LastName = newPerson.LastName,
                Age = newPerson.Age,
            };

            return newPersonDTO;
        }

        private static int RandomNumber(int min, int max)
        {
            var rand = new Random();
            return rand.Next(min, max);
        }

        private static string RandomString(int size, bool lowerCase = false)
        {
            var rand = new Random();
            var builder = new StringBuilder(size);

            // Unicode/ASCII Letters are divided into two blocks
            // (Letters 65–90 / 97–122):
            // The first group containing the uppercase letters and
            // the second group containing the lowercase.

            // char is a single Unicode character
            char offset = lowerCase ? 'a' : 'A';
            const int lettersOffset = 26; // A...Z or a..z: length=26

            for (var i = 0; i < size; i++)
            {
                var @char = (char)rand.Next(offset, offset + lettersOffset);
                builder.Append(@char);
            }

            return lowerCase ? builder.ToString().ToLower() : builder.ToString();
        }
    }
}