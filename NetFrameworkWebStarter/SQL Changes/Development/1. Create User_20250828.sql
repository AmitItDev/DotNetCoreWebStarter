Create table Users 
(
	UserId int primary key identity(1,1), 
	FullName varchar(100),
	Username varchar(100),
	Password varchar(100),
	IsActive bit, 
	UserTypeId int null
)
--INSERT INTO Users (FullName,Username,Password,IsActive,UserTypeId) VALUES ('Bizsoft Dev','admin','XUZL9YZ0bbk=',1,1)