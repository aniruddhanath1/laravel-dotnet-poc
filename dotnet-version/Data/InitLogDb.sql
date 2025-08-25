-- SQLite schema for logging exceptions
CREATE TABLE IF NOT EXISTS Exceptions (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    Message TEXT NOT NULL,
    StackTrace TEXT,
    Context TEXT,
    CreatedAt TEXT NOT NULL
);
