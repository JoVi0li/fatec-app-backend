using FatecAppBackend.Domain.Queries.College;
using FatecAppBackend.Domain.Repositories;
using FatecAppBackend.Shared.Handlers.Contracts;
using FatecAppBackend.Shared.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FatecAppBackend.Domain.Queries.College.GetCollegeQuery;

namespace FatecAppBackend.Domain.Handlers.Queries.College
{
    public class GetCollegeHandler : IHandlerQuery<GetCollegeQuery>
    {
        private readonly ICollegeRepository _collegeRepository;

        public GetCollegeHandler(ICollegeRepository collegeRepository)
        {
            _collegeRepository = collegeRepository;
        }

        public IQueryResult Execute(GetCollegeQuery query)
        {
            var colleges = _collegeRepository.GetAll();

            if(colleges == null || colleges.Count == 0)
            {
                return new GenericQueryResult(false, "Colleges not found", 0);
            }

            var result = colleges.Select(
                x =>
                {
                    return new GetCollegeQueryResult(x.Id, x.Name, x.Course, x.Time, x.Localization);
                }
            );

            return new GenericQueryResult(true, "Colleges found", result);
        }
    }
}
