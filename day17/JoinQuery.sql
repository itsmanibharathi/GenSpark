--cross join
select * from Categories,customers

--Inner join
select * from categories where CategoryID 
not in (select distinct categoryid from products)

select * from Suppliers where SupplierID 
not in (select distinct SupplierID from products)

--Get teh categoryId and teh productname
select CategoryId,ProductName from products

--Get teh categoryname and the productname
select categoryName,ProductName from Categories -- inner join 
join Products on Categories.CategoryID = Products.CategoryID

-- (Or)

select categoryName,ProductName 
from Categories, Products 
Where Categories.CategoryID = Products.CategoryID

--Get the Supplier company name, contact person name, Product name and the stock ordered

select * from Suppliers
select * from Products

select CompanyName,ContactName,ProductName,UnitsOnOrder 
from Suppliers join Products on Suppliers.SupplierID=Products.SupplierID

-- Print the order id, customername and the fright cost for all teh orders

select * from orders
Select * from Customers

select OrderID,ContactName , Freight from orders,Customers where Orders.CustomerID = Customers.CustomerID

 --product name, quantity sold, Discount Price, Order Id, Fright for all orders
 
 select * from Orders
 
 select o.OrderID "Order ID",p.Productname, od.Quantity "Quantity Sold",
 (p.UnitPrice*od.Quantity) "Base Price", 
 ((p.UnitPrice*od.Quantity)-((p.UnitPrice*od.Quantity)* od.Discount/100)) "Discounted price",
 Freight "Freight Charge"
 from Orders o join [Order Details] od
 on o.OrderID = od.OrderID
 join Products p on p.ProductID = od.ProductID
 order by o.OrderID



 
 --select customer name, product name, quantity sold and the frieght, 
 --total price(unitpice*quantity+freight)


 select c.ContactName , p.ProductName, od.Quantity 'Quanity sold',
 o.Freight, (p.UnitPrice*od.Quantity+o.Freight) 'Total price'  
 from orders o join [Order Details] od on o.OrderID = od.OrderID 
 join Products p on od.ProductID = p.ProductID 
 join Customers c on c.CustomerID = o.CustomerID 


 
 --Print the product name and the total quantity sold
 select productName,sum(quantity) "Total quantity sold"
 from products p join [Order Details] od
 on p.ProductID = od.ProductID
 group by ProductName
 order by 2 desc

 -- Customer name and the number of product bought for every order 
 
 select o.OrderID,c.ContactName , sum(od.ProductID) 'NO order'   from 
 Orders o join Customers c on o.CustomerID = c.CustomerID 
 join [Order Details] od on o.OrderID = od.OrderID
 group by c.ContactName,o.OrderID


 -- select the emp name , customer name, product name and total price of product

 select e.FirstName, c.ContactName , p.ProductName, sum(od.UnitPrice * od.Quantity) 'Total Price'
 from orders o join Customers c on o.CustomerID = c.CustomerID 
 join [Order Details] od on od.OrderID =o.OrderID
 join Products p on p.ProductID = od.ProductID
 join Employees e on e.EmployeeID = o.EmployeeID
 group by p.ProductName, c.ContactName,e.FirstName
 
 
 sp_help products
































