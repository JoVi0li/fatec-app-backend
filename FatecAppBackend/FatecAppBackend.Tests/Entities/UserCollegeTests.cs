using FatecAppBackend.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FatecAppBackend.Tests
{
    public class UserCollegeTests
    {

        [Fact]
        public void ShouldReturnIUserCollegeIsValid()
        {
            UserCollege userCollege = new UserCollege(
                new Guid(),
                new Guid(),
                "38219381221",
                false,
                "2jro23jk43p42",
                DateTime.Now
            );

            Assert.True(userCollege.IsValid);
        }
    }
}
