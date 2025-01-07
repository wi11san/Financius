CREATE DATABASE FinanciusDB;

USE FinanciusDB;

-- Tabela de Usuários
CREATE TABLE dbo.Usuarios (
     IdUsuario INT PRIMARY KEY IDENTITY (1,1),
     Nome NVARCHAR(100) NOT NULL,
     Email NVARCHAR(100) NOT NULL UNIQUE,
     SenhaHash NVARCHAR(200) NOT NULL
);

-- Tabela de Categorias
CREATE TABLE dbo.Categorias (
     IdCategoria INT PRIMARY KEY IDENTITY (1,1),
     Nome NVARCHAR(100) NOT NULL
);

-- Tabela de Receitas
CREATE TABLE dbo.Receitas (
     IdReceita INT PRIMARY KEY IDENTITY (1,1),
     Descricao NVARCHAR(200),
     Valor DECIMAL(18,2) NOT NULL,
     DataReceita DATETIME NOT NULL,
     IdUsuario INT FOREIGN KEY REFERENCES dbo.Usuarios (IdUsuario),
     IdCategoria INT FOREIGN KEY REFERENCES dbo.Categorias (IdCategoria)
);

-- Tabela de Despesas
CREATE TABLE dbo.Despesas (
     IdDespesa INT PRIMARY KEY IDENTITY (1,1),
     Descricao NVARCHAR(200),
     Valor DECIMAL(18,2) NOT NULL,
     DataDespesa DATETIME NOT NULL,
     IdUsuario INT FOREIGN KEY REFERENCES dbo.Usuarios (IdUsuario),
     IdCategoria INT FOREIGN KEY REFERENCES dbo.Categorias (IdCategoria)
);

