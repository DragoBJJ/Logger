ILogger
  |
  +-- Log(int userID, string name, string profession, string message)
  |
  +-- DataBaseLoggerStrategy
  |   |
  |   +-- MySqlDataBase
  |       |
  |       +-- Log(int userID, string name, string profession, string message)
  |
  +-- FileLoggerStrategy
  |   |
  |   +-- #owner: string
  |   |
  |   +-- #filePath: string
  |   |
  |   +-- Log(int userID, string name, string profession, string message)
  |
  +-- EventLoggerStrategy
      |
      +-- #systemEventSource: string
      |
      +-- Log(int userID, string name, string profession, string message)
  |
  +-- LoggerContext
      |
      +-- #dataBaseStrategy: DataBaseLoggerStrategy
      |
      +-- #fileStrategy: FileLoggerStrategy
      |
      +-- #selectedStrategy: ILogger
      |
      +-- addStrategy(key: StrategyKey, strategy: ILogger): void
      |
      +-- getAllStrategyNames(): string[]
      |
      +-- LogActivity(key: StrategyKey, userID: int, name: string, profession: string, message: string): void
      
