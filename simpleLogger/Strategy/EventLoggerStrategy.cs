using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using simpleLogger.Interfaces;

namespace simpleLogger.Strategy
{
    class EventLoggerStrategy : ILogger
    {

        readonly EventLog eventLog;
        private readonly string source;

        public EventLoggerStrategy(string source)
        {
            this.source = source;
            eventLog = new(this.source);
            eventLog.Source = this.source;
            eventLog.Log = this.source;
        }


        private void CreateEventLogMessage(string message)
        {
            try
            {
                using (EventLog eventLog = this.eventLog)
                {
                    eventLog.WriteEntry(message, EventLogEntryType.Information);

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

         void ReadEventLogs()
       {
           try {
                {
                    using (EventLog eventLog = this.eventLog)
                   
                    {
                        foreach (EventLogEntry entry in eventLog.Entries)
                        {

                            Console.WriteLine($" your Event Log from Source: {entry.Source}: {entry.Message}");


                        }
                    }
                }
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
       

         
        }

        private void DeleteEventLogMessage()
        {
            if (EventLog.Exists(this.source))
            {
                EventLog.Delete(this.source);
            }
        }

        public void Log(int userID, string name, string proffesion, string message)
        {
            string m = $"userID: {userID}, Name : {name}, Proffesion: {proffesion}, Message: {message}";
            CreateEventLogMessage(m);
        }
    }
}
