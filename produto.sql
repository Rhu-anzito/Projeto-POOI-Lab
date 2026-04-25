USE POOI_Lab;
GO

IF OBJECT_ID('dbo.TB_Produto', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.TB_Produto (
        id INT IDENTITY(1,1) PRIMARY KEY,
        nome VARCHAR(100) NOT NULL,
        preco DECIMAL(10,2) NOT NULL
    );
END