select * from Categories

select CategoryId from Categories where CategoryName = 'Confections'

--All the products from 'Confections'
select * from products where CategoryID = 
(select CategoryId from Categories where CategoryName = 'Confections')


select * from Suppliers
--select product names from the supplier Tokyo Traders

select * from Products where SupplierID = 
(select SupplierID from Suppliers where CompanyName = 'Tokyo Traders')

--get all the products that are supplied by suppliers from USA
select ProductName from products where SupplierID in
(select SupplierID from Suppliers where Country = 'USA')


--get all the products from the category that has 'ea' in the description
select * from products where CategoryID in
(select CategoryID from Categories where Description like '%ea%' )


select * from products where CategoryID in
(select CategoryID from Categories where Description like '%ea%')
and SupplierID = 
(select SupplierID from Suppliers where CompanyName = 'Tokyo Traders')


--select the product id and the quantity ordered by customrs from France

select ProductID,Quantity from [Order Details] where OrderID in 
(select OrderID from Orders where CustomerID in
(select CustomerID from Customers where Country = 'France'));

--Get the products that are priced above the average price of all the products

select * from Products where UnitPrice > 
(select avg(UnitPrice) from Products)


-- select the latest order of every employee 

select *  from orders o1 where orderDate =
(select Max(OrderDate) from Orders o2 where o2.EmployeeID = o1.EmployeeID)

--Select the maximum priced product in every category

select * from Products p1 where UnitPrice = 
(select max(UnitPrice) from Products p2 where p2.CategoryID = p1.CategoryID)

--select the order number for the maximum fright paid by every customer

select *  from orders o1 where Freight =
(select Max(Freight) from Orders o2 where o1.CustomerID = o2.CustomerID)



