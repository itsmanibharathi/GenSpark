use NorthWind

select * from customers where CustomerID not in (select distinct customerid from Orders)

select * from orders

-- outer join

select ContactName,ShipName,ShipAddress
from customers c join orders o
on c.CustomerID = o.CustomerID

-- left outer join  get the all records from the left side table if not in right pull 'Null' 
select ContactName,ShipName,ShipAddress
from customers c left outer join orders o
on c.CustomerID = o.CustomerID

-- other product witch never order 

select ProductID from Products where ProductID not in (select ProductID from [Order Details])



