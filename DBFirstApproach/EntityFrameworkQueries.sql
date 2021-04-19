///////////////////////////////////////////////////DI
-- Create EmployeeDB database
CREATE DATABASE EmployeeDB
GO

USE EmployeeDB
GO

-- Create Employee Table
CREATE TABLE Employee
(
  EmployeeID INT PRIMARY KEY IDENTITY(1,1),
  Name VARCHAR(100),
  Gender VARCHAR(100),
  Salary INT,
  Dept VARCHAR(50)
)
GO

-- Populate some test data into Employee table
INSERT INTO Employee VALUES('Pranaya', 'Male', 10000, 'IT' )
INSERT INTO Employee VALUES('Anurag', 'Male', 15000, 'HR' )
INSERT INTO Employee VALUES('Priyanka', 'Female', 22000, 'HR' )
INSERT INTO Employee VALUES('Sambit', 'Male', 20000, 'IT' )
INSERT INTO Employee VALUES('Preety', 'Female', 25000, 'IT' )
INSERT INTO Employee VALUES('Hina', 'Female', 20000, 'HR' )
GO

SELECT * FROM Employee
GO

////////////////////////////////////////////////////////////////EntityFramework

IF EXISTS (SELECT * FROM sys.databases WHERE name = 'EF_Demo_DB')
  DROP DATABASE EF_Demo_DB;
GO
-- Create the School database.
CREATE DATABASE EF_Demo_DB;
GO
-- Specify a simple recovery model 
-- to keep the log growth to a minimum.
ALTER DATABASE EF_Demo_DB 
  SET RECOVERY SIMPLE;
GO
USE EF_Demo_DB;
GO
-- Create Departments table
CREATE TABLE Departments
(
     ID INT PRIMARY KEY IDENTITY(1,1),
     Name VARCHAR(50),
     Location VARCHAR(50)
)
Go
-- Create Employees table.
CREATE TABLE Employees
(
     ID INT PRIMARY KEY IDENTITY(1,1),
     Name VARCHAR(50),
     Email VARCHAR(50),
     Gender VARCHAR(50),
     Salary INT,
     DepartmentId INT FOREIGN KEY REFERENCES Departments(ID)
)
Go
--Populate the Departments table with some test data
INSERT INTO Departments VALUES ('IT', 'Mumbai')
INSERT INTO Departments VALUES ('HR', 'Delhi')
INSERT INTO Departments VALUES ('Sales', 'Hyderabad')
Go
--Populate the Employees table with some test data
INSERT INTO Employees VALUES ('Mark', 'Mark@g.com', 'Male', 60000, 1)
INSERT INTO Employees VALUES ('Steve', 'Steve@g.com', 'Male', 45000, 3)
INSERT INTO Employees VALUES ('Pam', 'Pam@g.com', 'Female', 60000, 1)
INSERT INTO Employees VALUES ('Sara', 'Sara@g.com', 'Female', 345000, 3)
INSERT INTO Employees VALUES ('Ben', 'Ben@g.com', 'Male', 70000, 1)
INSERT INTO Employees VALUES ('Philip', 'Philip@g.com', 'Male', 45000, 2)
INSERT INTO Employees VALUES ('Mary', 'Mary@g.com', 'Female', 30000, 2)
INSERT INTO Employees VALUES ('Valarie', 'Valarie@g.com', 'Female', 35000, 3)
INSERT INTO Employees VALUES ('John', 'John@g.com', 'Male', 80000, 1)
Go

/////////////////////////////////////////////DatabaseFirst

