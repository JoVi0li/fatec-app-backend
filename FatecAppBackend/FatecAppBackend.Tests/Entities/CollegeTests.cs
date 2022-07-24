using FatecAppBackend.Domain;
using FatecAppBackend.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FatecAppBackend.Tests
{
    public class CollegeTests
    {
        [Fact]
        public void ShouldReturnIfCollegeIsValid()
        {
            College college = new(
                "Fatec Sebrae",
                "Gestão de Negócios e Inovação",
                EnTime.PM,
                "Rua XVL"
            );

            Assert.True(college.IsValid);
        }
    }
}
