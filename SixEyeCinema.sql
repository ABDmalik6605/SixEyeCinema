use Six_Eye_Cinema

--create database Six_Eye_Cinema
-- Create table timeslot
CREATE TABLE timeslot (
    Id char(5) PRIMARY KEY,
    Time_slot TIME
);
--create table age rating
create table ageRating(
 ArId varchar(15) primary Key,
 ageRest int 
);
-- Create table movies
CREATE TABLE movies (
	Mid int PRIMARY KEY,
	Mname varchar(50) Unique,
	Genre varchar(50),
	Age_limit varchar(15),
);
ALTER TABLE movies ADD CONSTRAINT FK_Screen FOREIGN KEY (Age_limit) REFERENCES AgeRating(ArID) ON UPDATE CASCADE ON DELETE CASCADE
ALTER TABLE movies ADD picture varchar(30) 
-- Create table screens
CREATE TABLE screens (
    Scid char(5) PRIMARY KEY,
    T_seats INT,
    price INT,
);
-- Create table shows
CREATE TABLE shows (
	Mid int ,
	Screen char(5),
	Mdate date,
	Time_slotId char(5),
	B_seats INT check (B_seats>=0),
	PRIMARY KEY(Screen,Mdate,time_slotId),
	foreign key (Time_slotId) references timeslot on update cascade on delete cascade,
	foreign key (Mid) references movies on update cascade on delete cascade,
	foreign key (Screen) references screens on update cascade on delete cascade
);
--ALTER TABLE movies ALTER COLUMN Screen CHAR(5);
--ALTER TABLE movies ADD CONSTRAINT FK_Screen FOREIGN KEY (Screen) REFERENCES screens(Scid) ON UPDATE CASCADE ON DELETE CASCADE
-- Create table addons
CREATE TABLE addons (
    Id char(5) PRIMARY KEY,
    Add_name VARCHAR(50),
    price INT
);

