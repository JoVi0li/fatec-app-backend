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
    public class GetUserCollegeByUserIdHandler : Notifiable<Notification>, IHandlerQuery<GetUserCollegeByUserIdQuery>
    {
        private readonly IUserCollegeRepository _userCollegeRepository;

        public GetUserCollegeByUserIdHandler(IUserCollegeRepository userCollegeRepository)
        {
            _userCollegeRepository = userCollegeRepository;
        }

        public IQueryResult Execute(GetUserCollegeByUserIdQuery query)
        {
            query.Execute();

            if (!query.IsValid)
            {
                return new GenericQueryResult(false, "Invalid props", query.Notifications);
            }

            var userCollege = _userCollegeRepository.GetByUserId(query.UserId);

            if (userCollege == null)
            {
                return new GenericQueryResult(false, "UserCollege not found", "Inform another UserId");
            }

            var result = new GetUserCollegeQueryResult(userCollege.Id, userCollege.UserId, userCollege.CollegeId, userCollege.StudentNumber, userCollege.ValidatedDocument, userCollege.ProofDocument, userCollege.GraduationDate);

            return new GenericQueryResult(true, "UserCollege found", result);
        }
    }
}
