using FatecAppBackend.Domain;
using FatecAppBackend.Domain.Entities;
using FatecAppBackend.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FatecAppBackend.Tests.Entities
{
    public class EventTests
    {
        [Fact]
        public void ShouldReturnIfEventIsValid()
        {
            List<UserCollege> userColleges = new();

            Event @event = new(
                 new Guid(),
                userColleges,
                "dasdada",
                "dasdasdasd",
                "dasdasdas",
                false,
                DateTime.Now,
                EnStatus.Ready
            );

            Assert.True(@event.IsValid);
        }
    }
}