-- Create table user
CREATE TABLE Users (
    Uid int PRIMARY KEY,
    Name VARCHAR(50),
	DateOfBirth date,
    Email VARCHAR(50),
    Password VARCHAR(50),
    Phone char(11),
);
--Create table history
Create table history(
	UID int,
	MID int,
	PRIMARY KEY (mid, uid),
    FOREIGN KEY (Mid) REFERENCES movies(Mid) on delete cascade on update cascade,
    FOREIGN KEY (Uid) REFERENCES Users(uid)on delete cascade on update cascade
);
-- Create table rating
CREATE TABLE rating (
    Mid int ,
    Uid int ,
    Rating float check (rating>=0 and rating <6),
    Reviewtext VARCHAR(50),
    PRIMARY KEY (mid, uid),
    FOREIGN KEY (Mid) REFERENCES movies(Mid) on delete cascade on update cascade,
    FOREIGN KEY (Uid) REFERENCES Users(uid)on delete cascade on update cascade
);--drop table coming_soon
-- Create table coming_soon
CREATE TABLE coming_soon (
    Cid int PRIMARY KEY,
    Name VARCHAR(50),
    Genre varchar(50),
	Age_limit varchar(15),
	picture varchar(30)
);
-- Create table booking
CREATE TABLE booking (
    Uid int,
    Mid int,
    Scid char(5),
	Book_date date,
	time_slotId char(5),
	Tickets int check (Tickets>0),
	TotalPrice int,
    PRIMARY KEY (uid, mid, scid),
    FOREIGN KEY (uid) REFERENCES users(uid)on delete cascade on update cascade,
    FOREIGN KEY (mid) REFERENCES movies(mid) on delete cascade on update cascade,
    FOREIGN KEY (scid) REFERENCES screens(scid) on delete cascade on update cascade,
);
insert into ageRating values('R-rated',18)
insert into ageRating values('PG-13',13)
--TimeSlot
insert into timeslot values ('Slot1','02:30:00')
insert into timeslot values ('Slot2','08:30:00')
--screens
insert into screens values ('SCID1','200','1500')
insert into screens values ('SCID2','250','1000')
insert into screens values ('SCID3','300','500')
--movies
insert into movies values ('1','Oppenheimer','History/Biography','R-rated','oppie.jpg')
insert into movies values ('2','The Dark knight','Fiction/Action/Thriller','PG-13','TDK.jpg')
insert into movies values ('3','Zack Snyder Justice League','Fiction/Action/Serios','R-rated','JLScut.jpg')
insert into movies values ('34','Breaking Bad','Action/Crime/Drugs','PG-13','BB.jpg')
insert into movies values ('65','Dragon Ball: Fusion Reborn','Shonen/Action/Fight','R-rated','rename.jpg')
--delete from movies
--shows
insert into shows values ('1','SCID1','05-24-2024','Slot1','80')
insert into shows values ('2','SCID2','05-24-2024','Slot2','65')
insert into shows values ('3','SCID3','05-25-2024','Slot1','40')
insert into shows values ('34','SCID1','05-25-2024','Slot2','55')
insert into shows values ('65','SCID2','05-26-2024','Slot1','60')
--addons
insert into addons values ('Add01','Popcorn','200')
insert into addons values ('Add02','Lays','100')
insert into addons values ('Add03','Hotdog','250')
insert into addons values ('Add04','Fries','100')
insert into addons values ('Add05','Drink','100')
--users
/*insert into users values ('UID01','Gege Akutami','01-01-1992','SukunaKaisen@gojomail.com','Nanami','1231231231','0')
insert into users values ('UID02','Bruce Wayne','01-01-1992','Vengence@batmail.com','Im Batman','1231231232','1')
insert into users values ('UID03','Akira Toriyama','05-04-1955','Shenran@dragonmail.com','Kamehameha','123123123','1')
insert into users values ('UID04','Levi ackerman','01-10-2012','AttackOnTitan@shiganshinamail.com','NoRegrets','123123124','0')
insert into users values ('UID05','Andrew Tate','01-01-1987','Chad@sigmamail.com','BreathAir','123123125','1')
insert into users values ('UID06','Abdullah Malik','04-12-2005','Abdullah@malikmail.com','123456','123123126','0')*/
--rating
insert into rating values ('MID04','UID03','5','Nice but dragon ball wali baat nhi')
insert into rating values ('MID02','UID06','5','Im Batman')
insert into rating values ('MID01','UID06','5','I am become Death the destroyer of worlds')
insert into rating values ('MID04','UID01','2','Sirf aik banda mara?')
delete from rating where mid='MID04' and uid='UID01'
insert into rating values ('MID01','UID03','5','Badi fazool movie hai')
--coming_soon
insert into coming_soon values ('11','Deadpool and Wolverine','Fiction/Action/Thriller','R-rated','Deadpool.jpeg')
insert into coming_soon values ('12','Gojo vs Sukuna','Fiction/Thriller/Action/Suspense','R-rated','sukuna-vs-gojo.jpg')
insert into coming_soon values ('13','PEaky Blinders 7','History/Crime/Action','PG-13','Peaky Blinders.jpeg')
--booking
insert into booking values('UID06','MID04','SCID2','05-25-2024','Slot1',1,200)
delete from booking where uid='UID01' and mid='MID04'
insert into booking values('UID01','MID04','SCID1','05-25-2024','Slot2',3,200)
--history
insert into history values ('UID03','MID04')
insert into history values ('UID06','MID02')
insert into history values ('UID06','MID01')
delete from history where uid='UID01' and mid='MID04'
insert into history values ('UID03','MID01')
select * from movies
select * from shows
select * from timeslot
select * from screens
select * from addons
select * from rating
select * from Users
select * from coming_soon
select * from booking
select * from history
--Views
--1
create view Inshow as
select Mname as Movie_name,Screen,Mdate as Date,time_slotId as Time,genre,Age_limit from movies join shows on movies.Mid=shows.Mid
select * from inshow
--2
create view Upcoming as
select Name,Genre,Age_limit from coming_soon
select * from Upcoming
--3
create view members as
select name,email,phone from Users 
select * from members
--4
create view menu as
select Add_name as Add_ons,price from addons
select * from menu
--5
create view ratings as
select movies.Mname as Moviename,avg(rating) as rating,count(rating) as Total_ratings from rating join movies on rating.Mid=movies.Mid
group by movies.Mname
select * from ratings



