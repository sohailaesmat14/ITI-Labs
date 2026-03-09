use iti

---1
CREATE FUNCTION GetMonthName(@Date DATE)
RETURNS VARCHAR(20)
AS
BEGIN
    RETURN DATENAME(MONTH, @Date)
END
SELECT dbo.GetMonthName('2025-05-15');

---2
CREATE FUNCTION GetNumbersBetween(@Start INT, @End INT)
RETURNS @ResultTable TABLE (Value INT)
AS
BEGIN
    DECLARE @Current INT = @Start + 1
    
    WHILE @Current < @End
    BEGIN
        INSERT INTO @ResultTable (Value)
        VALUES (@Current)
        
        SET @Current = @Current + 1
    END    
    RETURN
END
SELECT * FROM dbo.GetNumbersBetween(0, 10);

--3
CREATE FUNCTION GetStudentDept(@StID INT)
RETURNS TABLE
AS
RETURN
(
    SELECT S.St_Fname + ' ' + S.St_Lname AS FullName, D.Dept_Name
    FROM Student S
    INNER JOIN Department D ON S.Dept_Id = D.Dept_Id
    WHERE S.St_Id = @StID
)
SELECT * FROM dbo.GetStudentDept(1);

--4
CREATE FUNCTION CheckNameStatus(@StID INT)
RETURNS VARCHAR(100)
AS
BEGIN
    DECLARE @Fname VARCHAR(50), @Lname VARCHAR(50), @Msg VARCHAR(100)
    SELECT @Fname = St_Fname, @Lname = St_Lname
    FROM Student WHERE St_Id = @StID
--a
    IF @Fname IS NULL AND @Lname IS NULL
        SET @Msg = 'First name & last name are null'
--b
    ELSE IF @Fname IS NULL
        SET @Msg = 'First name is null'
--c
    ELSE IF @Lname IS NULL
        SET @Msg = 'Last name is null'
--d
    ELSE
        SET @Msg = 'First name & last name are not null'

    RETURN @Msg
END
SELECT dbo.CheckNameStatus(13); --13

--5
CREATE FUNCTION GetManagerDetails(@MgrID INT)
RETURNS TABLE
AS
RETURN
(
    SELECT D.Dept_Name, I.Ins_Name, I.Ins_Degree
    FROM Department D
    INNER JOIN Instructor I ON D.Dept_Manager = I.Ins_Id
    WHERE I.Ins_Id = @MgrID
)
SELECT * FROM dbo.GetManagerDetails(10); --all data are null in table

--6
CREATE FUNCTION GetStudentNamesByType(@Type VARCHAR(20))
RETURNS @NameTable TABLE (StudentName VARCHAR(100))
AS
BEGIN
--a
    IF @Type = 'first name'
        INSERT INTO @NameTable
        SELECT ISNULL(St_Fname, '') FROM Student
--b
    ELSE IF @Type = 'last name'
        INSERT INTO @NameTable
        SELECT ISNULL(St_Lname, '') FROM Student
--c       
    ELSE IF @Type = 'full name'
        INSERT INTO @NameTable
        SELECT ISNULL(St_Fname, '') + ' ' + ISNULL(St_Lname, '') FROM Student
    RETURN
END
SELECT * FROM dbo.GetStudentNamesByType('first name');
SELECT * FROM dbo.GetStudentNamesByType('full name');

--7
SELECT St_Id, 
       SUBSTRING(St_Fname, 1, LEN(St_Fname) - 1) AS NameMinusLastChar
FROM Student


--8
DELETE FROM Stud_Course
WHERE St_Id IN (
    SELECT S.St_Id
    FROM Student S
    INNER JOIN Department D ON S.Dept_Id = D.Dept_Id
    WHERE D.Dept_Name = 'SD'
)


--bonus

-- 1
CREATE TABLE Employees (
    EmpID hierarchyid PRIMARY KEY,
    EmpName NVARCHAR(50),
    Title NVARCHAR(50)
);

INSERT INTO Employees (EmpID, EmpName, Title)
VALUES 
(hierarchyid::GetRoot(), 'Ahmed', 'CEO'),      
('/1/', 'Mona', 'HR Manager'),                 
('/2/', 'Sayed', 'IT Manager'),                
('/2/1/', 'Hany', 'Software Developer');       

SELECT EmpID.ToString() AS Path, EmpName, Title 
FROM Employees;

--2
DECLARE @Counter INT = 3001;

WHILE @Counter <= 6000
BEGIN
    INSERT INTO Student (st_id, st_fname, st_lname)
    VALUES (@Counter, 'Jane', 'Smith');

    SET @Counter = @Counter + 1; 
END

SELECT @Counter AS 'Total Counter Value';