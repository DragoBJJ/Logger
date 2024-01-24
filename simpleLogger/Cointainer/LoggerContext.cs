using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging.Abstractions;
using simpleLogger.Interfaces;
using simpleLogger.Strategy;



namespace simpleLogger;

class LoggerContext
{

    private readonly Dictionary<StrategyKey, ILogger> _strategies;

    private ILogger logger;


    public LoggerContext()
    {
        this._strategies = new Dictionary<StrategyKey, ILogger>();
    }

    public ILogger strategy
    {
      
        set
        {
            this.logger = value;
        }

    }

    public void LogActivity(int userID, string name, string proffesion, string messages)
    {
         this.logger.Log(userID, name, proffesion, messages);
    }

    public ILogger Strategy
    {

        set
        {
            this.strategy = value;
            this._strategies[value.GetID()] = value;
        }

        
    }

    public string GetAllStrategyNames()
    {
        var items = from strategy in _strategies select $"{strategy.Key} Strategy";
        return string.Join(", ", items);
    }
    public void LogActivityByKey(StrategyKey strategy, int userID, string name, string proffesion, string messages)
    {
        if (_strategies.TryGetValue(strategy, out var logger))
        {
            logger.Log(userID, name, proffesion, messages);
        }
        else
        {
            throw new NotSupportedException($"Strategy {strategy} doesn't exist");
        }


    }
    public void LogAllActivityStrategies(int userID, string name, string proffesion, string messages)
    {

        foreach (var logger in _strategies.Values)
        {
            logger.Log(userID, name, proffesion, messages);
        }

    }
}
