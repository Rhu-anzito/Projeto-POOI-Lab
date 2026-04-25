IF NOT EXISTS (
    SELECT name 
    FROM sys.databases 
    WHERE name = 'POOI_Lab'
)
BEGIN
    CREATE DATABASE POOI_Lab;
END
GO