-- tr1(Rating)
--drop trigger isWatched
create trigger isWatched on rating
instead of insert
as
declare @mid1 int
declare @uid1 int

select @mid1 = inserted.mid from inserted
select @uid1 = inserted.uid from inserted
--select datediff(day,'05-25-2024',getdate())
if exists ( select * from history where history.uid = @uid1 and history.mid= @mid1)
begin
	if (datediff(day,(select top 1 book_date from booking where uid=@uid1 and mid=@mid1 order by book_date),getdate())>0)
		insert into rating select mid,uid,rating, reviewtext from inserted
	else
		print(' you did not watch this particular movie ')
	end
else
print(' you did not watch this particular movie ')

--drop trigger Restrictions
--tr2 (Booking)
create trigger Restrictions on booking
instead of insert
as
declare @mid1 int
declare @db date

select @mid1=inserted.mid from inserted
select @db = [Users].dateofbirth from inserted join [Users] on inserted.uid = Users.Uid 
--select datediff(year,@db,getdate())
--from users where uid='UID01'
if (datediff(year,@db,getdate()) >= (select agerest from ageRating join movies on ageRating.ArId=movies.Age_limit where movies.Mid=@mid1 ))
begin 
	declare @sid char(5)
	declare @ts char(5)
	declare @moviedate date
	select @sid=inserted.Scid from inserted
	select @ts=inserted.time_slotId from inserted
	select @moviedate=inserted.Book_date from inserted
	if (@mid1 = (select mid from shows where Screen=@sid and Mdate=@moviedate and Time_slotId=@ts))
	begin
		declare @seats int
		select @seats=inserted.Tickets from inserted
		if((select T_seats from screens where Scid=@sid)-(select B_seats from shows where Screen=@sid and Mdate=@moviedate and Time_slotId=@ts)-@seats>0)
		begin
			insert into booking select uid,mid,scid,book_date,time_slotId,tickets,totalprice from inserted
			update shows set B_seats=B_seats+@seats where Screen=@sid and Mdate=@moviedate and Time_slotId=@ts
		end
		else 
			print(' Not enough seats are available')
	end
	else 
	print(' Movie not available ')
end
else
print(' You are under the age limit ')

--Tr(3) History
create trigger AddHistory on booking
After insert as 
insert into history select uid,mid from inserted

--tr4 (Cancel)
create trigger cancellation on booking
after delete
as
declare @mid1 int
declare @uid1 int
select @mid1=deleted.mid from deleted
select @uid1=deleted.uid from deleted
declare @sid char(5)
declare @ts char(5)
declare @moviedate date
select @sid=deleted.Scid from deleted
select @ts=deleted.time_slotId from deleted
select @moviedate=deleted.Book_date from deleted
declare @seats int
select @seats=deleted.Tickets from deleted
if(datediff(day,@moviedate,getdate())<0)
begin
	delete from history where uid=@uid1 and mid=@mid1
	update shows set B_seats=B_seats-@seats where Screen=@sid and Mdate=@moviedate and Time_slotId=@ts
end
--drop trigger cancellation
--select datediff(day,'04-05-2024',getdate())

use Six_Eye_Cinema
/*create procedure historyinsert
(
   @UID1 int,
   @MID1 int
)
as
begin
insert into history(UID,MID)
values(@UID1,@MID1)
end
delete from history where UID='UID06' and MID='MID01'*/
--drop procedure signup
--signup
create procedure signup
(
   @name varchar(50),
   @DOB date,
   @mail varchar(50),
   @pass varchar(50),
   @phone char(11),
   @outputMessage NVarChar (100) OUTPUT
)
as
if (DATEDIFF(YEAR, @DOB, GETDATE())>17)
begin
	if exists(select * from users)
	begin
		insert into users values((select top 1 UID from users order by UID DESC)+1,@name,@DOB,@mail,@pass,@phone)
	end
	else 
		insert into users values(1,@name,@DOB,@mail,@pass,@phone)
	 SET @outputMessage = 'Congratulations you are a member now';
     RETURN;
