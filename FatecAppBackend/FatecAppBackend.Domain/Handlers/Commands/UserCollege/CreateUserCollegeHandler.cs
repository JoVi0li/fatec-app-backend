using FatecAppBackend.Domain.Commands.UserCollege;
using FatecAppBackend.Domain.Repositories;
using FatecAppBackend.Domain.Services;
using FatecAppBackend.Shared.Commands;
using FatecAppBackend.Shared.Handlers.Contracts;
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FatecAppBackend.Domain.Handlers.Commands.UserCollege
{
    public class CreateUserCollegeHandler : Notifiable<Notification>, IHandlerCommand<CreateUserCollegeCommand>
    {
        private readonly IUserCollegeRepository _userCollegeRepository;
        private readonly IFileService _fileService;

        public CreateUserCollegeHandler(IUserCollegeRepository userCollegeRepository, IFileService fileService)
        {
            _userCollegeRepository = userCollegeRepository;
            _fileService = fileService;
        }

        public ICommandResult Execute(CreateUserCollegeCommand command)
        {
            command.Execute();

            if (!command.IsValid)
            {
                return new GenericCommandsResult(false, "Invalid props", command.Notifications);
            }

            try
            {
                var userCollegeProofDoc = "user-college-proof-doc-photo-" + command.StudentNumber + "-" + Guid.NewGuid();
                command.ProofDocument = _fileService.UploadFile(command.ProofDocument, userCollegeProofDoc);
            }
            catch (Exception e)
            {
                return new GenericCommandsResult(false, "Could not upload the user college proof document photo", e.Message);
            }

            Entities.UserCollege userCollege = new(
                command.UserId,
                command.CollegeId,
                command.StudentNumber,
                false,
                command.ProofDocument,
                DateTime.Parse(command.GraduationDate)
            );

            if (!userCollege.IsValid)
            {
                return new GenericCommandsResult(false, "Invalid props", userCollege.Notifications);
            }

            _userCollegeRepository.Create(userCollege);

            return new GenericCommandsResult(true, "UserCollege created", userCollege.Id);
        }
    }
}
