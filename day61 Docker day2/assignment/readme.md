# Day 2 Docker Assignment [References](https://tomcam.github.io/postgres/)

Pull postgres image

```
docker pull postgres
```

Create a Container
```
docker run --name postgres_assignmet -e POSTGRES_PASSWORD=demo -e POSTGRES_USER=demo -d postgres
```

Open the postgres bash
```
docker exec -it postgres_assignment bash
```

Login demo user
```
psql -U demo
```

list databases

```
\l
```
Create database hear ';' important 

```
CRATE DATABASE work;
```
Use the database

```
\c work;
```

Create Table
```sql
-- Create table for Employee
CREATE TABLE Employee (
    employee_id SERIAL PRIMARY KEY,
    employee_name VARCHAR(100),
    age INT,
    phone VARCHAR(20),
    department_id INT REFERENCES Department
);

-- Create table for Department
CREATE TABLE Department (
    department_id SERIAL PRIMARY KEY,
    department_name VARCHAR(100)
);

-- Create table for Salary
CREATE TABLE Salary (
    salary_id SERIAL PRIMARY KEY,
    employee_id INT  REFERENCES Employee,
    salary DECIMAL(10, 2)
);
```
Insert data

```sql
-- Insert data into Employee table
INSERT INTO Employee (employee_name, age, phone, department_id, salary)
VALUES ('John Doe', 30, '123-456-7890', 1, 50000.00),
    ('Jane Smith', 25, '987-654-3210', 2, 60000.00),
    ('Mike Johnson', 35, '555-555-5555', 1, 55000.00);

-- Insert data into Department table
INSERT INTO Department (department_name)
VALUES ('Sales'),
    ('Marketing');

-- Insert data into Salary table
INSERT INTO Salary (employee_id, salary)
VALUES (1, 50000.00),
    (2, 60000.00),
    (3, 55000.00);
```

```sql
SELECT e.employee_name, e.age, e.phone, d.department_name, s.salary
from Employee as e JOIN Department as d on e.department_id = d.department_id JOIN Salary as s on e.employee_id = s.employee_id;
```
