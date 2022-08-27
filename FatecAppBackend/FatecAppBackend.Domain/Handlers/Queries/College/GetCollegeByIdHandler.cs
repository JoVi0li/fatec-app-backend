using FatecAppBackend.Domain.Queries.College;
using FatecAppBackend.Domain.Repositories;
using FatecAppBackend.Shared.Handlers.Contracts;
using FatecAppBackend.Shared.Queries;
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FatecAppBackend.Domain.Handlers.Queries.College
{
    public class GetCollegeByIdHandler : Notifiable<Notification>, IHandlerQuery<GetCollegeByIdQuery>
    {
        private readonly ICollegeRepository _collegeRepository;

        public GetCollegeByIdHandler(ICollegeRepository collegeRepository)
        {
            _collegeRepository = collegeRepository;
        }

        public IQueryResult Execute(GetCollegeByIdQuery query)
        {
            query.Execute();

            if (!IsValid)
            {
                return new GenericQueryResult(false, "Invalid props", query.Notifications);
            }

            var college = _collegeRepository.GetById(query.Id);

            if(college == null)
            {
                return new GenericQueryResult(false, "College not found", "Inform another Id");
            }

            var result = new GetCollegeQueryResult(college.Id, college.Name, college.Course, college.Time, college.Localization);

            return new GenericQueryResult(true, "College found", result);
        }
    }
}
