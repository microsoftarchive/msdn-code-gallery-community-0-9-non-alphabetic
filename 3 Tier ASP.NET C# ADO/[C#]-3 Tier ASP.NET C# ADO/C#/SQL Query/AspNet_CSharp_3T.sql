create database AspNet_CSharp_3T;

use AspNet_CSharp_3T;

create table product(
	Id int identity(100, 1) primary key,
	Name varchar(100),
	Price decimal(10,2),
	Stock Int
);

CREATE PROCEDURE sp_Product_Insert(
@name varchar(100),
@price decimal(10,2),
@stock Int)
AS
BEGIN
	INSERT INTO product (Name, Price, Stock) VALUES (@name, @price, @stock)
END

exec sp_Product_Insert 'Tv', 599.5, 10;
exec sp_Product_Insert 'Radio', 200.5, 5;


CREATE PROCEDURE sp_Product_Modify(
@id int,
@name varchar(100),
@price decimal(10,2),
@stock Int)
AS
BEGIN
	UPDATE product 
	SET Name = @name, 
		Price = @price, 
		Stock = @stock
	WHERE Id = @id
END

exec sp_Product_Modify 100, 'Tv 24 pulgadas', 500.5, 4;

CREATE PROCEDURE sp_Product_Delete(@id int)
AS
BEGIN
	DELETE product
	WHERE Id = @id
END

exec sp_Product_Delete 100;

CREATE PROCEDURE sp_Product_GetAll
AS
BEGIN
	SELECT * FROM product
END

exec sp_Product_GetAll;

CREATE PROCEDURE sp_Product_Get(@id int)
AS
BEGIN
	SELECT * FROM product
	where Id = @id
END

exec sp_Product_Get 100;