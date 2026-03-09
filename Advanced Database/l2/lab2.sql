--1
create table Department (
	DeptNo varchar(10) primary key ,
	DeptName varchar(10) ,
	loc nchar(2) default 'NY' CHECK (loc IN ('NY', 'DS', 'KW'))
)
insert into Department values('d1','Research','NY'),
							 ('d2','Accounting','DS'),
							 ('d3','Markiting','KW')


create table Employee (
	EmpNo int primary key,
	Emp_Fname varchar(20) not null, 
	Emp_Lname varchar(20) not null,
	DeptNo varchar(10) foreign key references Department(DeptNo),
	Salary int unique check(salary < 6000)
)
insert into Employee values (25348, 'Mathew', 'Smith', 'd3', 2500),
							(10102, 'Ann', 'Jones', 'd3', 3000),
							(18316, 'John', 'Barrimore', 'd1', 2400),
							(29346, 'James', 'James', 'd2', 2800),
							(9031, 'Lisa', 'Bertoni', 'd2', 4000),
							(2581, 'Elisa', 'Hansel', 'd2', 3600),
							(28559, 'Sybl', 'Moser', 'd1', 2900)


alter table empolyee add TelephoneNumber int
alter table empolyee drop column TelephoneNumber

--2
create Schema [Company]
create Schema [HumanResource]

alter schema company transfer department
alter schema company transfer project
alter schema HumanResource transfer Employee

--3
sp_helpconstraint 'HumanResource.Employee';

--4
CREATE SYNONYM Emp FOR HumanResource.Employee
Select * from Emp
Select * from Employee --error
Select * from HumanResource.Employee
Select * from HumanResource.Emp --error

--5
UPDATE Company.Project
SET Budget = Budget * 1.10
WHERE ProjectNo IN (
    SELECT ProjectNo 
    FROM Works_on 
    WHERE EmpNo = 10102 AND Job = 'Manager'
);


--6
UPDATE Company.Department
SET DeptName = 'Sales'
WHERE DeptNo IN (
    SELECT DeptNo 
    FROM HumanResource.Employee 
    WHERE Emp_Fname = 'James'
);

--7
UPDATE Works_on
SET Enter_Date = '2007-12-12'
FROM Works_on W
JOIN HumanResource.Employee E ON W.EmpNo = E.EmpNo
JOIN Company.Department D ON E.DeptNo = D.DeptNo
WHERE W.ProjectNo = 'p1' AND D.DeptName = 'Sales';

--8
DELETE Works_on
FROM Works_on W
JOIN HumanResource.Employee E ON W.EmpNo = E.EmpNo
JOIN Company.Department D ON E.DeptNo = D.DeptNo
WHERE D.loc = 'KW';









 
