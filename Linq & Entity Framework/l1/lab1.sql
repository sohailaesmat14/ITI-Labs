CREATE TABLE Employees (
    Id INT PRIMARY KEY,
    Name NVARCHAR(100),
    Department NVARCHAR(100)
);

INSERT INTO Employees (Id, Name, Department)
VALUES 
(1, 'Ahmed Hassan', 'IT'),
(2, 'Sarah Mohamed', 'HR'),
(3, 'John Doe', 'Finance'),
(4, 'Nour Ali', 'Marketing'),
(5, 'Emily Smith', 'Sales');

select * from Employees