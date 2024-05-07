
use NorthWind
--CTE

with OrderDetails_CTE(OrderID,ProductName,Quantity,Price)
as
(select OrderID, ProductName, Quantity "Quantity Sold",p.UnitPrice
from [Order Details] od join Products p
on od.ProductId = p.ProductID
where p.UnitPrice>15
union
SELECT OrderID, p.productname, Quantity "Quantity Sold", p.UnitPrice FROM [Order Details]
JOIN Products p ON p.ProductID = [Order Details].ProductID
JOIN Categories c ON c.CategoryID = p.CategoryID
WHERE p.UnitPrice BETWEEN 10 AND 20 AND c.CategoryName LIKE '%Dairy%')

select top 10 * from  OrderDetails_CTE order by price desc

drop view vworderDetails

create view vwOrderDetails
as
(select OrderID, ProductName, Quantity "Quantity Sold",p.UnitPrice
from [Order Details] od join Products p
on od.ProductId = p.ProductID
where p.UnitPrice>15
union
SELECT OrderID, p.productname, Quantity "Quantity Sold", p.UnitPrice FROM [Order Details]
JOIN Products p ON p.ProductID = [Order Details].ProductID
JOIN Categories c ON c.CategoryID = p.CategoryID
WHERE p.UnitPrice BETWEEN 10 AND 20 AND c.CategoryName LIKE '%Dairy%')


select * from vwOrderDetails order by UnitPrice



select top 10 * from (
select OrderID, ProductName, Quantity "Quantity Sold",p.UnitPrice
from [Order Details] od join Products p
on od.ProductId = p.ProductID
where p.UnitPrice>15
union
SELECT OrderID, p.productname, Quantity "Quantity Sold", p.UnitPrice FROM [Order Details]
JOIN Products p ON p.ProductID = [Order Details].ProductID
JOIN Categories c ON c.CategoryID = p.CategoryID
WHERE p.UnitPrice BETWEEN 10 AND 20 AND c.CategoryName LIKE '%Dairy%'
 
)as t  order by t.UnitPrice  desc


--Get the first 10 records of

--The order ID, Customer name and the product name for products that are purchaced by 
--people from USA
--The order ID, Customer name and the product name for products that are ordered by people from france 
--with fright less than 20

select * from [Order Details]

with OrderDetailss_CTE( OrderID , ContactName , ProductName)
as
(
select o.OrderID , c.ContactName , p.ProductName
from [Order Details] od join Products p on od.ProductID = p.ProductID 
join Orders o on od.OrderID = o.OrderID join Customers c on o.CustomerID = c.CustomerID
where c.Country = 'USA'
union
select o.OrderID , c.ContactName , p.ProductName
from [Order Details] od join Products p on od.ProductID = p.ProductID 
join Orders o on od.OrderID = o.OrderID join Customers c on o.CustomerID = c.CustomerID
where c.Country = 'france' and o.Freight < 20 
)
select top 10 * from  OrderDetailss_CTE 





















