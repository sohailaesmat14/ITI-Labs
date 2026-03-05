-- Select Queries
-- 1
Select *  
from Employee; 
-----------------------------
-- 2
Select Fname , Lname , Salary , Dno 
from Employee; 
-----------------------------
-- 3
Select distinct Pname , Plocation , Dnum
from Project
-----------------------------
-- 4
Select Fname+Lname as [Full Name] , Salary*12*0.1 as [ANNUAL COMM]
from Employee
-----------------------------
-- 5
Select Fname , SSN   
from Employee
where Salary > 1000
-----------------------------
-- 6
Select Fname , SSN   
from Employee
where Salary*12 > 10000
-----------------------------
-- 7
Select Fname , Salary  
from Employee
where Sex = 'F'
-----------------------------
-- 8
Select Dnum , Dname  
from Departments
where MGRSSN = 968574
-----------------------------
-- 9
Select Pnumber , Pname , Plocation
from Project
where Dnum = 10
-----------------------------
----------------------------------------------------
-- 1
--Insert into Employee 
--values ('Sohaila','Esmat',102672,'2001-10-14','6 Abdel Rahman Ouda','F',10000,112233,30)
-----------------------------
-- 2
--Insert into Employee (Fname,Lname,SSN,Bdate,Address,Sex,Dno)
--values ('Sara','Ahmed',102660,'2001-10-29','Mustafa Kamel','F',30)
-----------------------------
-- 3
--Insert into Departments 
--values ('DEPT IT',100,112233,'01-11-2006')
-----------------------------
-- 4
UPDATE Employee Set Dno = 100
where SSN = 968574
UPDATE Employee Set Dno = 20
where SSN = 102672
UPDATE Employee Set Superssn = 102672
where SSN = 102660
Select *  
from Employee; 
-----------------------------
--5
Select Dname
from Departments
where MGRSSN = 223344

Select ESSN , Dependent_name
from Dependent
where ESSN = 223344

Select *
from Works_for
where ESSN = 223344

Update Employee Set Superssn=102660  where Superssn = NULL

Delete from Dependent where ESSN = 223344
Delete from Works_for where ESSN = 223344
Delete from Employee where SSN = 223344

Select *  
from Employee; 
-----------------------------
--6
UPDATE Employee Set Salary = Salary+Salary*0.2
where SSN = 102672

Select *  
from Employee;

Select *  
from Departments;