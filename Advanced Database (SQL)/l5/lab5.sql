--1
use iti
CREATE PROC GetStudentCountPerDept
AS
SELECT d.Dept_Name, COUNT(s.St_Id) AS StudentCount
FROM Department d JOIN Student s
ON d.Dept_Id = s.Dept_Id
GROUP BY d.Dept_Name

GetStudentCountPerDept

--2
use company_sd
CREATE PROC CheckProjectEmployees
AS
	DECLARE @count INT
	SELECT @count = COUNT(ESSN) FROM works_for w WHERE Pno = 100
	IF @count >= 3
	BEGIN
		PRINT 'The number of employees in the project p1 is 3 or more'
	END
	ELSE
	BEGIN
		PRINT 'The following employees work for the project p1'
		SELECT e.Fname, e.Lname
		FROM Employee e JOIN works_for w ON e.SSN = w.ESSN
		WHERE w.Pno = 100
END

CheckProjectEmployees

--3
CREATE PROC UpdateProjectEmployee @oldEmp INT, @newEmp INT, @projNo INT
AS
BEGIN
    BEGIN TRY
        IF NOT EXISTS (SELECT 1 FROM works_for WHERE ESSN = @oldEmp AND Pno = @projNo)
        BEGIN
            RETURN
        END
        UPDATE works_for
        SET ESSN = @newEmp
        WHERE ESSN = @oldEmp AND Pno = @projNo
    END TRY
    BEGIN CATCH
        SELECT ERROR_MESSAGE() AS ErrorMessage
    END CATCH
END

UpdateProjectEmployee 112233 , 512463 , 100

--4
ALTER TABLE Project ADD Budget INT

CREATE TABLE Project_Audit (
    ProjectNo VARCHAR(10),
    UserName VARCHAR(50),
    ModifiedDate DATE,
    Budget_Old INT,
    Budget_New INT
)

CREATE TRIGGER TR_AuditProjectBudget
ON Project
AFTER UPDATE
AS
IF UPDATE(Budget)
BEGIN
    INSERT INTO Project_Audit (ProjectNo, UserName, ModifiedDate, Budget_Old, Budget_New)
    SELECT d.Pnumber, SUSER_NAME(), GETDATE(), d.Budget, i.Budget
    FROM inserted i JOIN deleted d ON i.Pnumber = d.Pnumber
END

UPDATE Project SET Budget = 250000 WHERE Pnumber = 100;
SELECT * FROM Project_Audit;

--5
use iti
CREATE TRIGGER TR_PreventInsertDept
ON Department
INSTEAD OF INSERT
AS
BEGIN
    PRINT 'You cannot insert a new record in that table'
END

INSERT INTO Department (Dept_Id, Dept_Name, Dept_Desc, Dept_Location)
VALUES (100, 'AI Department', 'Artificial Intelligence', 'Cairo');

SELECT * FROM Department WHERE Dept_Id = 100;

--6
use company_sd
CREATE TRIGGER TR_PreventEmployeeInsertInMarch
ON Employee
FOR INSERT
AS
IF FORMAT(GETDATE(), 'MMMM') = 'March'
BEGIN
    ROLLBACK
    PRINT 'Insertion is not allowed during March'
END

INSERT INTO Employee (SSN, Fname, Lname, Salary)
VALUES (998877, 'Sara', 'Ahmed', 5000);



--7
use iti
CREATE TABLE Student_Audit (
    ServerUserName VARCHAR(50),
    Date DATETIME,
    Note VARCHAR(MAX)
)

CREATE TRIGGER TR_StudentInsertAudit
ON Student
AFTER INSERT
AS
BEGIN
    INSERT INTO Student_Audit (ServerUserName, Date, Note)
    SELECT SUSER_NAME(), GETDATE(), 
    SUSER_NAME() + ' Insert New Row with Key=' + CAST(St_Id AS VARCHAR) + ' in table Student'
    FROM inserted
END

INSERT INTO Student (St_Id, St_Fname, St_Lname, St_Age, Dept_Id)
VALUES (500, 'Ahmed', 'Ali', 22, 10);

SELECT * FROM Student_Audit

--8
CREATE TRIGGER TR_StudentDeleteAudit
ON Student
INSTEAD OF DELETE
AS
BEGIN
    INSERT INTO Student_Audit (ServerUserName, Date, Note)
    SELECT SUSER_NAME(), GETDATE(), 
    'try to delete Row with Key=' + CAST(St_Id AS VARCHAR)
    FROM deleted
END

DELETE FROM Student WHERE St_Id = 500;
SELECT * FROM Student
SELECT * FROM Student_Audit

