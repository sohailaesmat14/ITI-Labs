use ITI
-- 1
CREATE VIEW v_student_grades
AS
SELECT S.St_Fname + ' ' + S.St_Lname AS [Full Name], C.Crs_Name
FROM Student S 
JOIN Stud_Course SC ON S.St_Id = SC.St_Id
JOIN Course C ON SC.Crs_Id = C.Crs_Id
WHERE SC.Grade > 50;

select * from v_student_grades

-- 2
CREATE VIEW v_managers_topics
WITH ENCRYPTION
AS
SELECT DISTINCT I.Ins_Name, T.Top_Name
FROM Instructor I 
JOIN Department D ON I.Ins_Id = D.Dept_Manager
JOIN Ins_Course IC ON I.Ins_Id = IC.Ins_Id
JOIN Course C ON IC.Crs_Id = C.Crs_Id
JOIN Topic T ON C.Top_Id = T.Top_Id;

select * from v_managers_topics

-- 3
CREATE VIEW v_instructor_dept
AS
SELECT I.Ins_Name, D.Dept_Name
FROM Instructor I 
JOIN Department D ON I.Dept_Id = D.Dept_Id
WHERE D.Dept_Name IN ('SD', 'Java');

select * from v_instructor_dept

-- 4
CREATE VIEW V1
AS
SELECT * FROM Student
WHERE St_Address IN ('Alex', 'Cairo')
WITH CHECK OPTION; 

Update V1 set st_address='tanta'
Where st_address='alex';

select * from v1

-- 5
use SD
CREATE VIEW v_project_emp_count
AS
SELECT P.ProjectName, COUNT(E.EmpNo) AS [Employee Count]
FROM db_accessadmin.Project P 
JOIN Works_on W ON P.ProjectNo = W.ProjectNo
JOIN Employee E ON W.EmpNo = E.EmpNo
GROUP BY P.ProjectName;

select * from v_project_emp_count

use iti
-- 6
CREATE CLUSTERED INDEX IX_Dept_HireDate
ON Department(Manager_hiredate);
--error
--"cannot create more than one clustered index on table 'Department'. Drop the existing clustered index 'PK_Department' before creating another"

-- 7
CREATE UNIQUE INDEX IX_Student_Age
ON Student(St_Age);
-- It will enforce uniqueness on the Age column, preventing duplicate values. 
-- If the table already contains duplicate ages, the index creation will fail.

-- 8
CREATE TABLE Last_Transactions (
    User_ID INT PRIMARY KEY,
    Transaction_Amount INT
);
CREATE TABLE Daily_Transactions (
    User_ID INT PRIMARY KEY,
    Transaction_Amount INT
);
INSERT INTO Last_Transactions VALUES (1, 4000), (4, 2000), (2, 10000);
INSERT INTO Daily_Transactions VALUES (1, 1000), (2, 2000), (3, 1000);

MERGE INTO Last_Transactions AS T
USING Daily_Transactions AS S
ON T.User_ID = S.User_ID
WHEN MATCHED THEN
    UPDATE SET T.Transaction_Amount = S.Transaction_Amount
WHEN NOT MATCHED THEN
    INSERT (User_ID, Transaction_Amount) VALUES (S.User_ID, S.Transaction_Amount);

select * from Last_Transactions

-----------------------------------------------------------------------------------
-- 1
use SD
CREATE VIEW v_clerk
AS
SELECT EmpNo, ProjectNo, Enter_Date
FROM Works_on
WHERE Job = 'Clerk';

select * from v_clerk

-- 2
CREATE VIEW v_without_budget
AS
SELECT ProjectNo, ProjectName
FROM db_accessadmin.Project
WHERE Budget IS NULL;

select * from v_without_budget

-- 3
CREATE VIEW v_count
AS
SELECT P.Projectname, COUNT(W.Job) AS [Jobs Count]
FROM db_accessadmin.Project P 
JOIN Works_on W ON P.Projectno = W.Projectno
GROUP BY P.Projectname;

select * from v_count

-- 4
CREATE VIEW v_project_p2
AS
SELECT EmpNo
FROM v_clerk
WHERE ProjectNo = 'p2';

select * from v_project_p2

-- 5
ALTER VIEW v_without_budget
AS
SELECT * FROM db_accessadmin.Project
WHERE ProjectNo IN ('p1', 'p2');

select * from v_without_budget

-- 6
DROP VIEW v_clerk;
DROP VIEW v_count;

-- 7
CREATE VIEW v_dept_d2
AS
SELECT E.EmpNo, E.Emp_Lname
FROM HumanResource.Employee E
WHERE E.DeptNo = 'd2';

select * from v_dept_d2

-- 8
SELECT Emp_Lname
FROM v_dept_d2
WHERE Emp_Lname LIKE '%J%';

-- 9
CREATE VIEW v_dept
AS
SELECT DeptNo, DeptName
FROM Company.Department;

select * from v_dept

-- 10
INSERT INTO v_dept (DeptNo, DeptName)
VALUES ('d4', 'Development');

select * from v_dept

-- 11
CREATE VIEW v_2006_check
AS
SELECT EmpNo, ProjectNo, Enter_Date
FROM Works_on
WHERE Enter_Date BETWEEN '2006-01-01' AND '2006-12-31';

select * from v_2006_check