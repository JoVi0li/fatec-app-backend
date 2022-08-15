using FatecAppBackend.Domain.Queries.UserCollege;
using FatecAppBackend.Domain.Repositories;
using FatecAppBackend.Shared.Handlers.Contracts;
using FatecAppBackend.Shared.Queries;
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FatecAppBackend.Domain.Handlers.Queries.UserCollege
{
    public class GetUserCollegeHandler : Notifiable<Notification>, IHandlerQuery<GetUserCollegeQuery>
    {
        private readonly IUserCollegeRepository _userCollegeRepository;

        public GetUserCollegeHandler(IUserCollegeRepository userCollegeRepository)
        {
            _userCollegeRepository = userCollegeRepository;
        }

        public IQueryResult Execute(GetUserCollegeQuery query)
        {
            var userColleges = _userCollegeRepository.GetAll();

            if (userColleges == null || userColleges.Count() == 0)
            {
                return new GenericQueryResult(false, "UserColleges not found", 0);
            }

            var result = userColleges.Select(
                x =>
                {
                    return new GetUserCollegeQueryResult(x.Id, x.UserId, x.CollegeId, x.StudentNumber, x.ValidatedDocument, x.ProofDocument, x.GraduationDate);
                }   
            );

            return new GenericQueryResult(true, "UserCollege found", result);
        }
    }
}
