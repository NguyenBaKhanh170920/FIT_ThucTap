Create database EFCore_Exam1
use EFCore_Exam1
CREATE TABLE Product (
  Id int PRIMARY KEY IDENTITY,
  Name nvarchar(200),
  Price int,
  Status int,
  CategoryId int,
  CreateDate date
)
CREATE TABLE Category (
  Id int PRIMARY KEY IDENTITY,
  Name nvarchar(200),
  Status int
)
--select *from Product where CategoryId=2
--create proc SP_Get_All_User
--as
--Select Id,Name,Email,Password,Temppass from tb_user
--go
GO
CREATE PROC Sp_getallproduct @CategoryId int
AS
BEGIN
  IF (@CategoryId IS NULL)
  BEGIN
    SELECT
      Id,
      Name,
      Price,
      Status,
      CategoryId,
      CreateDate
    FROM Product
  END
  ELSE
  BEGIN
    SELECT
      Id,
      Name,
      Price,
      Status,
      CategoryId,
      CreateDate
    FROM Product
    WHERE CategoryId = @CategoryId
  END
END
GO
--exec Sp_getallproduct @CategoryId=null
--drop PROCEDURE  Sp_getallproduct
GO
CREATE PROC Sp_deleteProduct @Id int
AS
BEGIN
  IF (@Id IS NULL)
  BEGIN
    DELETE FROM Product
  END
  ELSE
  BEGIN
    DELETE Product
    WHERE Id = @Id
  END
END
--select*from Product
--Select * from category
--exec Sp_deleteProduct @Id=null
GO
CREATE PROC Sp_insertProduct 
@Name nvarchar(200),
@Price int,
@Status int,
@CategoryId int,
@CreateDate date
AS
  INSERT INTO Product (Name, Price, Status, CategoryId, CreateDate)
    VALUES (@Name, @Price, @Status, @CategoryId, @CreateDate)
--exec Sp_insertProduct @Name='San pham 5',@Price=200,@Status=2,@CategoryId=3,@CreateDate='2005-5-5'
