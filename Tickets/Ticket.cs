using System;
using System.IO;

namespace Tickets
{
    class Program
    {
        static void Main(string[] args)
        {
            string file = "ticket.csv";
            string choice;
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
                    if (File.Exists(file))
                    {
                        // read data from file
                        StreamReader sr = new StreamReader(file);
                        while (!sr.EndOfStream)
                        {
                            string line = sr.ReadLine();
                            // convert string to array
                            string[] arr = line.Split(',');
                            string[] watching = arr[6].Split('|');

                            // display information
                            String display = (arr[0]+", "+arr[1]+", "+arr[2]+", "+arr[3]+", "+arr[4]+", "+arr[5]+", Watching:");

                            for(int i = 0;i<watching.Length;i++){
                                if(i==watching.Length-1){
                                    display = display+watching[i];
                                }else{
                                    display = display + watching[i] + ", ";
                                }
                            }
                            Console.WriteLine(display);
                        }
                        sr.Close();
                    }
                    else
                    {
                        Console.WriteLine("File does not exist");
                    }
                }
                //working here
                else if (choice == "2")
                {

                    if (File.Exists(file))
                    {
                        //the new ticket that will be appended to the file
                        String newTicket = "";
                        String watchingChoice;
                        //String lastIDS = "";
                        StreamWriter sw = new StreamWriter(file, true);
                        //StreamReader sr = new StreamReader(file);

                        //get the data
                        Console.WriteLine("Enter the ID of the ticket.");
                        newTicket += Console.ReadLine() + ",";
                        Console.WriteLine("Enter the summary of the ticket.");
                        newTicket += Console.ReadLine() + ",";
                        Console.WriteLine("Enter the status of the ticket.");
                        newTicket += Console.ReadLine() + ",";
                        Console.WriteLine("Enter the priority of the ticket.");
                        newTicket += Console.ReadLine() + ",";
                        Console.WriteLine("Enter the submitter of the ticket.");
                        newTicket += Console.ReadLine() + ",";
                        Console.WriteLine("Who is assigned the ticket.");
                        newTicket += Console.ReadLine() + ",";

                        //loop to get who is watching
                        do
                        {
                            Console.WriteLine("Enter someone who is watching.");
                            newTicket += Console.ReadLine();
                            Console.WriteLine("Are there more people watching Y/N.");
                            watchingChoice = Console.ReadLine();
                            if(watchingChoice.Equals("Y")||watchingChoice.Equals("y")){
                                newTicket += "|";
                            }
                        } while (watchingChoice.Equals("y")||watchingChoice.Equals("Y"));
                        Console.WriteLine(newTicket);
                        sw.WriteLine(newTicket);
                        sw.Close();
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
