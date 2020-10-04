using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Tickets
{
    public class TicketFile
    {
        public String filePath {get;set;}
        public List<Tickets> Tickets {get;set;}

        public TicketFile(string ticketFilePath){
            filePath = ticketFilePath;
            Tickets = new List<Tickets>();

            try{
                StreamReader sr = new StreamReader(filePath);
                sr.ReadLine();
                while(!sr.EndOfStream){
                    Tickets ticket = new Tickets();
                    String line = sr.ReadLine();

                    String[] ticketSplit = line.Split(',');
                    String[] watching = ticketSplit[6].Split('|');
                    ticket.ticketId = ticketSplit[0];
                    ticket.summary = ticketSplit[1];
                    ticket.status = ticketSplit[2];
                    ticket.priority = ticketSplit[3];
                    ticket.submitter = ticketSplit[4];
                    ticket.assigned = ticketSplit[5];
                    for(int i = 0; i<watching.Length; i++){
                        ticket.watching.Add(watching[i]);
                    }
                    Tickets.Add(ticket);
                }
                sr.Close();
            } catch {

            }
        }


        public void AddTicket(Tickets ticket){
            StreamWriter sw = new StreamWriter(filePath, true);

            sw.WriteLine($"{ticket.ticketId}, {ticket.summary}, {ticket.status}, {ticket.priority}, {ticket.submitter}, {ticket.assigned}, {String.Join("|",ticket.watching)}");
            Tickets.Add(ticket);

            sw.Close();
        }
    }
}
