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
            book.RemoveUser(0);
            
            
            Console.ReadKey();
        }
        
    }
     
}
