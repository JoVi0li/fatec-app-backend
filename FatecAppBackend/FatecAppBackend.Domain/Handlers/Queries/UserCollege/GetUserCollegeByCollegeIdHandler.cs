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
    public class GetUserCollegeByCollegeIdHandler : Notifiable<Notification>, IHandlerQuery<GetUserCollegeByCollegeIdQuery>
    {
        private readonly IUserCollegeRepository _userCollegeRepository;

        public GetUserCollegeByCollegeIdHandler(IUserCollegeRepository userCollegeRepository)
        {
            _userCollegeRepository = userCollegeRepository;
        }

        public IQueryResult Execute(GetUserCollegeByCollegeIdQuery query)
        {
            query.Execute();

            if (!query.IsValid)
            {
                return new GenericQueryResult(false, "Invalid props", query.Notifications);
            }

            var userCollege = _userCollegeRepository.GetByCollegeId(query.CollegeId);

            if(userCollege == null)
            {
                return new GenericQueryResult(false, "UserCollege not found", "Inform another CollegeId");
            }

            var result = new GetUserCollegeQueryResult(userCollege.Id, userCollege.UserId, userCollege.CollegeId, userCollege.StudentNumber, userCollege.ValidatedDocument, userCollege.ProofDocument, userCollege.GraduationDate);
            
            return new GenericQueryResult(true, "UserCollege found", result);
        }
    }
}
