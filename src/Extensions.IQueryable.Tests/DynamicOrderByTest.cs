using System;
using System.Collections.Generic;
using System.Linq;
using Tolitech.CodeGenerator.Extensions.IQueryable.Tests.Entities;
using Xunit;

namespace Tolitech.CodeGenerator.Extensions.IQueryable.Tests
{
    public class DynamicOrderByTest
    {
        [Fact(DisplayName = "DynamicOrderBy - OrderByAsc - Valid")]
        public void DynamicOrderBy_OrderByAsc_Valid()
        {
            var items = new List<PersonEntity>();

            for (int i = 0; i < 10; i++)
            {
                items.Add(new PersonEntity($"Name {i + 1:00}", i + 1, $"email{i}@email.com"));
            }

            var people = items
                .AsQueryable()
                .DynamicOrderBy("Name:asc, Age:asc")
                .ToList();

            Assert.True(people.First().Name == "Name 01");
        }

        [Fact(DisplayName = "DynamicOrderBy - OrderByDesc - Valid")]
        public void DynamicOrderBy_OrderByDesc_Valid()
        {
            var items = new List<PersonEntity>();

            for (int i = 0; i < 10; i++)
            {
                items.Add(new PersonEntity($"Name {i + 1:00}", i + 1, $"email{i}@email.com"));
            }

            var people = items
                .AsQueryable()
                .DynamicOrderBy("Name:desc, Age:asc")
                .ToList();

            Assert.True(people.First().Name == "Name 10");
        }

        [Fact(DisplayName = "DynamicOrderBy - ComplexOrderByAsc - Valid")]
        public void DynamicOrderBy_ComplexOrderByAsc_Valid()
        {
            var items = new List<PersonEntity>();
            items.Add(new PersonEntity($"Name 1", 31, $"test3@test.com"));
            items.Add(new PersonEntity($"Name 2", 30, $"test1@test.com"));
            items.Add(new PersonEntity($"Name 3", 32, $"test2@test.com"));

            var people = items
                .AsQueryable()
                .DynamicOrderBy("Email.Email:asc")
                .ToList();

            Assert.True(people.First().Name == "Name 2");
        }

        [Fact(DisplayName = "DynamicOrderBy - MultiplesOrderByAscAndDesc - Valid")]
        public void DynamicOrderBy_MultiplesOrderByAscAndDesc_Valid()
        {
            var items = new List<PersonEntity>();
            items.Add(new PersonEntity($"Name 1", 31, $"test@test.com"));
            items.Add(new PersonEntity($"Name 2", 30, $"test@test.com"));
            items.Add(new PersonEntity($"Name 3", 32, $"test@test.com"));

            var people = items
                .AsQueryable()
                .DynamicOrderBy("Email.Email:asc, Age:desc")
                .ToList();

            Assert.True(people.First().Name == "Name 3");
        }
    }
}