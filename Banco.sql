CREATE DATABASE POOI_Lab;
GO

USE POOI_Lab;
GO

CREATE TABLE dbo.TB_Produto
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nome VARCHAR(100) NOT NULL,
    Preco DECIMAL(10,2) NOT NULL
);

CREATE TABLE dbo.Aluno
(
    AlunoId INT IDENTITY(1,1) PRIMARY KEY,
    Nome NVARCHAR(120) NOT NULL,
    Email NVARCHAR(120),
    DataNascimento DATE
);

CREATE TABLE dbo.Professor
(
    ProfessorId INT IDENTITY(1,1) PRIMARY KEY,
    Nome NVARCHAR(120) NOT NULL,
    Email NVARCHAR(120),
    Titulo NVARCHAR(100)
);

CREATE TABLE dbo.Disciplina
(
    DisciplinaId INT IDENTITY(1,1) PRIMARY KEY,
    Codigo VARCHAR(20),
    Nome NVARCHAR(120),
    CargaHoraria INT
);