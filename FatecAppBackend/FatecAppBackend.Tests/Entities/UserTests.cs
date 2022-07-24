using FatecAppBackend.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FatecAppBackend.Tests
{
    public class UserTests
    {
        [Fact]
        public void ShouldReturnIfUserIsValid()
        {
            User user = new User(
                "João Vitor",
                "jovi.oli04@gmail.com",
                "jovioli318940",
                "jnifnusiednuifnweufniwn",
                "11989915309",
                "24104076848",
                "312-039-1293-129-312--231231",
                Shared.EnGender.Male,
                false
            );

            Assert.True(user.IsValid, "Valid User");
        }
    }
}
