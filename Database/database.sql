CREATE TABLE `Projects` (
                    `Id`	INTEGER PRIMARY KEY AUTOINCREMENT UNIQUE,
                    `ProjectName`	TEXT(100),
                    `ProjectId`	TEXT(100),
                    `Version`	TEXT(100),
                    `LastDeployAtUtc`	INTEGER
                    )

CREATE TABLE `Logs` (
                    `Id`	INTEGER PRIMARY KEY AUTOINCREMENT UNIQUE,
                    `ProjectId`	TEXT(100),
                    `ProjectVersion`	TEXT(100),
                    `LogText`	TEXT,
                    `CreatedAtUtc`	INTEGER
                    )

CREATE TABLE `Environments` (
                    `Id`	INTEGER PRIMARY KEY AUTOINCREMENT UNIQUE,
                    `Name`	TEXT(100),
                    `Destination`	TEXT(255)
                    )

CREATE TABLE `BuildSteps` (
                    `Id`	INTEGER PRIMARY KEY AUTOINCREMENT UNIQUE,
                    `EnvironmentId`	INTEGER,
                    `Application` TEXT(255),
					`Arguments` TEXT(255)
                    )