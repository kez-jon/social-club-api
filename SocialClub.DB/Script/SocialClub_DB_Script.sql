IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND TABLE_NAME = 'Member') 
BEGIN
CREATE TABLE Member(
    MemberId Int Primary Key IDENTITY(100,1),
	FirstName Nvarchar(20) NOT NULL,
	LastName Nvarchar(20) NOT NULL,
	Gender Nvarchar(10) NOT NULL,
	DateOfBirth Date NOT NULL,
	[Address] Nvarchar(100) NOT NULL,
	Postcode Char(10) NOT NULL,
	Phone Nvarchar(15) NOT NULL UNIQUE,
	Email Nvarchar(50) NOT NULL UNIQUE,
);
END


IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND TABLE_NAME = 'Contact') 
BEGIN
CREATE TABLE Contact(
    ContactId Int Primary Key IDENTITY(100,1),
	[Address] Nvarchar(100) NOT NULL,
	Postcode Char(10) NOT NULL,
	Phone Nvarchar(15) NOT NULL UNIQUE,
	Email Nvarchar(50) NOT NULL UNIQUE,
);
END

IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND TABLE_NAME = 'ClubEvent') 
BEGIN
CREATE TABLE ClubEvent(
EventId Int Primary Key Identity(100,1),
EventName Nvarchar(20) NOT NULL,
StartDate Datetime NOT NULL,
EndDate Datetime NOT NULL,
Venue Nvarchar(50) NOT NULL,
HostName NVARCHAR(30) NOT NULL,
EventStatus Nvarchar(10) NOT NULL,
EventDescription Nvarchar(100) NOT NULL
);
End