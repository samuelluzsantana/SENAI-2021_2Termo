--DDL

CREATE DATABASE Locadora;
GO

USE Locadora;
GO

CREATE TABLE empresa(
	idEmpresa		INT PRIMARY KEY IDENTITY,
	nomeEmpresa		VARCHAR(200) NOT NULL
);
GO

CREATE TABLE marcas(
	idMarca			INT PRIMARY KEY IDENTITY,
	nomeMarca		VARCHAR(200) NOT NULL,
);
GO

CREATE TABLE clientes(
	idCliente		INT PRIMARY KEY IDENTITY,
	nomeCliente		VARCHAR(200) NOT NULL,
	CPF				VARCHAR(11) NOT NULL
);
GO

CREATE TABLE modelos(
	idModelo		INT PRIMARY KEY	IDENTITY,
	idMarca			INT FOREIGN KEY REFERENCES marcas(idMarca),
	descricao		VARCHAR(200) NOT NULL
);
GO

CREATE TABLE veiculos(
	idVeiculo		INT PRIMARY KEY IDENTITY,
	idEmpresa		INT FOREIGN KEY REFERENCES empresa(idEmpresa),
	idModelo		INT FOREIGN KEY REFERENCES modelos(idModelo),
	placa			VARCHAR(20) NOT NULL
);
GO

CREATE TABLE alugueis(
	idAluguel		INT PRIMARY KEY IDENTITY,
	idVeiculo		INT FOREIGN KEY REFERENCES veiculos(idVeiculo),
	idCliete		INT FOREIGN KEY REFERENCES clientes(idCliente),
	dataInicio		DATE NOT NULL,
	dataFim			DATE NOT NULL,
);
GO

