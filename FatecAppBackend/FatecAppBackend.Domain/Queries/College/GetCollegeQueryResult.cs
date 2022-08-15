using FatecAppBackend.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FatecAppBackend.Domain.Queries.College
{
    public class GetCollegeQueryResult
    {
        public GetCollegeQueryResult(Guid id, string name, string course, EnTime time, string localization)
        {
            Id = id;
            Name = name;
            Course = course;
            Time = time;
            Localization = localization;
        }

        public Guid Id { get; private set; }

        public string Name { get; private set; }

        public string Course { get; private set; }

        public EnTime Time { get; private set; }

        public string Localization { get; private set; }
    }
}
