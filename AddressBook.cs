using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Singleton
{
    public delegate void DelegEventUser(IWriteLog w, string m);

    class AddressBook 
    {
        // implementation singleton
        private static readonly AddressBook inst = new AddressBook();

        private AddressBook()
        { }

        static AddressBook()
        { }

        public static AddressBook GetInstance()
        {
            return inst;
        }

        List<User> userList = new List<User>();

        //create type logs
        WriteLog wf = new WriteLog();
        WriteConsole wc = new WriteConsole();
        

        // create events
        public event DelegEventUser UserAdded = null;
        public event DelegEventUser UserRemoved = null;


        public void OnUserAddedEvent(IWriteLog w, string message)
        {
            if (UserAdded != null)
                UserAdded(w, message);
        }

        public void OnUserRemovedEvent(IWriteLog w, string message)
        {
            if (UserRemoved != null)
                UserRemoved(w, message);
        }

        public void AddUser()
        {
            User u = new User();    //create user           

            u.InputUser();    // input user's data 

            userList.Add(u);

            UserAdded += Logger.Info;      //add handler

            //  implementation weak connection
            OnUserAddedEvent(wf, "Added user in list"); //call event for file
            OnUserAddedEvent(wc, "Added user in list" + "\n"); //call event for console
            
            UserAdded -= Logger.Info;
        }

        public void RemoveUser(int index)
        {
            userList.RemoveAt(index);  // remove user by index

            UserRemoved += Logger.Warning;

            OnUserRemovedEvent(wf, "Removed user with list");  //call event file
            OnUserRemovedEvent(wc, "Removed user with list"); //call event for console
           
            UserRemoved -= Logger.Warning;
        }

    /*-------------------------------------------Add task3-------------------------------*/   
        public void SelectByEmail()
        {          
              var selectedUsers =  userList.Where(s => s.Email.Contains("gmail.com"));

              foreach (var u in selectedUsers)   // Deferred execution query
                  Console.WriteLine(u.LastName + " " + u.FirstName);

            /*var v = from User in userList
                    where User.Email.Contains("gmail.com") 
                    select User.LastName +" "+ User.FirstName;                   
          
              foreach (var u in v)
            Console.WriteLine(u);
              */
              Console.WriteLine("----------------------");
        }

        public void SelectByGender()
        {
            var v = from User in userList
                    where (User.Gender == "woman" || User.Gender == "female" || User.Gender == "girl") && ((DateTime.Now.Date - User.TimeAdded.Date).Days < 10)// User.Email == "gmail.com"
                    select User.LastName +" "+ User.FirstName;                   
          
              foreach (var u in v)
                Console.WriteLine(u);

              Console.WriteLine("----------------------");
        }

        public void TestExtentionMethod()
        {
            var v = userList.ExtentionMethod(); 

            foreach(string u in v)
                Console.WriteLine(u);

            Console.WriteLine("----------------------");
        }

        

        public void SelectBirthdayJanuary()
        {
            var v = from user in userList
                    where (user.Birthdate.Month == 1) && (user.Address.Length > 0) && (user.PhoneNumber.Length > 0)
                    orderby user.LastName descending
                    select user.LastName + " " + user.FirstName;

            foreach (var u in v)       //Deferred executed
                Console.WriteLine(u);

            Console.WriteLine("----------------------");

        }

        public void SelectManWomaninDictionary()
        {
            Dictionary<string, string> dictionary = new Dictionary<string,string>();
            string sum = "";
            var v = from User in userList
                    where (User.Gender == "woman")                    
                    select User.LastName + " " + User.FirstName;
            
            foreach (var u in v) 
                 sum += (u +"   "); 
            
            dictionary.Add("woman", sum);

            var w = from User in userList
                    where (User.Gender == "man")
                    select User.LastName + " " + User.FirstName;

            foreach (var u in w)
                sum += (u + "   ");
 
            dictionary.Add("man", sum);
            
            foreach(var u in dictionary)
                Console.WriteLine(u.Key + " | " + u.Value);

            Console.WriteLine("----------------------");

        }

        public void SelectByCityAndBirthdayToday(string city)
        {
            int count = 0;
             count = (from User in userList
                    where (User.City == city) && (User.Birthdate.Day == DateTime.Now.Day) && (User.Birthdate.Month == DateTime.Now.Month)
                      select User.LastName).Count();    //immediately executed
            
            Console.WriteLine("Count user from {0} who birthday is today: {1}",city,count);
                        
            Console.WriteLine("----------------------");
        }

        public void SelectSkipTake(Func<User, bool> condition, int skip, int take)
        {           
            var selectedUsers = userList.Where(condition).Skip(skip).Take(take);  

            foreach (var u in selectedUsers)
                Console.WriteLine(u.LastName + " " + u.FirstName);
                       
            Console.WriteLine("----------------------");
        }
    }
}
