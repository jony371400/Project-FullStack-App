-- DROP TABLE Department;

-- Create Database mytestdb;

-- Create Table dbo.Department(
-- 	DepartmentId int ,
-- 	DepartmentName nvarchar(500)
-- );

-- Create Table dbo.Employee(
-- 	EmployeeId int ,
-- 	EmployeeName nvarchar(500),
-- 	Department nvarchar(500),
-- 	DateOfJoining datetime,
-- 	PhotoFileName nvarchar(500),
-- );

Use mytestdb;

-- Insert into Department values(1,'IT');
-- Insert into Department values(2,'Support');
select * from Department;

-- Insert into Employee values(1 , 'Johnny' , 'IT' , GETDATE() , 'anonymous.png');
-- Insert into Employee values(2 , 'David' , 'Pharmacist' , GETDATE() , 'someone.png');
 select * from Employee;