using System;
using System.IO;
using NLog.Web;

namespace ml_latest_small
{
    class Program
    {
        static void Main(string[] args)
        {
            // create instance of Logger
            string path = Directory.GetCurrentDirectory() + "\\nlog.config";
            var logger = NLog.Web.NLogBuilder.ConfigureNLog(path).GetCurrentClassLogger();

            logger.Info("Program started");

            string file = "ml-latest-small/movies.csv";
            string choice = "0";
            if(File.Exists(file)){
                do{
                    // ask user a question
                    Console.WriteLine("1) Show movie list.");
                    Console.WriteLine("2) Add a movie.");
                    Console.WriteLine("Enter any other key to exit.");
                    // input response
                    choice = Console.ReadLine();

                    if(choice == "1"){
                        //display movies
                        StreamReader sr = new StreamReader(file);
                        string line = "";
                        Console.WriteLine("Movie Title");

                        while(!sr.EndOfStream){
                            line = sr.ReadLine();
                            string[] arr = line.Split(',');
                            string display = "";
                            for(int i = 0; i<(arr.Length-2); i++){
                                if(i==0){
                                    display += arr[i+1];
                                } else{
                                    display += "," + arr[i+1];
                                }
                            }
                            Console.WriteLine(display);
                        }
                        sr.Close();
                    } else if(choice == "2"){
                        StreamReader sr = new StreamReader(file);

                        //the movie string that will be written to the file
                        string newMovie = "";
                        //the movie name that the user inputs
                        string movieName = "";
                        //check if the name is a duplicate
                        Boolean isNotDuplicate = true;
                        //add a max id check
                        string maxId = "0";
                        //add new id
                        int newId = 0;
                        //add name
                        Console.WriteLine("Enter the name of the new movie:");
                        movieName = Console.ReadLine();

                        //loop through the file
                        while(!sr.EndOfStream){
                            string line = sr.ReadLine();
                            string[] arr = line.Split(',');
                            string nameCheck = "";
                            for(int i = 0; i<(arr.Length-2); i++){
                                if(i==0){
                                    nameCheck += arr[i+1];
                                } else{
                                    nameCheck += ", " + arr[i+1];
                                }
                            }
                            //check for duplicate names
                            if(nameCheck == movieName){
                                isNotDuplicate = false;
                            }
                            //set the max id (the last one should be saved and that would be the max)
                            maxId = arr[0];
                        }

                        if(isNotDuplicate){
                            //set the new id
                            newId = Int32.Parse(maxId) + 1;
                            //add the name and id to what will be added to the file
                            newMovie = newId + "," + movieName + ",";

                            //add genres
                            Boolean numberCheck = true;
                            int numGenres = 1;
                            //get how many genres are being added to the movie
                            do
                            {
                                if(numberCheck){
                                    Console.WriteLine("How many genres does this movie have?");
                                } else{
                                    Console.WriteLine("Your input was not a number.  How many genres does this movie have?");
                                }
                                string input = Console.ReadLine();
                                numberCheck = Int32.TryParse(input, out numGenres);
                            } while (!numberCheck);
                            //get the genres from user
                            if(numGenres == 0){
                                newMovie += "(no genres listed)";
                            }
                            for(int i = 0; i<numGenres; i++){
                                Console.WriteLine("What is a genre for this movie?");
                                if(i == (numGenres - 1)){
                                    newMovie += Console.ReadLine();
                                } else {
                                    newMovie += Console.ReadLine() + "|";
                                }
                            }

                            sr.Close();
                            //write to the file
                            StreamWriter sw = new StreamWriter(file, true);
                            sw.WriteLine(newMovie);
                            sw.Close();
                        } else{
                            sr.Close();
                            logger.Warn("Duplicate Movie!!");
                            //Console.WriteLine("That movie is already here.");
                        }
                    }
                }while (choice =="1" || choice == "2");
            }else{
                logger.Warn("File Does not exist.");
            }
            logger.Info("Program ended");
        }
    }
}
