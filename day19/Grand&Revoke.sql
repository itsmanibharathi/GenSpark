-- create new user

CREATE LOGIN new_user WITH PASSWORD = 'password123';


-- add the user from table 

CREATE USER new_user FOR LOGIN new_user;



-- grand 
select * from Employees

Grant select,insert on Employees to new_user

select * from sys.database_permissions

select * from sys.database_principals
-- revoke

revoke select on Employees from new_user


SELECT *
FROM sys.server_principals
WHERE type_desc IN ('SQL_LOGIN', 'WINDOWS_LOGIN');


SELECT *
FROM sys.database_principals
WHERE type_desc = 'SQL_USER';