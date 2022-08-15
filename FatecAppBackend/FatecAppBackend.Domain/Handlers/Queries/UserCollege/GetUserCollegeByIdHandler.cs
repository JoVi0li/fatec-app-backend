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
    public class GetUserCollegeByIdHandler : Notifiable<Notification>, IHandlerQuery<GetUserCollegeByIdQuery>
    {
        private readonly IUserCollegeRepository _userCollegeRepository;

        public GetUserCollegeByIdHandler(IUserCollegeRepository userCollegeRepository)
        {
            _userCollegeRepository = userCollegeRepository;
        }

        public IQueryResult Execute(GetUserCollegeByIdQuery query)
        {
            query.Execute();

            if (!query.IsValid)
            {
                return new GenericQueryResult(false, "Invalid props", query.Notifications);
            }

            var userCollege = _userCollegeRepository.GetById(query.Id);

            if (userCollege == null)
            {
                return new GenericQueryResult(false, "UserCollege not found", "Inform another Id");
            }

            var result = new GetUserCollegeQueryResult(userCollege.Id, userCollege.UserId, userCollege.CollegeId, userCollege.StudentNumber, userCollege.ValidatedDocument, userCollege.ProofDocument, userCollege.GraduationDate);

            return new GenericQueryResult(true, "UserCollege found", result);
        }
    }
}
