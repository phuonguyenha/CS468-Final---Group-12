﻿CREATE DATABASE CS486_Team12_DB
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
    streamCount INT CHECK(streamCount >= 0),
    dateAdded DATE,
    PRIMARY KEY(ID, GID)
);

create table SingerofSongs
(
	SongID int,
	SingerID int
	primary key (SongID,SingerID)
);

ALTER TABLE SingerofSongs ADD
CONSTRAINT FK_SingerofSongs_SongID
FOREIGN KEY(SongID) REFERENCES Songs(ID);

ALTER TABLE SingerofSongs ADD
CONSTRAINT FK_SingerofSongs_Singers
FOREIGN KEY(SongID) REFERENCES Singers(ID);



CREATE TABLE Singers
(
    ID INT PRIMARY KEY,
    name NVARCHAR(50)
);
GO

create table playlists
(
	ID int primary key,
	name nvarchar(50)
);
go

create table SongofPlaylists
(
	PlID int,
	SongID int,
	primary key(PlID,SongID)
);
go



ALTER TABLE Genres ADD
CONSTRAINT FK_GENRES_REGIONS
FOREIGN KEY(RID) REFERENCES Regions(ID);

ALTER TABLE Songs ADD
CONSTRAINT FK_SONGS_GENRES
FOREIGN KEY(GID) REFERENCES GENRES(ID);

Alter table SongofPlaylists add
constrant fk_SongofPlaylist_pl
foreign key(PlID) references playlists(ID)

Alter table SongofPlaylists add
constrant fk_SongofPlaylist_song
foreign key(SongID) references Songs(ID)

GO

USE MASTER
DROP DATABASE CS486_Team12_DB;


insert into Regions
values 
	(1,'Việt Nam'),
	(2,'Âu Mỹ'),
	(3,'Châu Á'),
	(4,'Khác');


insert into Genres
values 
	(1, 'Nhạc Trẻ', 1),
	(2,'Trữ Tình',1),
	(3,'Remix Việt',1),
	(4,'Rap Việt',1),
	(5,'Tiền Chiến',1),
	(6,'Nhạc Trịnh',1),
	(7,'Pop',2),
	(8,'Rock',2),
	(9,'Electronica',2),
	(10,'R&B',2),
	(11,'Blues',2),
	(12,'Latin',2),
	(13,'Nhạc Hàn',3),
	(14,'Nhạc Hoa',3),
	(15,'Nhạc Nhật',3),
	(16,'Nhạc Thái',3),
	(17,'Beat',4),
	(18,'Không lời',4),
	(19,'Thể loại khác',4),
	(20,'Tui hát',4);


CREATE TABLE Songs
(
    ID INT,
    name NVARCHAR(100),
    GID INT,
    streamCount INT CHECK(streamCount >= 0),
    dateAdded DATE,
    PRIMARY KEY(ID, GID)
);


insert into Songs
values
	(1,'Nơi này có anh',1,200,'20/11/2011'),
	(2,'Nắng ấm xa dần',1,200,'20/11/2011'),
	(3,'Em của ngày hôm qua',1,200,'20/11/2011'),
	(4,'TheNights',2,200,'20/11/2011');

insert into Singers
values
	(1,'Sơn Tùng'),
	(2,'No name');

insert into SingerofSongs
values
	(1,1),
	(2,1),
	(3,1),
	(4,2);

insert into playlists
values
	(1,'My playlist')

insert into SongofPlaylists
values
	(1,1);

	đasa


