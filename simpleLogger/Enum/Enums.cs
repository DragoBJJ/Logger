using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simpleLogger;

public enum StrategyKey : byte
{
    DATABASE = 1,
    FILE = 2,
    EVENT = 3,
}
