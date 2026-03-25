use iti
UPDATE Instructor
SET Salary =
CASE Ins_Id
    WHEN 1 THEN 8000
    WHEN 2 THEN 6000
    WHEN 3 THEN 5500
    WHEN 4 THEN 12000
    WHEN 5 THEN 11000
    WHEN 6 THEN 7000
    WHEN 7 THEN 4000
    WHEN 8 THEN 6500
    WHEN 9 THEN 5000
    WHEN 10 THEN 9000
    WHEN 11 THEN 4800
    WHEN 12 THEN 5200
    WHEN 13 THEN 4500
    WHEN 14 THEN 4700
    WHEN 15 THEN 10000
END
WHERE Salary IS NULL;

--1
SELECT COUNT(*) AS StudentsWithAge
FROM Student
WHERE St_Age IS NOT NULL;

--2
SELECT DISTINCT Ins_Name
FROM Instructor;

--3
SELECT S.St_Id AS [Student ID],ISNULL(S.St_Fname,'') + ' ' + ISNULL(S.St_Lname,'') AS [Student Full Name],
ISNULL(D.Dept_Name, 'No Department') AS [Department Name]
FROM Student S
LEFT JOIN Department D
ON S.Dept_Id = D.Dept_Id;

--4
SELECT I.Ins_Name,ISNULL(D.Dept_Name, 'No Department') AS Dept_Name
FROM Instructor I
LEFT JOIN Department D
ON I.Dept_Id = D.Dept_Id;

--5
SELECT S.St_Fname + ' ' + S.St_Lname AS StudentName,C.Crs_Name
FROM Student S
JOIN Stud_Course SC ON S.St_Id = SC.St_Id
JOIN Course C ON SC.Crs_Id = C.Crs_Id
WHERE SC.Grade IS NOT NULL;

--6
SELECT T.Top_Name,COUNT(C.Crs_Id) AS CourseCount
FROM Topic T
LEFT JOIN Course C
ON T.Top_Id = C.Top_Id
GROUP BY T.Top_Name;

--7
SELECT 
    MAX(Salary) AS MaxSalary,
    MIN(Salary) AS MinSalary
FROM Instructor;

--8
SELECT *
FROM Instructor
WHERE Salary < (SELECT AVG(Salary) FROM Instructor);

--9
SELECT D.Dept_Name
FROM Instructor I
JOIN Department D
ON I.Dept_Id = D.Dept_Id
WHERE I.Salary = (SELECT MIN(Salary) FROM Instructor);

--10
SELECT DISTINCT TOP 2 Salary
FROM Instructor
ORDER BY Salary DESC;

--11
SELECT 
    Ins_Name,
    COALESCE(CONVERT(VARCHAR, Salary), 'Bonus') AS Salary
FROM Instructor;

--12
SELECT AVG(Salary) AS AvgSalary
FROM Instructor;

--13
SELECT S.St_Fname AS StudentName, Sup.St_Fname AS SupervisorName
FROM Student S
LEFT JOIN Student Sup
ON S.St_super = Sup.St_Id;

--14
SELECT *
FROM (
    SELECT 
        Ins_Name,
        Salary,
        Dept_Id,
        DENSE_RANK() OVER (PARTITION BY Dept_Id ORDER BY Salary DESC) AS Rnk
    FROM Instructor
    WHERE Salary IS NOT NULL
) X
WHERE Rnk <= 2;

--15
SELECT *
FROM (
    SELECT 
        *,
        ROW_NUMBER() OVER (PARTITION BY Dept_Id ORDER BY NEWID()) AS Rn
    FROM Student
) X
WHERE Rn = 1;
-------------------------------------------------------------------
use AdventureWorks2012
--1
SELECT SalesOrderID, ShipDate
FROM Sales.SalesOrderHeader
WHERE ShipDate BETWEEN '2002-07-28' AND '2014-07-29';

--2
SELECT ProductID, Name
FROM Production.Product
WHERE StandardCost < 110;

--3
SELECT ProductID, Name
FROM Production.Product
WHERE Weight IS NULL;

--4
SELECT *
FROM Production.Product
WHERE Color IN ('Silver', 'Black', 'Red');

--5
SELECT *
FROM Production.Product
WHERE Name LIKE 'B%';

--6
SELECT *
FROM Production.ProductDescription
WHERE Description LIKE '%[_]%';

--7
SELECT OrderDate,SUM(TotalDue) AS TotalSum
FROM Sales.SalesOrderHeader
WHERE OrderDate BETWEEN '2001-07-01' AND '2014-07-31'
GROUP BY OrderDate;

--8
SELECT DISTINCT HireDate
FROM HumanResources.Employee;

--9
SELECT AVG(ListPrice) AS AvgListPrice
FROM (SELECT DISTINCT ListPrice FROM Production.Product) X;

--10
SELECT 'The ' + Name + ' is only! ' + CAST(ListPrice AS VARCHAR) AS ProductInfo
FROM Production.Product
WHERE ListPrice BETWEEN 100 AND 120
ORDER BY ListPrice;

--11-a
SELECT rowguid, Name, SalesPersonID, Demographics
INTO store_Archive
FROM Sales.Store;

--11-b
SELECT rowguid, Name, SalesPersonID, Demographics
FROM Sales.Store;
--false condition 

--12
SELECT CONVERT(VARCHAR, GETDATE(), 101)
UNION
SELECT CONVERT(VARCHAR, GETDATE(), 103)
UNION
SELECT FORMAT(GETDATE(), 'yyyy-MM-dd');
