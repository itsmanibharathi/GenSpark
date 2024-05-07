use NorthWind

select * from Categories

select * from Suppliers

-- union 

select CategoryID,  categoryname from Categories
union
select SupplierId,CompanyName from Suppliers

select * from [Order Details]

select * from Orders where ShipCountry='Spain'
union -- unique rows 
select * from orders where Freight>50

select * from Orders where ShipCountry='Spain'
union all -- it have respectation
select * from orders where Freight>50

-- intersect

select * from Orders where ShipCountry='Spain'
intersect -- get only respectation rows 
select * from orders where Freight>50

--get the order id, productname and quantitysold of products that have price
--greater than 15


select od.OrderID,p.ProductName,od.Quantity 'Quantitysold'
from [Order Details] od join Products p on od.ProductID = p.ProductID 
where p.UnitPrice > 15


--get the order id, productname and quantitysold of products that are from category 'dairy'
--and within the price range of 10 to 20

select od.OrderID,p.ProductName,od.Quantity 'Quantitysold' 
from [Order Details] od join Products p on od.ProductID = p.ProductID join Categories c on p.CategoryID = c.CategoryID 
where c.CategoryName like 'dairy%' and p.UnitPrice between 10 and 20




select OrderID, ProductName, Quantity "Quantity Sold",p.UnitPrice
from [Order Details] od join Products p
on od.ProductId = p.ProductID
where p.UnitPrice>15
union
SELECT OrderID, p.productname, Quantity "Quantity Sold", p.UnitPrice FROM [Order Details]
JOIN Products p ON p.ProductID = [Order Details].ProductID
JOIN Categories c ON c.CategoryID = p.CategoryID
WHERE p.UnitPrice BETWEEN 10 AND 20 AND c.CategoryName LIKE '%Dairy%'
order by p.unitprice desc




















