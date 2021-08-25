--Criando banco de dados
CREATE DATABASE Filmes;
GO

USE Filmes;
GO

CREATE TABLE generos(
	idGenero INT PRIMARY KEY IDENTITY,
	nomegenero VARCHAR(200) NOT NULL
);
GO

CREATE TABLE filmes(
	idFilme INT PRIMARY KEY IDENTITY,
	nomeFilme VARCHAR(200) NOT NULL,
	idGenero INT FOREIGN KEY REFERENCES generos(idGenero)
);
GO