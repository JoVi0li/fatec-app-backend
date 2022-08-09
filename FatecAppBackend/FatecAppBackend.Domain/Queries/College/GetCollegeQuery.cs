using FatecAppBackend.Shared;
using FatecAppBackend.Shared.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FatecAppBackend.Domain.Queries.College
{
    public class GetCollegeQuery : IQuery
    {
        public void Execute()
        {
            throw new NotImplementedException();
        }

        public class GetCollegeQueryResult
        {
            public Guid Id { get; set; }
            public string Name { get; private set; }

            public string Course { get; private set; }

            public EnTime Time { get; private set; }

            public string Localization { get; private set; }
        }
    }
}
