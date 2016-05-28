using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Singleton
{
    public delegate void DelegEventUser(IWriteLog w, string m);

    class AddressBook
    {
        // implementation singleton
        private static readonly AddressBook inst = new AddressBook();  
        
        private AddressBook()
        {}

        static AddressBook()
        { }

        public static AddressBook GetInstance()
        {
            return inst;
        }

        List<User> usersList = new List<User>();       

        //create type logs
        WriteLog wf = new WriteLog();  
        WriteConsole wc = new WriteConsole();
        WriteDataBase wdb = new WriteDataBase();        

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
           
            usersList.Add(u);

            UserAdded += Logger.Info;      //add handler

            //  implementation weak connection
            OnUserAddedEvent(wf,"Added user in list"); //call event for file
            OnUserAddedEvent(wc, "Added user in list"+"\n"); //call event for console
            OnUserAddedEvent(wdb, "Added user in list"); //call event for DB (testting handler error connection with DB)
            UserAdded -= Logger.Info;
        }

        public void RemoveUser(int index)
        {
            usersList.RemoveAt(index);  // remove user by index

            UserRemoved += Logger.Warning;
                       
            OnUserRemovedEvent(wf, "Removed user with list");  //call event file
            OnUserRemovedEvent(wc, "Removed user with list"); //call event for console
            OnUserRemovedEvent(wdb, "Removed user with list"); //call event for DB (testting handler error connection with DB)
            UserRemoved -= Logger.Warning;
        }

        

    }
}
