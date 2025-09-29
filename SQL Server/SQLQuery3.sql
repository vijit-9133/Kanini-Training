use KANINIBATCH2
create table Flight_details(Flight_id varchar(20)primary key,Flight_name varchar(20),Flight_source varchar(20),Flight_destination varchar(20),Flight_date date,Flight_seat int)
create table passengers(pass_id varchar(20) primary key,pass_name varchar(20),DOB date,Address varchar(20),Phone bigint,Email varchar(20))
create table booking(booking_id varchar(20) primary key,flightid varchar(20) references Flight_details(Flight_id),Booking_date date,Amt int)
create table booking_details(Bookingid varchar(20) references booking(booking_id),
Passid varchar(20)references passengers(pass_id),
CONSTRAINT PK_Bookd PRIMARY KEY (Bookingid, Passid))

INSERT INTO Flight_details VALUES ('FL001', 'Air India', 'Mumbai', 'Delhi', '2025-08-01', 150);
INSERT INTO Flight_details VALUES ('FL002', 'IndiGo', 'Bengaluru', 'Chennai', '2025-08-02', 180);
INSERT INTO Flight_details VALUES ('FL003', 'Vistara', 'Kolkata', 'Hyderabad', '2025-08-03', 120);
INSERT INTO Flight_details VALUES ('FL004', 'SpiceJet', 'Goa', 'Mumbai', '2025-08-04', 160);
INSERT INTO Flight_details VALUES ('FL005', 'Akasa Air', 'Delhi', 'Pune', '2025-08-05', 140);
INSERT INTO Flight_details VALUES ('FL006', 'Air India', 'Chennai', 'Kolkata', '2025-08-06', 170);
INSERT INTO Flight_details VALUES ('FL007', 'IndiGo', 'Hyderabad', 'Ahmedabad', '2025-08-07', 130);
INSERT INTO Flight_details VALUES ('FL008', 'Vistara', 'Mumbai', 'Bengaluru', '2025-08-08', 190);
INSERT INTO Flight_details VALUES ('FL009', 'SpiceJet', 'Kochi', 'Delhi', '2025-08-09', 110);
INSERT INTO Flight_details VALUES ('FL010', 'Akasa Air', 'Patna', 'Goa', '2025-08-10', 155);

INSERT INTO passengers VALUES ('P001', 'Rahul Sharma', '1990-05-15', 'Delhi', 9876543210, 'rahul@email.com');
INSERT INTO passengers VALUES ('P002', 'Priya Singh', '1988-11-22', 'Mumbai', 9876543211, 'priya@email.com');
INSERT INTO passengers VALUES ('P003', 'Amit Gupta', '1995-03-01', 'Bengaluru', 9876543212, 'amit@email.com');
INSERT INTO passengers VALUES ('P004', 'Sneha Kumari', '2000-07-10', 'Chennai', 9876543213, 'sneha@email.com');
INSERT INTO passengers VALUES ('P005', 'Vikas Reddy', '1985-01-20', 'Hyderabad', 9876543214, 'vikas@email.com');
INSERT INTO passengers VALUES ('P006', 'Anjali Devi', '1992-09-03', 'Kolkata', 9876543215, 'anjali@email.com');
INSERT INTO passengers VALUES ('P007', 'Arjun Patel', '1998-04-25', 'Ahmedabad', 9876543216, 'arjun@email.com');
INSERT INTO passengers VALUES ('P008', 'Neha Verma', '1993-06-18', 'Pune', 9876543217, 'neha@email.com');
INSERT INTO passengers VALUES ('P009', 'Sachin Joshi', '1980-02-29', 'Delhi', 9876543218, 'sachin@email.com');
INSERT INTO passengers VALUES ('P010', 'Deepika Rao', '1997-12-05', 'Mumbai', 9876543219, 'deepika@email.com');

