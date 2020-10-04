using System;
using System.IO;
//test
namespace Tickets
{
    class Program
    {
        static void Main(string[] args)
        {
            string file = "ticket.csv";
            string choice;
            TicketFile ticketFile = new TicketFile(file);
            do
            {
                // ask user a question
                Console.WriteLine("1) Read data from file.");
                Console.WriteLine("2) Update data in file.");
                Console.WriteLine("Enter any other key to exit.");
                // input response
                choice = Console.ReadLine();
                if (choice == "1")
                {
                    foreach(Tickets t in ticketFile.Tickets){
                        Console.WriteLine(t.Display());
                    }
                }
                else if (choice == "2")
                {

                    if (File.Exists(file))
                    {
                        Tickets ticket = new Tickets();
                        String watchingChoice;
                       //get the data
                        Console.WriteLine("Enter the ID of the ticket.");
                        ticket.ticketId = Console.ReadLine();
                        Console.WriteLine("Enter the summary of the ticket.");
                        ticket.summary = Console.ReadLine();
                        Console.WriteLine("Enter the status of the ticket.");
                        ticket.status = Console.ReadLine();
                        Console.WriteLine("Enter the priority of the ticket.");
                        ticket.priority = Console.ReadLine();
                        Console.WriteLine("Enter the submitter of the ticket.");
                        ticket.submitter = Console.ReadLine();
                        Console.WriteLine("Who is assigned the ticket.");
                        ticket.assigned= Console.ReadLine();

                        //loop to get who is watching
                        do
                        {
                            Console.WriteLine("Enter someone who is watching.");
                            ticket.watching.Add(Console.ReadLine());
                            Console.WriteLine("Are there more people watching Y/N.");
                            watchingChoice = Console.ReadLine();
                        } while (watchingChoice.Equals("y")||watchingChoice.Equals("Y"));
                        ticketFile.AddTicket(ticket);
                    }
                    else
                    {
                        Console.WriteLine("File does not exist");
                    }
                }
            } while (choice == "1" || choice == "2");
        }
    }
}
