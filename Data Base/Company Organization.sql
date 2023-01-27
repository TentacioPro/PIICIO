create database Organization
use Organization
create table TeamLeaderDetails(ID int identity(1,1),EmployeeID varchar(max),Password varchar(max),Name varchar(max),MobileNumber varchar(max),MailID varchar(max),Status varchar(max),RegisterDate varchar(max))
create table EmployeeDetails(ID int identity(1,1),EmployeeID varchar(max),Password varchar(max),Name varchar(max),MobileNumber varchar(max),MailID varchar(max),TeamLeaderID varchar(max),Status varchar(max),RegisterDate varchar(max))
create table EAttendanceDetails(ID int identity(1,1),EmployeeID varchar(max),Name varchar(max),TeamLeaderID varchar(max),Date varchar(max))
create table TLAttendanceDetails(ID int identity(1,1),TeamLeaderID varchar(max),Name varchar(max),Date varchar(max))
create table EDailyUpdates(ID int identity(1,1),EmployeeID varchar(max),Name varchar(max),Details varchar(max),TeamLeaderID varchar(max),Date varchar(max))
create table TLDailyUpdates(ID int identity(1,1),TeamLeaderID varchar(max),Name varchar(max),Details varchar(max),Date varchar(max))
create table QRCode(ID int Identity(1,1),Name varchar(max),ContentType nvarchar(max),Data varbinary(max),FileKey varchar(max))
create table Files(ID int Identity(1,1),FileName varchar(max),FileKey varchar(max),TeamLeaderID varchar(max),Date varchar(max))
create table SendInformation(ID int Identity(1,1),EmployeeID varchar(max),Name varchar(max),Details varchar(max),FileName varchar(max),Who varchar(max),Date varchar(max))


drop table SendInformation