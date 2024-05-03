-- 1) Print the storeid and number of orders for the store

select stor_id , Count(ord_num) 'No of orders' from sales group by stor_id

-- 2) print the numebr of orders for every title

select title_id, count(ord_num) 'NO of orders' from sales group by title_id

-- 3) print the publisher name and book name

select p.pub_name, t.title from titles t join publishers p on t.pub_id = p.pub_id

-- 4) Print the author full name for al the authors

select (au_fname + ' ' + au_lname ) 'full name' from authors 

-- 5) Print the price or every book with tax (price+price*12.36/100)

select title,type,price, (price+(price*12.36/100)) 'Tax' from titles

-- 6) Print the author name, title name

select (a.au_fname +' '+ a.au_lname) 'Author name',t.title from 
titleauthor ta join titles t on ta.title_id = t.title_id join authors a on ta.au_id = a.au_id
order by a.au_fname , a.au_lname

-- 7) print the author name, title name and the publisher name

select (a.au_fname +' '+ a.au_lname) 'Author name',t.title, p.pub_name from 
titleauthor ta join titles t on ta.title_id = t.title_id 
join authors a on ta.au_id = a.au_id 
join publishers p on p.pub_id = t.pub_id
order by a.au_fname , a.au_lname


-- 8) Print the average price of books pulished by every publicher

select pub_id, avg(price) 'Avg price' from titles group by pub_id

-- 9) print the books published by 'Marjorie'
select * from titles where title_id in
(select title_id from titleauthor where au_id in
(select au_id from authors where au_fname = 'Marjorie'))

-- or 

select t.title_id , a.au_fname from titleauthor ta 
join authors a on ta.au_id = a.au_id 
join titles t on t.title_id = ta.title_id 
where a.au_fname = 'Marjorie'


-- 10) Print the order numbers of books published by 'New Moon Books'

select ord_num from sales where title_id in 
(select title_id from titles where pub_id in 
(select pub_id from publishers where pub_name = 'New Moon Books'))
-- or 

select s.ord_num, p.pub_name 
from publishers p 
join titles t on t.pub_id = p.pub_id 
join sales s on s.title_id = t.title_id 
where p.pub_name = 'New Moon Books'

-- 11) Print the number of orders for every publisher

select pub_id,COUNT(s.ord_num) 'No of Orders' 
from sales s join titles t on s.title_id = t.title_id group by t.pub_id

-- 12) print the order number , book name, quantity, price and the total price for all orders

select s.ord_num,t.title,s.qty,t.price,(s.qty*t.price) 'Total price' 
from sales s join titles t on s.title_id = t.title_id

-- 13) print he total order quantity fro every book

select title_id, sum(qty) 'Total order qty'  from sales group by title_id

-- 14) print the total ordervalue for every book

select s.title_id, sum(s.qty*t.price) 'Total order Price'  
from sales s join titles t on s.title_id = t.title_id 
group by s.title_id


-- 15) print the orders that are for the books published by the publisher for which 'Paolo' works for

select * from sales where title_id in
(select title_id from titles where pub_id in (select pub_id from employee where fname = 'Paolo'))

-- or

select e.fname, s.ord_num , t.title ,s.qty 
from employee e join titles t on e.pub_id = t.pub_id 
join sales s on t.title_id = s.title_id
where e.fname = 'Paolo'
