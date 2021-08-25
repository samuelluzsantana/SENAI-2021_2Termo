-- DDL

CREATE DATABASE CZBooks;
GO

USE CZBooks;
GO


CREATE TABLE TipoUsuarios
(
	idTipoUsuario INT PRIMARY KEY IDENTITY,
	nomeTipo VARCHAR(200) NOT NULL
);
GO



CREATE TABLE Usuarios
(
	idUsuario INT PRIMARY KEY IDENTITY,
	idTipoUsuario INT FOREIGN KEY REFERENCES TipoUsuarios(idTipoUsuario),
	nomeUSuario VARCHAR(200) NOT NULL,
	email VARCHAR(200) UNIQUE NOT NULL,
	senha VARCHAR(200) NOT NULL
);
GO



CREATE TABLE Autores
(
	idAutor INT PRIMARY KEY IDENTITY,
	idTipoUsuario INT FOREIGN KEY REFERENCES TipoUsuarios(idTipoUsuario),
	nomeAutor VARCHAR(200) NOT NULL
);
GO



CREATE TABLE Generos
(
	idGenero INT PRIMARY KEY IDENTITY,
	nomeGenero VARCHAR(200) NOT NULL
);
GO



CREATE TABLE Intituicoes
(
	idIntituicao INT PRIMARY KEY IDENTITY,
	nomeFantasia VARCHAR(200) NOT NULL,
	cnpj CHAR(14) NOT NULL,
	endereco VARCHAR(200) NOT NULL
);
GO




CREATE TABLE Livros
(
	idLivro INT PRIMARY KEY IDENTITY,
	idAutor INT FOREIGN KEY REFERENCES Autores(idAutor),
	idGenero INT FOREIGN KEY REFERENCES Generos(idGenero),
	idIntituicao INT FOREIGN KEY REFERENCES Intituicoes(idIntituicao),
	titulo VARCHAR(200) NOT NULL,
	sinopse VARCHAR(480) NOT NULL,
	dataPublicacao DATE NOT NULL,
	preco CHAR(200) NOT NULL,
);
GO


