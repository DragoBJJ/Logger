
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

            MySqlDataBase sqlDataBase = new();

            DataBaseLoggerStrategy dataBaseStrategy = new(sqlDataBase);
            FileLoggerStrategy fileStrategy = new(OWNER, FILE_PATH);
            EventLoggerStrategy eventStrategy = new(SYSTEM_EVENT_SOURCE);

            LoggerContext logger = new(dataBaseStrategy, fileStrategy);

            logger.addStrategy(StrategyKey.EVENT, eventStrategy);


            Console.WriteLine($"All Strategies in LoogerContext: {logger.getAllStrategyNames()}");


            logger.LogActivity(StrategyKey.FILE, 10, "Leonardo", "Doctor / Enginner", "I'm Leonardo Da Vinci !");
            logger.LogActivity(StrategyKey.EVENT, 1, "Leonardo", "Doctor / Enginner", "I'm Leonardo Da Vinci !");
            logger.LogActivity(StrategyKey.DATABASE, 10, "Leonardo", "Actor", "I'm Leonardo Da Vinci !");

            //logger.LogAllActivityStrategies(1, "Leonardo", "Doctor / Enginner", "I'm Leonardo Da Vinci !");



        }
    }

}