-- Create the EF_Demo_DB database.
CREATE DATABASE EF_Demo_DB;
GO
-- Use EF_Demo_DB
USE EF_Demo_DB;
GO
-- Create Standard Table
CREATE TABLE Standard(
 StandardId INT PRIMARY KEY IDENTITY(1,1),
 StandardName VARCHAR(100),
 Description VARCHAR(100)
)
GO
-- Standard table data
INSERT INTO Standard VALUES('STD1', 'Outstanding');
INSERT INTO Standard VALUES('STD2', 'Good');
INSERT INTO Standard VALUES('STD3', 'Average');
INSERT INTO Standard VALUES('STD4', 'Below Average');
GO
-- Create Teacher Table
CREATE TABLE Teacher(
 TeacherId INT PRIMARY KEY IDENTITY(1,1),
 FirstName VARCHAR(100),
 LastName VARCHAR(100),
 StandardId INT FOREIGN KEY REFERENCES Standard(StandardId)
)
GO
-- Teacher table data
INSERT INTO Teacher VALUES('Anurag', 'Mohanty', 1);
INSERT INTO Teacher VALUES('Preety', 'Tiwary', 2);
INSERT INTO Teacher VALUES('Priyanka', 'Dewangan', 3);
INSERT INTO Teacher VALUES('Sambit', 'Satapathy', 3);
INSERT INTO Teacher VALUES('Hina', 'Sharma', 2);
INSERT INTO Teacher VALUES('Sishanta', 'Jena', 1);
GO
-- Create Course Table
CREATE TABLE Course(
 CourseId INT PRIMARY KEY IDENTITY(1,1),
 CourseName VARCHAR(100),
 TeacherId INT FOREIGN KEY REFERENCES Teacher(TeacherId)
)
GO
-- Course table data
INSERT INTO Course VALUES('.NET', 1);
INSERT INTO Course VALUES('Java', 2);
INSERT INTO Course VALUES('PHP', 3);
INSERT INTO Course VALUES('Oracle', 4);
INSERT INTO Course VALUES('Android', 5);
INSERT INTO Course VALUES('Python', 6);
GO
-- Create Student Table
CREATE TABLE Student(
 StudentId INT PRIMARY KEY IDENTITY(1,1),
 FirstName VARCHAR(100),
 LastName VARCHAR(100),
 StandardId INT FOREIGN KEY REFERENCES Standard(StandardId)
)
GO
-- Student table data
INSERT INTO Student VALUES('Virat', 'Kohli', 1);
INSERT INTO Student VALUES('Rohit', 'Sharma', 2);
INSERT INTO Student VALUES('Lokesh', 'Rahul', 3);
INSERT INTO Student VALUES('Smriti', 'Mandana', 4);
GO
-- Create StudentAddress Table
CREATE TABLE StudentAddress(
 StudentId INT PRIMARY KEY FOREIGN KEY REFERENCES Student(StudentId),
 Address1 VARCHAR(100),
 Address2 VARCHAR(100),
 Mobile VARCHAR(10),
 Email VARCHAR(100)
)
GO
-- StudentAddress table data
INSERT INTO StudentAddress VALUES(1, 'Lane1', 'Lane2', '1111111111', '1@dotnettutorials.net');
INSERT INTO StudentAddress VALUES(2, 'Lane3', 'Lane4', '2222222222', '2@dotnettutorials.net');
INSERT INTO StudentAddress VALUES(3, 'Lane5', 'Lane6', '3333333333', '3@dotnettutorials.net');
INSERT INTO StudentAddress VALUES(4, 'Lane7', 'Lane8', '4444444444', '4@dotnettutorials.net');
GO
-- Create StudentCourse Table
CREATE TABLE StudentCourse(
 StudentId INT NOT NULL FOREIGN KEY REFERENCES Student(StudentId),
    CourseId INT NOT NULL FOREIGN KEY REFERENCES Course(CourseId)
    PRIMARY KEY (StudentId, CourseId)
)
GO
-- StudentCourse table data
INSERT INTO StudentCourse VALUES(1,1);
INSERT INTO StudentCourse VALUES(1,2);
INSERT INTO StudentCourse VALUES(2,3);
INSERT INTO StudentCourse VALUES(2,4);
INSERT INTO StudentCourse VALUES(3,1);
INSERT INTO StudentCourse VALUES(3,6);
INSERT INTO StudentCourse VALUES(4,5);
INSERT INTO StudentCourse VALUES(4,6);
GO

CREATE PROCEDURE spGetCoursesByStudentId
 @StudentID INT
AS
BEGIN
 SELECT c.CourseId, c.CourseName, c.TeacherId
    FROM Student s LEFT OUTER JOIN StudentCourse sc on sc.StudentId = s.StudentId 
 LEFT OUTER JOIN Course c on c.CourseId = sc.CourseId
    WHERE s.StudentId = @StudentId
END
GO
-- Insert Student stored Procedure
CREATE PROCEDURE spInsertStudent
 @StandardId INT,
 @FirstName VARCHAR(100),
 @LastName VARCHAR(100)
AS
BEGIN
     INSERT INTO Student(FirstName ,LastName, StandardId)
     VALUES(@FirstName, @LastName, @StandardId);
     SELECT SCOPE_IDENTITY() AS StudentId
END
GO
-- Update Student stored Procedure
CREATE PROCEDURE spUpdateStudent
 @StudentId INT,
 @StandardId INT,
 @FirstName VARCHAR(100),
 @LastName VARCHAR(100)
AS
BEGIN
    UPDATE Student
 SET FirstName = @FirstName,
     LastName = @LastName,
     StandardId = @StandardId
 WHERE StudentId = @StudentId;
END
GO
-- Delete Student stored Procedure
CREATE PROCEDURE spDeleteStudent
 @StudentId int
AS
BEGIN
    DELETE FROM Student
 WHERE StudentId = @StudentId
END
GO
-- Student Course View
CREATE VIEW vwStudentCourse
AS
 SELECT s.StudentId, 
   s.FirstName, 
   s.LastName,
   sc.CourseId, 
   c.CourseName
 FROM    Student s INNER JOIN StudentCourse sc
 ON  s.StudentId = sc.StudentId 
 INNER JOIN Course c ON sc.CourseId = c.CourseId
GO

