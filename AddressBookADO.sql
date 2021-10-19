USE AddressBookDB

create table AddressBook(
ABID int identity(100,1) PRIMARY KEY,
firstname varchar(50), lastname varchar(50), address varchar(50), city varchar(50), state varchar(50), email varchar(50),
zipNo int, PhoneNumber float
);

CREATE PROC spAddRecordInAddressBook
@firstname varchar(50),@lastname varchar(50),@address varchar(50),@city varchar(50),@state varchar(50),@email varchar(50),
@zipNo int,@PhoneNumber float
AS
BEGIN
	INSERT INTO AddressBook VALUES (@firstname ,@lastname ,@address ,@city ,@state ,@email ,@zipNo ,@PhoneNumber);
END

exec spAddRecordInAddressBook 'Kalpesh','Chindarkar','Sewri','Mumbai','Maharashtra','kalpesh@gmail.com',400015,9920036999
spAddRecordInAddressBook 'Ketan','Chindarkar','24th street','Banglore','Karnataka','ketan@gmail.com',710015,9999914752

CREATE PROC spEditPersonPhoneNumber(
@firstname varchar(50),
@PhoneNumber float
)
AS
BEGIN
	UPDATE AddressBook SET PhoneNumber=@PhoneNumber where firstname=@firstname;
END

spEditPersonPhoneNumber 'Kalpesh' 9920036999

CREATE PROC spDeleteRowUsingFirstname
@fname varchar(50)
AS
BEGIN
	Delete from AddressBook where firstname=@fname;
END

spDeleteRowUsingFirstname 'Kalpesh'

select * from AddressBook