end 
else
begin
	SET @outputMessage = 'You must be at least 18 years old to register.';
     RETURN;
end
select * from Users
--usershow
create procedure usershow
as 
begin 
select name,email,phone from users
end 
--drop procedure movieshow
--movieshow
create procedure movieshow
as 
begin 
select Mname,picture from movies where mid<20
end 
--animeshow
create procedure animeshow
as 
begin 
select Mname,picture from movies where mid>=60
end 
--seriesshow
create procedure seriesshow
as 
begin 
select Mname,picture from movies where mid>=30 and mid<60
end 
--showshow
create view top6
as
select Mname,picture,sum(shows.B_seats) as bookings from movies join shows on shows.Mid=movies.Mid
group by Mname,picture

create procedure showshow
as 
begin 
select top 6 Mname,picture from top6
order by bookings DESC
end 
--comingshow
create procedure comingshow as
begin 
select top 3 Name,picture from coming_soon
end
--drop procedure seriesshow

--Admin
--select * from movies
--select * from shows
select * from timeslot
select * from screens
select * from addons
--select * from Users
select * from coming_soon
select * from booking

--shows
create procedure getShow 
as
begin 
select shows.Mid,shows.Screen,shows.Mdate,shows.Time_slotId,shows.B_seats from shows
end

create procedure delshow @scd char(5),@Mdate date , @tmid char(5)
as
begin 
delete from shows where Screen=@scd and Mdate=@Mdate and Time_slotId=@tmid
end

create procedure editshow  @scd char(5),@Mdate date , @timeid char(5),@mid2 char(5), @scd2 char(5),@Mdate2 date , @timeid2 char(5)
as
begin 
update shows set Mid=@mid2,Screen=@scd2,shows.Mdate=@Mdate2,shows.Time_slotId=@timeid2
where Screen=@scd and Mdate=@Mdate and Time_slotId=@timeid 
end

 create procedure setShow @mid char(5), @scd char(5),@dt date , @timeid char(5)
 as
 begin 
 insert into shows values(@mid,@scd,@dt,@timeid,'0')
 end
 --drop procedure delShow
 select * from shows

exec setShow @mid='MID04',@scd='SCID3',@dt='12-12-2009',@timeid='Slot2'

 exec editShow @scd='SCID3', @Mdate='10-10-2010', @tmid='Slot1'
 --adminusers
create procedure getusers 
as
begin 
select uid,Name,Email from users
end
create procedure deluser @uid1 int as
begin 
delete from users where uid=@uid1
end
--exec deluser @uid1=1
--drop procedure getmovies
--movies
create procedure getmovies as
begin
select Mid,Mname,Genre,Age_limit,picture from movies
end
create procedure delmovie @mid1 int as
begin 
delete from movies where mid=@mid1
end
create procedure setmovie @mid int, @mname varchar(50),@gen varchar(50) ,@agr varchar(30),@pic varchar(50)
as
begin
insert into movies values(@mid,@mname,@gen,@agr,@pic)
end
create procedure editmovie @mid1 int, @mid int, @mname varchar(50),@gen varchar(50) ,@agr varchar(30),@pic varchar(50)
as
begin 
update movies set Mid=@mid,Mname=@mname,Genre=@gen,Age_limit=@agr,picture=@pic
where Mid=@mid1
end
--UPCOMING
create procedure getcoming as
begin
select Cid,name,Genre,Age_limit,picture from coming_soon
end
create procedure delcoming @cid1 int as
begin 
delete from coming_soon where cid=@cid1
end
create procedure setcoming @cid int, @mname varchar(50),@gen varchar(50) ,@agr varchar(30),@pic varchar(50)
as
begin
insert into coming_soon values(@cid,@mname,@gen,@agr,@pic)
end
create procedure editcoming @cid1 int, @cid int, @mname varchar(50),@gen varchar(50) ,@agr varchar(30),@pic varchar(50)
as
begin 
update coming_soon set cid=@cid,name=@mname,Genre=@gen,Age_limit=@agr,picture=@pic
where cid=@cid1
end