﻿using FatecAppBackend.Domain.Queries.User;
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
    public class GetUserByEmailHandler : Notifiable<Notification>, IHandlerQuery<GetUserByEmailQuery>
    {
        private readonly IUserRepository _userRepository;

        public GetUserByEmailHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IQueryResult Execute(GetUserByEmailQuery query)
        {
            query.Execute();

            if (!query.IsValid)
            {
                return new GenericQueryResult(false, "Invalid props", query.Notifications);
            }

            var user = _userRepository.GetByEmail(query.Email);

            if (user == null)
            {
                return new GenericQueryResult(false, "User not found", "Inform another Email");
            }

            if (!user.IsValid)
            {
                return new GenericQueryResult(false, "Invalid props", user.Notifications);
            }

            var result = new GetUserQueryResult(user.Id, user.UserCollege?.Id, user.Name, user.Email, user.Photo, user.PhoneNumber, user.IdentityDocumentNumber, user.Gender, user.ValidatedUser, user.UserCollege?.ValidatedDocument);
            
            return new GenericQueryResult(true, "User found", result);
        }
    }
}
