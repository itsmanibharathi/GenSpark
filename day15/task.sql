--use master
--go
--Drop Database Day15Task;

-- Create DataBase

Create Database Day15Task;
go
use Day15Task

-- DDL

-- Crete Department Table 

create table departments
(DName varchar(10) Constraint PK_DName primary key,
DFloor int ,
DPhonenumber varchar(10));
go
sp_help departments;

-- Create Employee Table 

create table employees (
    EID int identity (101,1) constraint PK_EID primary key,
    EName varchar(20),
    ESalary int,
    BID int,
    DName varchar(10) Constraint FK_DName Foreign Key References departments(DName) ,
    Constraint FK_BI Foreign Key (BID) References employees(EID),
);
go

-- Head in departments

Alter table departments
add MgrId int constraint FK_MgrId foreign key references employees(EID);
go
sp_help departments;


-- Create Item Table
Create table items
(IName varchar(50) Constraint PK_IName primary key,
IType char ,
IColor varchar(10))


-- Create sales table
go
Create table sales 
(SID int identity (1001,1) constraint PK_SID primary key,
Sqty int ,
IName varchar(50) Constraint SFK_IName References items(IName) not null,
DName varchar(10) Constraint SFK_DName References departments(DName)
)
go
sp_help sales;


-- Insert the data

-- Departement  DName, DFloor, DPhonenumber

insert into departments (DName, DFloor, DPhonenumber) values ('Management', 5, '34')


insert into departments (DName, DFloor, DPhonenumber) 
values ('Books', 1, '81'),
    ('Clothes', 2, '24'),
    ('Equipment', 3, '57'),
    ('Furniture', 4, '14'),
    ('Navigation', 1, '41'),
    ('Recreation', 2, '29'),
    ('Accounting', 5, '35'),
    ('Purchasing', 5, '36'),
    ('Personnel', 5, '37'),
    ('Marketing', 5, '38');

Select * from departments;


-- insert the emloyee 

insert into employees (EName, ESalary, DName)
values ('Alice', 75000, 'Management');


insert into employees (EName, ESalary, DName, BID)
values ('Ned', 45000, 'Marketing', 101)

insert into employees (EName, ESalary, DName, BID)
values 
    ('Andrew', 25000, 'Marketing', 102),
    ('Clare', 22000, 'Marketing', 102),
    ('Todd', 38000, 'Accounting', 101);

insert into employees (EName, ESalary, DName, BID)
values 
    ('Nancy', 22000, 'Accounting', 105),
    ('Brier', 43000, 'Purchasing', 101);

insert into employees (EName, ESalary, DName, BID)
values 
    ('Sarah', 56000, 'Purchasing', 107),
    ('Sophie', 35000, 'Personnel', 101),
    ('Sanjay', 15000, 'Navigation', 103),
    ('Rita', 15000, 'Books', 104),
    ('Gigi', 16000, 'Clothes', 104),
    ('Maggie', 11000, 'Clothes', 104),
    ('Paul', 15000, 'Equipment', 103),
    ('James', 15000, 'Equipment', 103),
    ('Pat', 15000, 'Furniture', 103),
    ('Mark', 15000, 'Recreation', 103);

select * from employees;

-- add the dep head 

select * from departments;

-- Update Management department
UPDATE departments
SET MgrId = 101
WHERE DName = 'Management';

-- Update Books department
UPDATE departments
SET MgrId = 104
WHERE DName = 'Books';

-- Update Clothes department
UPDATE departments
SET MgrId = 107
WHERE DName = 'Clothes';

-- Update Equipment department
UPDATE departments
SET MgrId = 104
WHERE DName = 'Equipment';

-- Update Furniture department
UPDATE departments
SET MgrId = 105
WHERE DName = 'Furniture';

-- Update Navigation department
UPDATE departments
SET MgrId = 104
WHERE DName = 'Navigation';

-- Update Recreation department
UPDATE departments
SET MgrId = 107
WHERE DName = 'Recreation';

-- Update Accounting department
UPDATE departments
SET MgrId = 108
WHERE DName = 'Accounting';

-- Update Purchasing department
UPDATE departments
SET MgrId = 109
WHERE DName = 'Purchasing';

-- Update Personnel department
UPDATE departments
SET MgrId = 110
WHERE DName = 'Personnel';

-- Update Marketing department
UPDATE departments
SET MgrId = 102
WHERE DName = 'Marketing';


-- Insert the data into the item table

insert into items (IName, IType, IColor) 
values ('Binoculars', 'N', 'Black');

insert into items (IName, IType, IColor) 
values ('Pocket Knife-Nile', 'E', 'Brown'),
       ('Pocket Knife-Avon', 'E', 'Brown'),
       ('Elephant Polo stick', 'R', 'Bamboo'),
       ('Camel Saddle', 'R', 'Brown'),
       ('Boots-snake proof', 'C', 'Green'),
       ('Pith Helmet', 'C', 'Khaki'),
       ('Hat-polar Explorer', 'C', 'White'),
       ('Hammock', 'F', 'Khaki'),
       ('Map case', 'E', 'Brown'),
       ('Safari Chair', 'F', 'Khaki'),
       ('Safari cooking kit', 'F', 'Khaki'),
       ('Stetson', 'C', 'Black'),
       ('Tent - 2 person', 'F', 'Khaki'),
       ('Tent -8 person', 'F', 'Khaki');

insert into items (IName, IType) 
values ('Compass', 'N'),
       ('Geo positioning system', 'N'),
       ('Map Measure', 'N'),
       ('Sextant', 'N'),
       ('Exploring in 10 Easy Lessons', 'B'),
       ('How to win Foreign Friends', 'B');
 


 -- insert the data into the sales 
insert into sales (Sqty, IName, DName) 
values(2, 'Boots-snake proof', 'Clothes')

insert into sales (Sqty, IName, DName) 
values(1, 'Pith Helmet', 'Clothes'),
(1, 'Sextant', 'Navigation'),
(3, 'Hat-polar Explorer', 'Clothes'),
(5, 'Pith Helmet', 'Equipment'),
(2, 'Pocket Knife-Nile', 'Clothes'),
(3, 'Pocket Knife-Nile', 'Recreation'),
(1, 'Compass', 'Navigation'),
(2, 'Geo positioning system', 'Navigation'),
(5, 'Map Measure', 'Navigation'),
(1, 'Geo positioning system', 'Books'),
(1, 'Sextant', 'Books'),
(3, 'Pocket Knife-Nile', 'Books'),
(1, 'Pocket Knife-Nile', 'Navigation'),
(1, 'Pocket Knife-Nile', 'Equipment'),
(1, 'Sextant', 'Clothes'),
(1, 'Exploring in 10 easy lessons', 'Books'),
(1, 'Elephant Polo stick', 'Recreation'),
(1, 'Camel Saddle', 'Recreation');

select * from sales
