using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _153502_Minenkov_lab1.Entities
{
    internal class Room
    {

        private Client person = null;

        public Client Person
        {
            get { return person; }
            set { person = value; }
        }
        public Room(uint number)
        {
            this.number = number;
        }

        public Room(uint number, uint cost)
        {
            this.number = number;
            this.cost = cost;
        }

        private uint number;
        public uint Number
        {
            get { return number; }
            set { number = value; }
        }

        uint cost = 5;

        public uint Cost
        {
            get { return cost; }
            set { cost = value; }
        }

        bool isAvailible = true;

        public bool IsAvailible
        {
            get { return isAvailible; }
            set { isAvailible = value; }
        }

        public void SetUnAvailible()
        {
            isAvailible = false;
        }

        public void SetClient(Client client)
        {
            this.person = client;
        }

    }
}
