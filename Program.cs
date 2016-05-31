using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            AddressBook book = AddressBook.GetInstance();
            book.AddUser();
            book.AddUser();
            book.AddUser();

            Console.WriteLine("Users list who email is the domain gmail.com");
            book.SelectByEmail();

            Console.WriteLine("Users list girl add in list for last 10 days");
            book.SelectByGender();

            Console.WriteLine("Users list who Birthday in January");
            book.SelectBirthdayJanuary();

            Console.WriteLine("Users list man and woman");
            book.SelectManWomaninDictionary();

            book.SelectByCityAndBirthdayToday("Lviv");


            Console.WriteLine("Users list with condition and two parametrs");

            Func<User, bool> f = s => s.PhoneNumber.Length == 10;      

            book.SelectSkipTake(f,1,2);
           

            book.TestExtentionMethod();
            Console.ReadKey();
        }
        
    }
     
}
