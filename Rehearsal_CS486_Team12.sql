Create database CS486_Team12_DB
Go

USE CS486_Team12_DB
GO

Create table Songs
(
	songID int primary key,
	songName NVARCHAR(50),
	genre NVARCHAR(50),
	region NVARCHAR(50),
	dateAdded DATE,
	streamCount INT,
);

CREATE TABLE SingerSongs
(
	singerID int, 
	songID int,
	primary key(singerID, songID)
)

Create table Singers
(
	singerID int primary key,
	singerName nvarchar(50),
)

CREATE TABLE SongsOfPlaylist
(	
	playlistID int,
	songID int,
	primary key(songID,playlistID),
	favorites BIT check(Favorites = 0 OR Favorites = 1)
)

CREATE TABLE Playlists
(
	playlistID int primary key,
	userID int,
	playlistName NVARCHAR(50)
)

CREATE TABLE Users
(
	userID int primary key,
	userName NVARCHAR(50),
	sex CHAR(1) CHECK (Sex IN ('M', 'F', 'U')),
	age INT CHECK(Age > 15 AND Age < 80)
);

GO

ALTER TABLE Playlists ADD
CONSTRAINT FK_Playlists_userID FOREIGN KEY(userID) REFERENCES Users(UserID);

Alter table SingerSongs add
Constraint FK_SingerSong_SongID foreign key(SongID) references Songs(SongID)

Alter table SongsOfPlaylist add
Constraint FK_SongsOfPlaylist_Playlists foreign key(playlistID) references Playlists(playlistID)
go

INSERT INTO Singers (singerID, singerName) VALUES
(1, 'Maroon 5'),
(2, 'Rihanna'),
(3, 'Taylor Swift');

insert into Songs (songID, songName, genre, region, dateAdded, streamCount) values
(1, 'Sugar', 'Pop', 'Âu - Mỹ', '1-1-2000', 1000000),
(2, 'Monster', 'R&B/Hip Hop/ Rap', 'Âu - Mỹ', '1-2-2000', 600000),
(3, 'You belong with me', 'Pop',  'Âu - Mỹ', '1-1-2001', 600000);

INSERT INTO SingerSongs(singerID, songID) VALUES
(1, 1),
(2, 2),
(3, 3);

Insert into Users(userID, userName, Sex, Age)Values
(1,'Nguyen Van A', 'M', 20),
(2,'Nguyen Van B', 'F', 20);

Insert into playlists(playlistID,playlistName, userID)values
(1,'Playlist1',1),
(2,'Playlist2',2),
(3,'Playlist3',1),
(4,'Playlist4',2);

insert into SongsOfPlaylist(playlistID, songID, Favorites) values
(1,1,1),
(1,2,0),
(2,1,1), 
(2,2,0);
GO

CREATE OR ALTER procedure sp_selectMoiNhat(@playlistid INT, @genre NVARCHAR(50))
AS
BEGIN
	SELECT s.songName, sng.singerName, s.streamCount, s.dateAdded, sp.favorites
	FROM playlists p JOIN SongsOfPlaylist sp ON p.playlistID = sp.playlistID
	JOIN Songs s ON sp.songID = s.songID JOIN SingerSongs ss ON s.songID = ss.songID
	JOIN Singers sng ON ss.singerID = sng.singerID
	WHERE p.playlistID = @playlistid AND s.genre = @genre
END
GO

CREATE OR ALTER PROCEDURE sp_updatePlaylist(@playlistid INT, @songid INT, @favorites BIT)
AS
BEGIN TRY
	BEGIN TRANSACTION
		if not exists(
			select *
			from playlists
			where playlistID = @playlistid
		)
		BEGIN
			--RAISERROR('There is no such playlistid', 16, 1);
			-- ROLLBACK;
			THROW 50001,'There is no such playlistid', 1;
		END

		if not exists(
			select *
			from songs
			where songID = @songid
		)
		BEGIN
			--RAISERROR('There is no such songid', 16, 1);
			-- ROLLBACK;
			THROW 50002,'There is no such songid', 1;
		END

		if exists(
			select *
			from SongsOfPlaylist
			where songID = @songid and playlistID = @playlistid
		)
		BEGIN
			--RAISERROR('Song is already in playlist', 16, 1);
			-- ROLLBACK;
			THROW 50003,'Song is already in playlist', 1;
		END

		insert into SongsOfPlaylist(playlistID, songID, Favorites)
		values (@playlistid, @songid, @favorites);
	COMMIT TRANSACTION
	RETURN 1;
END TRY
BEGIN CATCH
	ROLLBACK;
	--RAISERROR('Something is wrong', 16, 1);
	THROW
END CATCH
GO

Select * from playlists

-- select * from SongsOfPlaylist where playlistID = 1
-- exec sp_updatePlaylist 1, 3, 1

-- delete from SongsOfPlaylist where songid = 3

-- USE MASTER
-- DROP DATABASE CS486_Team12_DB
