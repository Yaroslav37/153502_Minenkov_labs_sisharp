using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _153502_Minenkov_lab1.Collections;

namespace _153502_Minenkov_lab1.Entities
{
    public class Journal
    {
        MyCustomCollection<string> AddedClientList = new MyCustomCollection<string>();
        MyCustomCollection<int> AddedRoomsList = new MyCustomCollection<int>();


        public void AddWorker(string LastName) {
            AddedClientList.Add(LastName);
        }


        public void printInfoAboutAddedClients()
        {
            String info = "";
            foreach (string lastname in AddedClientList)
            {
                info += lastname + " added in ClientList. \n";
            }
            Console.WriteLine(info);
        }
    }
}
