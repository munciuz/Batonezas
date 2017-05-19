using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Batonezas.DataAccess;

namespace Batonezas.Tests.Tags
{
    public static class DishData
    {
        public static IQueryable<Dish> CreateQuery()
        {
            IList<Dish> dishes = new List<Dish>
            {
                new Dish { Id = 1, Name = "Lasisos kepsnys", CreatedDateTime = new DateTime(2017, 05, 15), CreatedByUserId = 1, IsValid = true, User = new User {UserName = "administrator"} },
                new Dish { Id = 2, Name = "karbonadas", CreatedDateTime = new DateTime(2017, 05, 15), CreatedByUserId = 1, IsValid = true, User = new User {UserName = "administrator"} },
                new Dish { Id = 3, Name = "snicelis", CreatedDateTime = new DateTime(2017, 05, 15), CreatedByUserId = 1, IsValid = true, User = new User {UserName = "administrator"} }};

            var query = dishes.AsQueryable();

            return query;
        }

        public static Dish Get() => CreateQuery().First();
    }
}
