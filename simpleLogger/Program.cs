
using System;
using System.IO;
using System.Configuration;
using simpleLogger.Strategy;
using simpleLogger.Database;

namespace simpleLogger
{
    class Program
    {
        static void Main(string[] args)
        {

            string OWNER = "YOUR_FOLDER_NAME";
            string FILE_PATH = $"C:\\Users\\{OWNER}\\Desktop";
            string SYSTEM_EVENT_SOURCE = "Application";

            DataBase SqlDataBase = new();

            DataBaseLoggerStrategy dataBaseStrategy = new(SqlDataBase);
            EventLoggerStrategy eventStrategy = new(SYSTEM_EVENT_SOURCE);
            FileLoggerStrategy fileStrategy = new(OWNER, FILE_PATH);

            LoggerContext logger = new()
            {
                Strategy = fileStrategy
            };

            logger.LogActivity(1, "Leonardo", "Doctor / Enginner", "I'm Leonardo Da Vinci !");

            Console.WriteLine($"All Strategies in LoggerContext: {logger.GetAllStrategyNames()}");


           logger.LogActivityByKey(StrategyKey.FILE, 10, "Leonardo", "Doctor / Enginner", "I'm Leonardo Da Vinci !");
           //logger.LogActivityByKey(StrategyKey.EVENT, 1, "Leonardo", "Doctor / Enginner", "I'm Leonardo Da Vinci !");

           logger.LogAllActivityStrategies(1, "Leonardo", "Doctor / Enginner", "I'm Leonardo Da Vinci !");

        }
    }

}