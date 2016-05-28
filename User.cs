using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Singleton
{
    class User
    {
       public string LastName;
       public string FirstName;
       public string Birthdate;
       public string TimeAdded;
       public string City;
       public string Address;
       public string PhoneNumber;
       public string Gender;
       public string Email;

       public void InputUser()
       {
           Console.WriteLine("     Please input user data ");
           Console.Write("input lastname: ");
           Console.ReadLine();

           Console.Write("input firstname: ");
           Console.ReadLine();

           Console.Write("input Birthdate: ");
           Console.ReadLine();

           Console.Write("input TimeAdded: ");
           Console.ReadLine();

           Console.Write("input City: ");
           Console.ReadLine();

           Console.Write("input Address: ");
           Console.ReadLine();

           Console.Write("input PhoneNumber: ");
           Console.ReadLine();

           Console.Write("input Gender: ");
           Console.ReadLine();

           Console.Write("input Email: ");
           Console.ReadLine();

           Console.WriteLine();
       }
    }
}
