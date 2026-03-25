--1
use company_SD
declare c_sal cursor
for select Salary from Employee
for update

declare @sal int
open c_sal
fetch c_sal into @sal

while @@FETCH_STATUS = 0
begin
    if @sal < 3000
        update Employee set Salary = Salary * 1.1 where current of c_sal
    else
        update Employee set Salary = Salary * 1.2 where current of c_sal    
    fetch c_sal into @sal
end

close c_sal
deallocate c_sal

--2
use iti
declare c_dept cursor
for select d.Dept_Name, i.Ins_Name 
    from Department d join Instructor i 
    on i.Ins_Id = d.Dept_Manager

declare @dname varchar(20), @mname varchar(20)
open c_dept
fetch c_dept into @dname, @mname

while @@FETCH_STATUS = 0
begin
    select @dname as Department, @mname as Manager
    fetch c_dept into @dname, @mname
end

close c_dept
deallocate c_dept

--3
declare c_names cursor
for select St_Fname from Student where St_Fname is not null

declare @name varchar(20), @allNames varchar(max) = ''
open c_names
fetch c_names into @name

while @@FETCH_STATUS = 0
begin
    set @allNames = concat(@allNames, @name, ', ')
    fetch c_names into @name
end

select @allNames as AllStudents
close c_names
deallocate c_names

--4-1
CREATE PROC sp_GetMonthName @Date DATE
AS
    SELECT DATENAME(MONTH, @Date) AS MonthName

EXEC sp_GetMonthName '2025-05-15'

--4-2
CREATE PROC sp_GetNumbersBetween @Start INT, @End INT
AS
    DECLARE @Current INT = @Start + 1
    DECLARE @TempTable TABLE (Value INT)

    WHILE @Current < @End
    BEGIN
        INSERT INTO @TempTable VALUES (@Current)
        SET @Current = @Current + 1
    END
    SELECT * FROM @TempTable

EXEC sp_GetNumbersBetween 0, 10

--4-3
CREATE PROC sp_GetStudentDept @StID INT
AS
    SELECT S.St_Fname + ' ' + S.St_Lname AS FullName, D.Dept_Name
    FROM Student S
    INNER JOIN Department D ON S.Dept_Id = D.Dept_Id
    WHERE S.St_Id = @StID

EXEC sp_GetStudentDept 1

--4-4
CREATE PROC sp_CheckNameStatus @StID INT
AS
    DECLARE @Fname VARCHAR(50), @Lname VARCHAR(50)
    SELECT @Fname = St_Fname, @Lname = St_Lname FROM Student WHERE St_Id = @StID

    IF @Fname IS NULL AND @Lname IS NULL
        SELECT 'First name & last name are null' AS Status
    ELSE IF @Fname IS NULL
        SELECT 'First name is null' AS Status
    ELSE IF @Lname IS NULL
        SELECT 'Last name is null' AS Status
    ELSE
        SELECT 'First name & last name are not null' AS Status

EXEC sp_CheckNameStatus 13

--4-5
CREATE PROC sp_GetManagerDetails @MgrID INT
AS
    SELECT D.Dept_Name, I.Ins_Name, I.Ins_Degree
    FROM Department D
    INNER JOIN Instructor I ON D.Dept_Manager = I.Ins_Id
    WHERE I.Ins_Id = @MgrID

EXEC sp_GetManagerDetails 10

--4-6
CREATE PROC sp_GetStudentNamesByType @Type VARCHAR(20)
AS
    IF @Type = 'first name'
        SELECT ISNULL(St_Fname, '') FROM Student
    ELSE IF @Type = 'last name'
        SELECT ISNULL(St_Lname, '') FROM Student
    ELSE IF @Type = 'full name'
        SELECT ISNULL(St_Fname, '') + ' ' + ISNULL(St_Lname, '') FROM Student

EXEC sp_GetStudentNamesByType 'full name'

--5
CREATE SEQUENCE LabSeq
    START WITH 1
    INCREMENT BY 1
    MAXVALUE 10
    NO CYCLE; 

create table TestSeq (ID int)
insert into TestSeq values (NEXT VALUE FOR LabSeq)

--6
CREATE DATABASE Adv_Snapshot
ON ( NAME = AdventureWorks2022_Data, 
     FILENAME = 'D:\ITI\9.advanced database\lab\l6\Adv_Snapshot.ss' )
AS SNAPSHOT OF AdventureWorks2022;

--7
-- Full Backup
BACKUP DATABASE SD 
TO DISK = 'D:\ITI\9.advanced database\lab\l6\SD_Full.bak';

-- Differential Backup
BACKUP DATABASE SD 
TO DISK = 'D:\ITI\9.advanced database\lab\l6\SD_Diff.bak' 
WITH DIFFERENTIAL;
