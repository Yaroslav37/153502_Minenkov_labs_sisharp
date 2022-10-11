using System;
using _153502_Minenkov_lab1.Entities;

namespace _153502_Minenkov_lab1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Hotel hotel = new Hotel();

            Journal journal = new Journal();

            hotel.NotifyClients += journal.AddWorker;
            hotel.Orders += (LastName, RoomNumber) => Console.WriteLine(LastName + " арендовал комнату № " + RoomNumber);

            hotel.PrintListOfClients();

            hotel.AddClient("Minenkov");
            hotel.RentRoom("Minenkov", 7);
            hotel.RentRoom("Minenkov", 7);
            hotel.RentRoom("Minenkov", 1);
            hotel.RentRoom("Minenkov", 2);
            hotel.RentRoom("Minenkov", 3);
            hotel.RentRoom("Minenkov", 5);

            hotel.printTotalCost("Minenkov");
            hotel.printTotalCost("Bogomolov");

            hotel.AddClient("Petrov");
            hotel.PrintListOfClients();
            hotel.PrintAvailibleRooms();

            hotel.GenerateIndexOutOfRangeException();
            hotel.GenerateRemoveException();

            Console.WriteLine("-------------------------------");
            journal.printInfoAboutAddedClients();
        }
    }
}
