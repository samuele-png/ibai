using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BCrypt.Net;

namespace DataLayer
{
    public static class PasswordHandler
    {
        private static string pepper = "gekoloniseerdForSaltAndPepper";
        public static string GetRandomSalt()
        {   /*             
             GenerateSalt(int workFactor, SaltRevision saltSaltRevision = SaltRevision.Revision2B)
             generatesalt argument is salt length? can't find proper documentation. can't understand what workfactor is nor saltrevision. shouldn't workbut does (?)
            */
            return BCrypt.Net.BCrypt.GenerateSalt(12);
        }
        public static string HashPassword(string password)
        {
            string pepperedPass = password + pepper;

            return BCrypt.Net.BCrypt.HashPassword(pepperedPass, GetRandomSalt());
        }
        public static bool ValidatePassword(string password, string correctHash)
        {
            {
                string pepperedPass = password + pepper;
                return BCrypt.Net.BCrypt.Verify(pepperedPass, correctHash);
            }
        }
    }

}
