--1
select Dnum , Dname , MGRSSN , (Fname+Lname) as MngName
from Departments , Employee
where MGRSSN=SSN
--2
select Dname ,Pname
from Departments d , Project p
where d.Dnum=p.Dnum
--3
select *
from Employee , Dependent
where SSN =ESSN
--4
SELECT Dependent_name, d.Sex
FROM Employee e, Dependent d
WHERE e.SSN = d.ESSN
  AND e.Sex = 'F'
  AND d.Sex = 'F'

UNION

SELECT Dependent_name, e.Sex
FROM Employee e, Dependent d
WHERE e.SSN = d.ESSN
  AND e.Sex = 'M'
  AND d.Sex = 'M'

--5
select Pnumber , Pname , city
from Project
where city in ('Cairo','Alex')

--6
select *
from Project
where Pname like 'a%'

--7
select *
from employee
where dno = 30 and (salary between 1000 and 2000)

--8
select *
from employee e , Works_for , Project
where ESSn=SSN
and Pno = Pnumber
and dnum = 10
and Hours >= 10
and Pname = 'Al Rabwah'

--9
SELECT E.Fname, E.Lname
FROM Employee E, Employee S
WHERE E.Superssn = S.SSN
  and S.Fname = 'Kamel'
  and S.Lname = 'Mohamed';

 --10
SELECT P.Pname, SUM(W.Hours) as TotalHoursPerWeek
FROM Project P, Works_for W
WHERE P.Pnumber = W.Pno
GROUP BY P.Pname;

--11
select fname , lname , Pname
from Employee e, project p
where e.Dno = p.Dnum
order by Pname

--12
select d.*
from Departments d , Employee e
where d.Dnum = e.Dno
and e.SSN = (select min(ssn) from Employee)

--13
select d.Dname , max(e.Salary) as MaxSalary ,min(e.Salary)as MinSalary ,avg(e.Salary)as AvgSalary
from Departments d , Employee e
where d.Dnum = e.Dno
group by d.Dname

--14
select e.Lname
from Employee e, Departments
where ssn = MGRSSN 
and ssn not in (select ESSN from Dependent)

--15
select d.Dname , d.Dnum , count(e.Fname) as 'number of its employees'
from Departments d, Employee e
where d.Dnum = e.Dno
group by d.Dname , D.Dnum
having avg(e.Salary) < all (select avg(Salary) from Employee)

--16
select e.Fname,e.Lname,p.Pname
from Employee e, Project p, Departments d
order by d.Dname , e.Lname , e.Fname

--17
select distinct p.Dnum , d.Dname , e.Lname , e.Address , e.Bdate
from Project p , Departments d , Employee e
where p.Dnum = d.Dnum
and d.MGRSSN = e.SSN
and p.City='Cairo'


