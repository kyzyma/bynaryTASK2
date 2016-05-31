using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Singleton
{
   static class ExtentionClass
    {
        public static IEnumerable<string> ExtentionMethod(this IEnumerable<User> source)
       {
           var v = from user in source
                   where (DateTime.Now.Year - user.Birthdate.Year) > 18 && user.City == "Kiev" // це не зовсім точна формула розрахунку кількості років
                   select user.LastName + " " + user.FirstName;
            

            foreach (var u in v)
            {
                yield return u;
            }
        }
    }
}
