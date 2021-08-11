CREATE DATABASE CS486_Team12_DB
GO

USE CS486_Team12_DB
GO

CREATE TABLE Genres
(
    ID INT PRIMARY KEY,
    name NVARCHAR(50),
    RID INT
);

CREATE TABLE Regions
(
    ID INT PRIMARY KEY,
    name NVARCHAR(50),  
);

CREATE TABLE Songs
(
    ID INT,
    name NVARCHAR(100),
    GID INT,
    streamCount INT,
    dateAdded DATE
);

CREATE TABLE Singers
(
    ID INT PRIMARY KEY,
    name NVARCHAR(50)
)