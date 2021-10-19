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

exec spAddRecordInAddressBook 'Kalpesh','Chindarkar','Sewri','Mumbai','Maharashtra','kalpesh@gmail.com',400015,992003699

select * from AddressBook