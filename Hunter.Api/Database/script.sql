create database HunterMovies;
go
use HunterMovies;
go
create table Actors(
   ID int primary key identity,
   Name varchar(90) not null,
   Birthday date,
   Sex char,
   Photo nvarchar(100),
   constraint check_sex
       check(Sex in ('m', 'w', 'o')) /*man, woman, other*/     
);
go
create table Genres(
   ID int primary key identity,
   Name varchar(90) not null
);
go
create table Movies(
   ID int primary key identity,
   Title varchar(90) not null,
   Genre int,
   ReleaseDate date,
   Photo nvarchar(100),
   constraint genre_fk foreign key(Genre) references Genres(ID)

);
go
create table Movies_Actors(
   ID_Movie int,
   ID_Actor int,
   constraint movie_actor_pk primary key(ID_Movie, ID_Actor),
   constraint movie_fk foreign key (ID_Movie) references Movies(ID),
   constraint actor_fk foreign key (ID_Actor) references Actors(ID)
);
go
create index name_actor_idx on Actors(Name);
go
create index name_movie_idx on Movies(Title);