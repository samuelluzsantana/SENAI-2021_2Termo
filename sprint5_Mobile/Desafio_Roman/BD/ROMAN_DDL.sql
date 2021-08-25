CREATE DATABASE ROMAN;
GO

USE ROMAN;
GO

CREATE TABLE TipoUsuario(
	idTipoUsuario int IDENTITY PRIMARY KEY,
	nomeTipoUsuario VARCHAR(200) NOT NULL 
)

GO

CREATE TABLE Usuario(
	idUsuario int IDENTITY PRIMARY KEY,
	idTipoUsuario int FOREIGN KEY REFERENCES TipoUsuario (idTipoUsuario),
	email VARCHAR(200) NOT NULL UNIQUE,
	senha VARCHAR(200) NOT NULL
)
GO

CREATE TABLE Equipe(
	idEquipe int IDENTITY PRIMARY KEY,
	nomeEquipe VARCHAR(200) NOT NULL
)
GO

CREATE TABLE Professor(
	idProfessor int IDENTITY PRIMARY KEY,
	idUsuario int FOREIGN KEY REFERENCES Usuario (idUsuario),
	idEquipe int FOREIGN KEY REFERENCES Equipe (idEquipe),
	nomeProfessor VARCHAR(200) NOT NULL
	
)
GO

CREATE TABLE Tema(
	idTema int IDENTITY PRIMARY KEY,
	nomeTema VARCHAR(200) NOT NULL
)
GO 

CREATE TABLE Projeto(
	idProjeto int IDENTITY PRIMARY KEY,
	nomeProjeto VARCHAR(200) NOT NULL,
	idTema int FOREIGN KEY REFERENCES Tema (idTema),
)
GO

