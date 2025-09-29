use KANINIBATCH2;
CREATE TABLE STUDENT(STUDENT_ID INT PRIMARY KEY, NAME VARCHAR(20),COURSEID INT,CITY VARCHAR(15));
CREATE TABLE course (course_id INT PRIMARY KEY,course_name VARCHAR(50) NOT NULL,credits INT);
CREATE TABLE teacher (teacher_id INT PRIMARY KEY,teacher_name VARCHAR(50) NOT NULL,main_course_id INT);
INSERT INTO STUDENT  VALUES
(101, 'Rahul Sharma', 101, 'Mumbai'),
(102, 'Priya Singh', 103, 'Delhi'),
(103, 'Amit Gupta', 101, 'Bengaluru'),
(104, 'Sneha Kumari', 102, 'Chennai'),
(105, 'Vikas Reddy', 105, 'Hyderabad'), 
(106, 'Anjali Devi', 103, 'Mumbai'),
(107, 'Arjun Patel', 106, 'Delhi'); 

INSERT INTO course  VALUES
(101, 'Database Management', 4),
(102, 'Web Development', 3),
(103, 'Data Science', 5),
(104, 'Cyber Security', 4);
insert into course values(107, 'UI', 4);
delete from course where course_id = 107;

INSERT INTO teacher  VALUES
(1, 'Dr. Anand Kumar', 101),
(2, 'Prof. Sarita Rao', 103),
(3, 'Mr. Deepak Mehta', 102),
(4, 'Ms. Preeti Verma', 104),
(5, 'Dr. Rajeev Sinha', 999);
ALTER TABLE STUDENT
ADD CONSTRAINT FK_STUDENT_COURSE1 FOREIGN KEY (COURSEID)
REFERENCES course (course_id); --THIS DID NOT WORK AS THE DATA IS INCONSISTENT. IN ORDER TO ADD A FK CONSTRAINT, DATA HAS TO BE CONSISTENT.

SELECT name, city FROM student;
SELECT name, city
FROM student
WHERE city = 'Mumbai'; --USING THE WHERE CLAUSE

SELECT course_id 
from course 
where credits>3

SELECT                 -- Using inner join. It displays only the common columns in the tables that are using inner join. The data that is not matched to other tables is left out.In this case student with id 105 is left. 
    s.STUDENT_ID as sid,
    s.name AS StudentName,
    c.course_name AS CourseName
FROM
    student s
INNER JOIN
    course c ON s.courseid = c.course_id;

SELECT                               --In this case teacher with courseid 999 is not in the result as there is no course in course table with 999 id.
    t.teacher_name AS TeacherName,
    c.course_name AS MainCourseTaught
FROM
    teacher t
INNER JOIN
    course c ON t.main_course_id = c.course_id;

SELECT                          -- Selecting the StudentName, City, and CourseName for all students who are linked to an existing course.
    s.name as STUDENT_NAME,
    s.CITY,
    c.course_name
FROM 
    STUDENT s
INNER JOIN
    course c ON s.courseid = c.course_id 

SELECT --Usiing left join to get the vakues that are not linked to other values as well in the result.
    s.name AS StudentName,
    s.city,
    c.course_name AS CourseName,
    c.credits
FROM
    student s
LEFT JOIN
    course c ON s.courseid = c.course_id;

SELECT
    t.teacher_name AS TeacherName,
    c.course_name AS MainCourseTaught
FROM
    teacher t
LEFT JOIN
    course c ON t.main_course_id = c.course_id;

SELECT
    t.teacher_name AS TeacherName,
    c.course_name AS MainCourseTaught
FROM
    course c
LEFT JOIN
    teacher t ON c.course_id = t.main_course_id; 

SELECT --Usiing left join to get the vakues that are not linked to other values as well in the result.
    s.name AS StudentName,
    s.city,
    c.course_name AS CourseName,
    c.credits
FROM
    student s
LEFT JOIN
    course c ON s.courseid = c.course_id
where 
    c.course_name is null; 

SELECT --Right join to display student data
    c.course_name,
    s.name AS StudentName
FROM
    student s
RIGHT JOIN
    course c ON s.courseid = c.course_id;

SELECT
    c.course_name AS CourseName,
    t.teacher_name AS TeacherName
FROM
    course c        
