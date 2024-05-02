-- Create DB
CREATE DATABASE dbEmployeeTracker;
go
-- Use the DB
USE dbEmployeeTracker;
-- Drop the db
-- USE master;
-- go
-- DROP DATABASE dbEmployeeTracker;

-- Create Table

CREATE TABLE Areas 
(Area varchar(20),
Zipcode char(5))

SELECT * FROM Areas;

SP_HELP Areas; -- 

-- Add the Primary key
--Edit the area colum to be teh primary key
alter table Areas
alter column Area varchar(20) not null
alter table Areas
add constraint pk_Area primary key(Area)

--Drop and re create table to add primary key

drop table Areas

create Table Areas
(Area varchar(20) primary key ,
Zipcode char(6))

-- Add column in the table 

Alter table Areas 
Add newcol varchar(20) not null

-- Drop the newcol

Alter table Areas
Drop Column newcol

-- Creating 

-- identity is for auto increment 
create table Skills(
Skill_id int identity(1,1) constraint pk_skill primary key,
Skill varchar(20),
SkillDescription varchar(100))


sp_help skills;

-- Creating employee table 
create table Employees
(id int identity(101,1) constraint pk_EmployeeId primary key,
name varchar(100) ,
DateOfBirth datetime constraint chk_DOB Check(DateOfBirth<Getdate()),
EmployeeArea varchar(20) constraint fk_Area references Areas(Area),
Phone varchar(15),
email varchar(100) not null)


sp_help Employees

-- emp skills

create table EmployeeSkill
(Employee_id int constraint fk_skill_eid foreign key references Employees(id),
Skill int constraint fk_Skill_EmplSkill foreign key references Skills(skill_id),
skillLevel float constraint chk_skilllevel check(skillLevel>=0),
constraint pk_employee_skill primary key(Employee_id,Skill))

sp_help EmployeeSkill;



--DML--
Insert into Areas(Area,Zipcode) values('DDDD','12345')
Insert into Areas(Zipcode,Area) values('12333','FFFF')
insert into Areas values('HHHH','12222')

-- Insert multiple rows 

--Insert into Areas values('MMMK','23123'),('DDR','12345')
Select * from Areas

-- Delete 

Delete From Areas;


--Foreign Key insert
insert into Employees(name,DateOfBirth,EmployeeArea,Phone,Email)
Values('Ramu','2000-12-12','DDDD','9876543210','ramu@gmail.com')
insert into Employees(name,DateOfBirth,EmployeeArea,Phone,Email)
Values('Somu','2001-05-01','FFFF','9988776655','somu@gmail.com') ,
	('Kimu','03-08-2000','DDDD','12345','7766554433	kimu@gmail.com')

select * from Employees

-- update table 
update Employees
set Phone ='7766554433', Email = 'kimu@gmail.com'
where name = 'kimu'
--Employee Skill- Composite key

Insert into EmployeeSkill values(101,3,8)

Select * from Employees;
-- Update 

update Employees set phone = '9876543210'
where id = 101
update Employees set phone = '9988776655'
where id = 102


Insert into EmployeeSkill values(102,2,7)
Insert into EmployeeSkill values(102,3,7)

update EmployeeSkill set skillLevel = 8
where skill = 2 and Employee_id = 102;
select * from EmployeeSkill;

insert Skills values ('C','PLT'),('C++','OOPS'),('Java','Web'),('C#','Web'),('SQL','RDBMS');


-- select	