using System;

namespace one.Domain
{
    public class Person : Entity<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }
}