RIGHT JOIN
    teacher t ON c.course_id = t.main_course_id;

SELECT 
    s.NAME AS Sname,
    c.course_name  AS Cname
from 
    course c
right join 
    STUDENT s on s.courseid = c.course_id;

SELECT 
   t.teacher_name as TEACHER,
   c.course_name
FROM
   course c
RIGHT JOIN 
   teacher t ON c.course_id = t.main_course_id
WHERE 
   c.course_id is null;

SELECT      --Full join. It returns all the data from both the tables. It is like the combination of inner join, left and right join.
    s.name AS StudentName,
    s.city,
    s.courseid AS StudentAssignedCourseID,
    c.course_name AS CourseName,
    c.credits AS CourseCredits,
    c.course_id AS CourseIDInTable
FROM
    student s
FULL OUTER JOIN
    course c ON s.courseid = c.course_id;
SELECT      
    s.name AS StudentName,
    s.city,
    s.courseid AS StudentAssignedCourseID,
    c.course_name AS CourseName,
    c.credits AS CourseCredits,
    c.course_id AS CourseIDInTable
FROM
    student s
FULL OUTER JOIN
    course c ON s.courseid = c.course_id
WHERE
    s.COURSEID IS NULL OR c.course_id is null;

SELECT --Multi join to display student, course and teacher data using left join
    s.name AS Name,
    c.course_name AS CourseNAme,
    t.teacher_name AS Teacher
FROM
    STUDENT s                          
LEFT JOIN
    course c ON s.courseid = c.course_id 
LEFT JOIN
    teacher t ON c.course_id = t.main_course_id;

SELECT
    t1.teacher_name AS Teacher1,
    t1.main_course_id AS SharedC,
    t2.teacher_name AS Teacher2
FROM
    teacher t1               
INNER JOIN
    teacher t2               
ON
    t1.main_course_id = t2.main_course_id 
WHERE
    t1.teacher_id != t2.teacher_id   
    AND t1.teacher_id < t2.teacher_id; 
  
SELECT        -- Subqueries practice with IN keyword 
    s.name,
    s.city,
    s.courseid
FROM
    student s
WHERE
    s.courseid IN (SELECT course_id FROM course WHERE credits > 4);

SELECT
    c.course_name,
    c.credits
FROM
    course c
WHERE
    c.course_id IN (SELECT main_course_id FROM teacher WHERE teacher_id > 3);

SELECT         
    s.name,
    s.city,
    s.courseid
   
FROM
    student s
WHERE
    s.COURSEID not in (select course_id from course where credits = 3);

SELECT   --Using exists with subquery.
    s.name,
    s.city
FROM
    student s
WHERE
    EXISTS (SELECT 1 FROM course c WHERE c.course_id = s.courseid);

SELECT
    c.course_name,
    c.credits
FROM
    course c
WHERE
    EXISTS (SELECT 1 FROM student s WHERE s.courseid = c.course_id);

SELECT
    t.teacher_name AS NAME
FROM
    teacher t
WHERE
    EXISTS (SELECT 1
            FROM course c
            WHERE c.course_id = t.main_course_id 
              AND c.credits > 4);

SELECT
    c.course_id AS cid,
    c.course_name AS cname
FROM
    course c
WHERE
    NOT EXISTS (SELECT 1
                FROM teacher t
                WHERE t.main_course_id = c.course_id 
                );








--Assignment 
create table tblShippers(shopperid int,country_name varchar(20));
create table tblorderDetails(orderid int, productid int,unitprice int, quantity int, discount int);
create table tblCustomers(customerid int,companyname varchar(20),contactname varchar(20),contacttitle varchar(15),address varchar(20),country varchar(20));
create table tblOrders(orderid int, customer_id int,employeeid int,orderdate date,reqdate date,shippeddate date); 
ALTER TABLE tblShippers
ADD CONSTRAINT MyConstraint
DEFAULT 'CANADA' FOR country_name;

ALTER TABLE tblCustomers
ADD CONSTRAINT MyConstraint2
unique (companyname);

ALTER TABLE tblOrderDetails
ADD CONSTRAINT MyConstraint4
check (quantity>0);

ALTER TABLE tblOrders
ADD CONSTRAINT MyConstraint3
check (shippeddate > orderdate);

exec sp_help tblShippers;
select * from STUDENT;




