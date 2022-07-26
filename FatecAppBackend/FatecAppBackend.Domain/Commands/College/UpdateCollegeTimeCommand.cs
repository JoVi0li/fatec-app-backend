using FatecAppBackend.Shared;
using FatecAppBackend.Shared.Commands;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FatecAppBackend.Domain.Commands.College
{
    public class UpdateCollegeTimeCommand : Notifiable<Notification>, ICommand
    {
        public UpdateCollegeTimeCommand(EnTime time, Guid id)
        {
            Time = time;
            Id = id;
        }

        public EnTime Time { get; set; }
        public Guid Id { get; set; }

        public void Execute()
        {
            AddNotifications(
                new Contract<Notification>()
                    .Requires()
                    .IsNotNull(Time, "Time", "Time cannot be null")
                    .IsNotNull(Id, "Id", "Id cannot be null")
            );
        }
    }
}