INSERT INTO booking VALUES ('B001', 'FL001', '2025-07-28', 8500);
INSERT INTO booking VALUES ('B002', 'FL002', '2025-07-29', 7200);
INSERT INTO booking VALUES ('B003', 'FL003', '2025-07-29', 9800);
INSERT INTO booking VALUES ('B004', 'FL004', '2025-07-30', 6500);
INSERT INTO booking VALUES ('B005', 'FL005', '2025-07-30', 7800);
INSERT INTO booking VALUES ('B006', 'FL006', '2025-07-31', 9100);
INSERT INTO booking VALUES ('B007', 'FL007', '2025-07-31', 5900);
INSERT INTO booking VALUES ('B008', 'FL008', '2025-07-28', 12000);
INSERT INTO booking VALUES ('B009', 'FL009', '2025-07-29', 6800);
INSERT INTO booking VALUES ('B010', 'FL010', '2025-07-30', 7500);
INSERT INTO booking VALUES ('B011', 'FL007', '2025-08-02', 12000);
INSERT INTO booking VALUES ('B012', 'FL008', '2025-08-03', 6800);
INSERT INTO booking VALUES ('B013', 'FL009', '2025-08-03', 7500);

INSERT INTO booking_details VALUES ('B001', 'P001');
INSERT INTO booking_details VALUES ('B001', 'P002'); 
INSERT INTO booking_details VALUES ('B002', 'P003');
INSERT INTO booking_details VALUES ('B003', 'P004');
INSERT INTO booking_details VALUES ('B004', 'P005');
INSERT INTO booking_details VALUES ('B005', 'P006');
INSERT INTO booking_details VALUES ('B006', 'P007');
INSERT INTO booking_details VALUES ('B007', 'P008');
INSERT INTO booking_details VALUES ('B008', 'P009');
INSERT INTO booking_details VALUES ('B009', 'P010');
select Flight_source from Flight_details;

select f.Flight_source as Source, 
count(f.Flight_name) as NO_OF_FLIGHTS 
from Flight_details f 
where f.Flight_source like '%o%' or f.Flight_source like '%O%'
group by f.Flight_source
order by f.Flight_source desc;

select 
pass_name + ' hails from '+ Address  as WEEKEND_TRIPS
from
passengers p
inner join 
booking_details bd on p.pass_id = bd.Passid
inner join 
booking b on bd.Bookingid = b.booking_id
inner join
Flight_details fd on b.flightid= fd.Flight_id
where 
DATENAME(WEEKDAY,fd.Flight_date) IN  ('SATURDAY', 'SUNDAY')
order by pass_name desc

select 
Flight_name, 
DATENAME(MONTH, fd.Flight_date) AS Flight_Time, 
count(bd.Passid) as PASSENGER_COUNT
from
Flight_details fd
left join 
booking b on fd.Flight_id = b.flightid
left join
booking_details bd on b.booking_id=bd.Bookingid
where 
Flight_source != 'Mumbai'
group by 
    fd.Flight_id, 
    fd.Flight_name,
    fd.Flight_date
having count(bd.Passid)<2

create or alter procedure passengerDetails(@Addr varchar(20))
as
begin 
    PRINT 'The list of passengers names is:'
    select upper(p.pass_name) 
    from passengers p
    where lower(p.Address) = lower(@Addr)
    order by p.pass_name desc
end;
EXEC passengerDetails 'Mumbai';
GO
create or alter procedure bookingAmount(@Fid varchar(20),@final decimal output)
as
begin
     select @final= sum(Amt) from booking  where flightid = @Fid 
     SET @final = @final * 1.10;
end;
GO
DECLARE @totalAmount DECIMAL(10, 2); 
EXEC bookingAmount @Fid = 'FL001', @final = @totalAmount OUTPUT;
SELECT @totalAmount 

GO
create or alter procedure findbooking(@Bid varchar(20))
as
begin
    DECLARE @bExists BIT;
    SELECT @bExists = CASE WHEN EXISTS (SELECT 1 FROM booking WHERE booking_id = @Bid) THEN 1 ELSE 0 END;

    IF @bExists = 1
    BEGIN
        SELECT
            p.pass_name AS PassengerName,
            DATEDIFF(day, b.Booking_date, fd.Flight_date) AS TotalDays
        FROM
            booking_details bd
        INNER JOIN
            booking b ON bd.Bookingid = b.booking_id
        INNER JOIN
            passengers p ON bd.Passid = p.pass_id
        INNER JOIN
            Flight_details fd ON b.flightid = fd.Flight_id
        WHERE
            b.booking_id = @Bid
        ORDER BY
            p.pass_name DESC; 
    END
    ELSE
    BEGIN
        PRINT 'No booking found for the provided booking ID';
    END
END;

GO
findbooking 'B999';