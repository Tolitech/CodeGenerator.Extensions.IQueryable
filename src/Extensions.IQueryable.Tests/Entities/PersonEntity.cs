using System;
using Tolitech.CodeGenerator.Extensions.IQueryable.Tests.ValueObjects;

namespace Tolitech.CodeGenerator.Extensions.IQueryable.Tests.Entities
{
    public class PersonEntity : IEntity
    {
        public PersonEntity(string name, int age, string email)
        {
            PersonId = Guid.NewGuid();
            Name = name;
            Age = age;
            Email = new EmailValueObject { Email = email };
        }

        public Guid PersonId { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public EmailValueObject Email { get; set; }
    }
}
