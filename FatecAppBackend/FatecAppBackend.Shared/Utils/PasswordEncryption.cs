using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FatecAppBackend.Shared.Utils
{
    public static class PasswordEncryption
    {
        public static string Encrypt(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public static bool IsValid(string password, string hash)
        {
            return BCrypt.Net.BCrypt.Verify(password, hash);
        }
    }
}
