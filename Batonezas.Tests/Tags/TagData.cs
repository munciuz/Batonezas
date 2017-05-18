using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Batonezas.DataAccess;

namespace Batonezas.Tests.Tags
{
    public static class TagData
    {
        public static IQueryable<Tag> CreateQuery()
        {
            IList<Tag> tags = new List<Tag>
            {
                new Tag { Id = 1, Name = "Vistiena", CreatedDateTime = new DateTime(2017, 05, 15), CreatedByUserId = 1, IsValid = true },
                new Tag { Id = 2, Name = "Kiauliena", CreatedDateTime = new DateTime(2017, 05, 15), CreatedByUserId = 1, IsValid = true },
                new Tag { Id = 3, Name = "Mesainis", CreatedDateTime = new DateTime(2017, 05, 15), CreatedByUserId = 1, IsValid = true },
                new Tag { Id = 4, Name = "Sriuba", CreatedDateTime = new DateTime(2017, 05, 15), CreatedByUserId = 1, IsValid = true }};

            var query = tags.AsQueryable();

            return query;
        }
    }
}
