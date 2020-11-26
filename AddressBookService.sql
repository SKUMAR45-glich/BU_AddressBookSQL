
--Creation of DataBase

CREATE DATABASE AddressBookServiceDataBase
GO

USE AddressBookServiceDataBase 
GO


--Creating the table AddressBookService

create table AddressBookService
	(
	Id INT IDENTITY(1,1),
	FirstName varchar(20) not null,
	LastName varchar(20) not null,
	Address varchar(15) not null,
	City varchar(15) not null,
	State varchar(20) not null,
	Zipcode varchar(6) not null,
	PhoneNumber varchar(12) not null,
	Email varchar(30)
);



--Insertion of values

INSERT INTO AddressBookService(FirstName,LastName,Address,City,State,Zipcode,PhoneNumber,Email)
     VALUES
           ('Saurabh','Kumar','Airoli','Mumbai','Maharastra','400708','9038882016','saur@gmail.com'),
		   ('Piyush','Rawat','Airport','Mumbai','Maharastra','400709','8100080240','piy@gmail.com'),
		   ('Atul','Bharadwaj','Railway','Banglore','Karnataka','800214','9883302140','atul@gmail.com'),
		   ('Aditi','Gupta','near D block','Hyderabad','Telagana','800215','7418529634','adit@gmail.com'),
		   ('Saurabh','Kiran','Rodic','New Delhi','Dilli','100021','7418529630','sk@gmail.com');
GO



select * from AddressBookService;                                                                 --Display the values



--Update the City

update AddressBookService set City='Noida'
where LastName='Kiran';



--Delete from AddressBook

delete from AddressBookService
where City = 'Banglore';


--Select according to City

select * from AddressBookService
where City = 'Mumbai';


--Count the City and State by groupby 

select COUNT(City), City, State from AddressBookService
group by State, City;



--Sorting in Ascending order 

select * from AddressBookService
order by FirstName,LastName; 


--Addition a Relation

alter table AddressBookService
add Relation_Type varchar(15);

update AddressBookService set Relation_Type ='Friends' where FirstName='Saurabh';
update AddressBookService set Relation_Type ='Family' where FirstName='Piyush';
update AddressBookService set Relation_Type ='Family' where FirstName='Aditi';



--Grouping

select Count(FirstName) as No_of_Contacts,Relation_Type 
	from AddressBookService 
	group by Relation_Type;


--Multiple

Insert Into AddressBookService Values
	('Piyush','Rawat','Airport','Mumbai','Maharastra','400709','8100080240','piy@gmail.com','Friends');



alter table AddressBookService add
Deduction float,
taxable_pay real,
income_tax real,
net_pay float;

alter table AddressBookService add constraint df_address default 'India' for address

Insert Into AddressBookService (FirstName,LastName,City,State,Zipcode,PhoneNumber) Values
	('Rishabh','Gupta','Patna','Bihar','852741','9874561230');



--Create StoredProcedure for Updation

Create Procedure SpUpdateCityRelation
(
@Id int,
@FirstName varchar(40),
@LastName varchar(50),
@RelationType varchar(20),
@Address varchar(50),
@City varchar(25),
@State varchar(40),
@Zipcode varchar(7),
@PhoneNumber varchar(13),
@Email varchar(30)
)
As
Begin
Update AddressBookService Set City = @City,
					  State = @State,
					  Relation_Type = @RelationType
					  where Id = @Id ;

Select * from AddressBookService;

End

Alter Table  AddressBookService
add DOJ datetime;

update AddressBookService set DOJ ='2020-09-18' where City ='Mumbai';
update AddressBookService set DOJ ='2020-09-10' where City ='Noida';
update AddressBookService set DOJ ='2020-09-30' where Relation_Type = 'Family';




--Create StoredProcedure for Updation

Create Procedure SpAddofContact
(
@Id int,
@FirstName varchar(40),
@LastName varchar(50),
@RelationType varchar(20),
@Address varchar(50),
@City varchar(25),
@State varchar(40),
@Zipcode varchar(7),
@PhoneNumber varchar(13),
@Email varchar(30),
@DateofJoining Date
)
As
Begin
Insert into AddressBookService (FirstName,LastName,City,State,Address,PhoneNumber,Zipcode,Email,Relation_Type,DateofJoining) values (@FirstName,
							   @LastName,
							   @City,
							   @State,
							   @Address,
							   @PhoneNumber,
							   @Zipcode,
							   @Email,
							   @RelationType,
							   @DateofJoining)

End