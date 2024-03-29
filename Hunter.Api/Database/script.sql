﻿create database HunterMovies;
go
use HunterMovies;
go
create table Actors(
   Id int primary key identity,
   Name varchar(90) not null,
   Birthday date,
   Sex char,
   Photo nvarchar(100),
   constraint check_sex
       check(Sex in ('m', 'w', 'o')) /*man, woman, other*/     
);
go
create table Genres(
   Id int primary key identity,
   Name varchar(90) not null
);
go
create table Movies(
   Id int primary key identity,
   Title varchar(90) not null,
   GenreId int,
   ReleaseDate date,
   Photo nvarchar(100),
   constraint genre_fk foreign key(GenreId) references Genres(ID)

);
go
create table Movies_Actors(
   MovieId int,
   ActorId int,
   constraint movie_actor_pk primary key(MovieId, ActorId),
   constraint movie_fk foreign key (MovieId) references Movies(ID),
   constraint actor_fk foreign key (ActorId) references Actors(ID)
);
go
create index name_actor_idx on Actors(Name);
create index name_movie_idx on Movies(Title)
go
insert into actors values('Harold Cordero', sysdatetime(), 'm', 'harold.jpg');
insert into actors values('Miguel Rondon', sysdatetime(), 'm', 'miguel.jpg');
insert into genres values('Horror')
insert into genres values('Comedy')
insert into movies values('Scary Movie', 1, sysdatetime(), 'scary.jpg')
insert into movies values('King Kong', 2, sysdatetime(), 'king.jpg')