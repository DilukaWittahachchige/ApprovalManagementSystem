--
-- File generated with SQLiteStudio v3.3.3 on Tue Nov 23 15:02:35 2021
--
-- Text encoding used: System
--
PRAGMA foreign_keys = off;
BEGIN TRANSACTION;

-- Table: ApprovelInfo
DROP TABLE IF EXISTS ApprovelInfo;

CREATE TABLE ApprovelInfo (
    Id         INTEGER NOT NULL
                       PRIMARY KEY AUTOINCREMENT,
    ManagerId  INTEGER REFERENCES [Users ] (Id) ON DELETE RESTRICT
                       NOT NULL,
    RequestId  INTEGER REFERENCES RequestInfo (Id) ON DELETE RESTRICT
                       NOT NULL,
    IsApproved BOOLEAN NOT NULL,
    Comment    STRING  NOT NULL
);


-- Table: RequestInfo
DROP TABLE IF EXISTS RequestInfo;

CREATE TABLE RequestInfo (
    Id           INTEGER NOT NULL
                         PRIMARY KEY AUTOINCREMENT,
    CreateUserId INTEGER NOT NULL
                         REFERENCES [Users ] (Id) ON DELETE RESTRICT,
    RequestInfo  STRING  NOT NULL,
    Status       BOOLEAN NOT NULL
);


-- Table: Users 
DROP TABLE IF EXISTS [Users ];

CREATE TABLE [Users ] (
    Id           INTEGER NOT NULL
                         PRIMARY KEY AUTOINCREMENT,
    Name         STRING  NOT NULL,
    EmailAddress STRING  NOT NULL,
    Position     STRING  NOT NULL,
    IsActive     BOOLEAN NOT NULL
);


COMMIT TRANSACTION;
PRAGMA foreign_keys = on;
