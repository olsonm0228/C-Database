using System;
using System.IO;
using NLog.Web;

namespace sleepData
{
    class Program
    {
        static void Main(string[] args)
        {
            // create instance of Logger
            string path = Directory.GetCurrentDirectory() + "\\nlog.config";
            var logger = NLog.Web.NLogBuilder.ConfigureNLog(path).GetCurrentClassLogger();

            logger.Info("Program started");

            // ask for input
            Console.WriteLine("Enter 1 to create data file.");
            Console.WriteLine("Enter 2 to parse data.");
            Console.WriteLine("Enter anything else to quit.");
            // input response
            string resp = Console.ReadLine();

            if (resp == "1"){
                // create data file

                 // ask a question
                Console.WriteLine("How many weeks of data is needed?");
                // input the response (convert to int)
                int weeks = int.Parse(Console.ReadLine());
                // determine start and end date
                DateTime today = DateTime.Now;
                // we want full weeks sunday - saturday
                DateTime dataEndDate = today.AddDays(-(int)today.DayOfWeek);
                // subtract # of weeks from endDate to get startDate
                DateTime dataDate = dataEndDate.AddDays(-(weeks * 7));

                // random number generator
                Random rnd = new Random();
                // create file
                StreamWriter sw = new StreamWriter("data.txt");

                // loop for the desired # of weeks
                while (dataDate < dataEndDate)
                {
                    // 7 days in a week
                    int[] hours = new int[7];
                    for (int i = 0; i < hours.Length; i++)
                    {
                        // generate random number of hours slept between 4-12 (inclusive)
                        hours[i] = rnd.Next(4, 13);
                    }
                    // M/d/yyyy,#|#|#|#|#|#|#
                    //Console.WriteLine($"{dataDate:M/d/yy},{string.Join("|", hours)}");
                    sw.WriteLine($"{dataDate:M/d/yyyy},{string.Join("|", hours)}");
                    // add 1 week to date
                    dataDate = dataDate.AddDays(7);
                }
                sw.Close();
            }else if (resp == "2"){
                string nextLine;
                DateTime currentDay;
                double currentAve;
                int currentTotal;

                using(StreamReader sr = new StreamReader("data.txt")){
                    while((nextLine = sr.ReadLine()) != null){
                        string[] splitData = nextLine.Split(',');
                        string[] sleepHours = splitData[1].Split('|');
                        currentDay = Convert.ToDateTime(splitData[0]);
                        currentAve = 0;
                        currentTotal = 0;
                        for (int i = 0; i < sleepHours.Length; i++)
                        {
                            currentTotal += Int32.Parse(sleepHours[i]);
                        }
                        currentAve = currentTotal/7.0;
                        //need first 3 letters of month then ,
                        Console.WriteLine($"Week of {currentDay:MMM}, {currentDay:dd, yyyy}");
                        Console.WriteLine($" Su Mo Tu We Th Fr Sa Tot Avg");
                        Console.WriteLine($" -- -- -- -- -- -- -- --- ---");
                        Console.WriteLine($" {sleepHours[0],2} {sleepHours[1],2} {sleepHours[2],2} {sleepHours[3],2} {sleepHours[4],2} {sleepHours[5],2} {sleepHours[6],2} {currentTotal,3} {currentAve,2:F1}");
                        Console.WriteLine($"");

                    }
                }
            }
            logger.Info("Program ended");
        }
    }
}
