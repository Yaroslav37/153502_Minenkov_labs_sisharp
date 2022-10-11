using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _153502_Minenkov_lab1.Collections;

namespace _153502_Minenkov_lab1.Entities
{
    internal class Client
    {
        private string lastName;

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        public Client(string lastName) { this.lastName = lastName; }

        public void RentRoom(Room currentRoom)
        {
            currentRoom.SetUnAvailible();
            currentRoom.SetClient(this);

        }

    }
}
