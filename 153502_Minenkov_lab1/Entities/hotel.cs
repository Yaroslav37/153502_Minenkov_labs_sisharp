using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _153502_Minenkov_lab1.Collections;

namespace _153502_Minenkov_lab1.Entities
{

    internal class Hotel
    {
        public delegate void ClientOrders(string LastName, uint RoomNumberr);
        public delegate void ClientHandler(string LastName);

        public event ClientOrders Orders;
        public event ClientHandler NotifyClients;

        public Hotel()
        {
            for (uint i = 1; i < 15; i++)
                roomList.Add(new Room(i));
            //Orders += (LastName,RoomNumber) => Console.WriteLine(LastName + " арендовал комнату № " + RoomNumber);
        }

        MyCustomCollection<Client> clientsList = new MyCustomCollection<Client>();
        MyCustomCollection<Room> roomList = new MyCustomCollection<Room>();

        public void AddClient(string LastName)
        {
            clientsList.Add(new Client(LastName));
            NotifyClients?.Invoke($"Client {LastName} added");
        }

        public void AddRoom(uint number, uint cost = 5)
        {
            roomList.Add(new Room(number, cost));
        }

        public void RentRoom(string clientLastName, uint number) {
            Client currentClient = findClient(clientLastName);

            if (currentClient == null)
            {
                Console.WriteLine("Такого клиента не существует!");
                return;
            }

            Room currentRoom = null;

            foreach (Room room in roomList)
            {
                if (room.Number == number)
                {
                    currentRoom = room;
                }
            }

            if (currentRoom == null)
            {
                Console.WriteLine("Такого номера не существует!");
                return;
            }

            if (currentRoom.IsAvailible)
            {
                currentClient.RentRoom(currentRoom);
                Orders?.Invoke(currentClient.LastName, currentRoom.Number);
            }
            else
            {
                Console.WriteLine("Номер " + currentRoom.Number + " недоступен для аренды!");
            }

        }

        public void PrintAvailibleRooms()
        {
            uint numberOfAvailibleRooms = 0;
            string availibleRooms = "";

            foreach(Room room in roomList)
            {
                if (room.IsAvailible)
                {
                    availibleRooms += room.Number + " ";
                    numberOfAvailibleRooms++;
                }
            }

            if (numberOfAvailibleRooms > 0) Console.WriteLine("Свободные комнаты: " + availibleRooms);
            else Console.WriteLine("Нет свободных комнат!");
        }

        public void PrintListOfClients()
        {
            if (clientsList.IsEmpty)
            {
                Console.WriteLine("Клиенты не найдены!");
                return;
            }

            int i = 0;

            foreach(Client client in clientsList)
            {
                i++;
                Console.WriteLine(i + ". " + client.LastName);
            }
        }

        private Client findClient(string LastName)
        {
            Client currentClient = null;
            foreach (Client client in clientsList)
            {
                if (client.LastName == LastName)
                {
                    currentClient = client;
                }
            }
            return currentClient;
        }

        public void printTotalCost(string LastName)
        {
            Client currentClient = findClient(LastName);
            if (currentClient == null)
            {
                Console.WriteLine("Клиент " + LastName + " не найден");
                return;
            }
            uint totalCost = 0;

            foreach(Room r in roomList)
            {
                if(r.Person == currentClient)
                {
                    totalCost += r.Cost;
                }
            }
            Console.WriteLine("Стоимость проживания " + LastName + " = " + totalCost);
        }

        //public void AddOrder(string LastName, uint RoomNumber)
        //{
        //    Console.WriteLine(LastName + " арендовал комнату № " + RoomNumber);
        //}

        public void GenerateIndexOutOfRangeException()
        {
            int lastElementIndex = clientsList.Count;
            Console.WriteLine(clientsList[lastElementIndex + 2].LastName);
        }

        public void GenerateRemoveException()
        {
            Client unknown = new Client("Unknown");
            clientsList.Remove(unknown);
        }
    }
}
