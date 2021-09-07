USE StoreManagement

--create table for stores
--use foreign key to reference to the users table
CREATE TABLE Stores
(
	Id INT PRIMARY KEY IDENTITY(1,1),
	StoreName VARCHAR(120) NOT NULL,
	StoreNumber VARCHAR(120) NOT NULL,
	StoreType VARCHAR(120) NOT NULL,
	StoreProducts INT NOT NULL,
	UserId VARCHAR(450) FOREIGN KEY
);