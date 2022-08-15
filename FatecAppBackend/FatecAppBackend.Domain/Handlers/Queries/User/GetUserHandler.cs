using FatecAppBackend.Domain.Queries.User;
using FatecAppBackend.Domain.Repositories;
using FatecAppBackend.Shared.Handlers.Contracts;
using FatecAppBackend.Shared.Queries;
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FatecAppBackend.Domain.Handlers.Queries.User
{
    public class GetUserHandler : Notifiable<Notification>, IHandlerQuery<GetUserQuery>
    {
        private readonly IUserRepository _userRepository;

        public GetUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IQueryResult Execute(GetUserQuery query)
        {
            var users = _userRepository.GetAll();

            if (users == null || users.Count == 0)
            {
                return new GenericQueryResult(false, "Users not found", 0);
            }

            var result = users.Select(
                x =>
                {
                    return new GetUserQueryResult(x.Id, x.UserCollege.Id, x.Name, x.Email, x.Photo, x.PhoneNumber, x.IdentityDocumentNumber, x.Gender, x.ValidatedUser, x.UserCollege.ValidatedDocument);

                }
            );

            return new GenericQueryResult(true, "Users found", result);
        }
    }
}
