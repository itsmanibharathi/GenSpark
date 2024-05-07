
use pubs
--1) Create a stored procedure that will take the author firstname and 
--print all the books polished by him with the publisher's name

create proc GetBookByAuFName(@first_name varchar(20))
as
begin 
	Select a.au_lname , t.title
	from authors a join titleauthor ta on a.au_id = ta.au_id 
	join titles t on ta.title_id = t.title_id join publishers p on t.pub_id = p.pub_id
	where a.au_lname = @first_name
end

alter proc GetBookByAuFName(@first_name varchar(20))
as
begin 
	Select a.au_lname , t.title, p.pub_name
	from authors a join titleauthor ta on a.au_id = ta.au_id 
	join titles t on ta.title_id = t.title_id join publishers p on t.pub_id = p.pub_id
	where a.au_lname = @first_name
end

exec GetBookByAuFName 'Green'

select * from authors
select * from titleauthor 
select * from titles
--2) Create a sp that will take the employee's firtname and print all the titles sold by him/her, price, quantity and the cost.

select * from sales

Create proc GetSoldInfoByEmpFName(@FName varchar(20))
as
begin 
	select e.fname, t.title,max(t.price)'Price',sum(s.qty)'Quantity',sum(t.price*s.qty) 'Cost'
	from publishers p join employee e on p.pub_id = e.pub_id 
	join titles t on p.pub_id = t.pub_id join sales s on t.title_id = s.title_id
	where  e.fname = @FName
	group by t.title,e.fname
end

exec GetSoldInfoByEmpFName 'paolo'


select * from employee
sp_help employee
--3) Create a query that will print all names from authors and employees

	select au_fname +' '+ au_lname 'Full Name' from authors
	union
	select fname+' '+ lname 'Full Name' from employee

--4) Create a  query that will float the data from sales,titles, publisher and authors table to 
--print title name, Publisher's name, author's full name with quantity ordered and price for the order for all orders,
--print first 5 orders after sorting them based on the price of order

with OrderDetails_CTE(title,pub_name,auther_Full_name,qty,price)
as
(select t.title,p.pub_name,(a.au_fname+' '+a.au_lname) 'Author_Full_name' ,s.qty ,(s.qty*t.price)'Price '
from sales s join titles t on s.title_id = t.title_id 
join publishers p on t.pub_id = p.pub_id join titleauthor ta on t.title_id = ta.title_id 
join authors a on ta.au_id = a.au_id)

select top 5 * from OrderDetails_CTE order by price desc






