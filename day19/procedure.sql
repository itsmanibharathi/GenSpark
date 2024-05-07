
create procedure proc_FirstProcedure
as
begin
    print 'Hello'
end

execute proc_FirstProcedure

create proc proc_GreetWithName(@cname varchar(20))
as
begin
   print 'Hello '+@cname
end

go
exec proc_GreetWithName 'Ramu'
exec proc_GreetWithName 'somu'

-- create the procedure for inserting data
select * from Employees

create proc proc_AddEmployee(@ename varchar(10),@edob datetime,
@earea varchar(10), @ephone varchar(15), @eemail varchar(15))
as
begin
   insert into Employees(name,DateOfBirth,EmployeeArea,Phone,Email)
   values(@ename,@edob,@earea,@ephone,@eemail)
end

exec proc_AddEmployee 'Bimu','2000-09-07','HHHH','1122334455','bimu@gmail.com'
create proc proc_AddEmployee(@ename varchar(10),@edob datetime,
@earea varchar(10), @ephone varchar(15), @eemail varchar(15))
as
begin
   insert into Employees(name,DateOfBirth,EmployeeArea,Phone,Email)
   values(@ename,@edob,@earea,@ephone,@eemail)
end


alter proc proc_GreetWithName(@cname varchar(20))
as
begin
   print 'Welcome '+@cname
end

exec proc_GreetWithName 'Mani'


create proc proc_Moreparam(@cname varchar(20), @age int)
as 
begin 
	print 'hi '+@cname +'Your age'+@age
end

exec proc_Moreparam 'mani' , 22


-- alter the proc

alter proc proc_Moreparam(@cname varchar(20), @age int)
as 
begin 
	print 'hi '+@cname +' Your age'+Cast(@age as varchar(3))
end

exec proc_Moreparam 'mani' , 22


