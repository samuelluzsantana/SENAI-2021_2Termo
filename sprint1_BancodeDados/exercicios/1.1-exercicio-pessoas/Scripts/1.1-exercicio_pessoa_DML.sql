--DML

USE Pessoas;
GO

INSERT INTO Pessoas(nome)
VALUES	('John'),
		('Mary')
GO

INSERT INTO CNH(numeroCNH,idPessoa)
VALUES	('26085894300',1),
		('99304452090',2)
GO

INSERT INTO Telefone(numeroTelefone,idPessoa)
VALUES	('1196845526',1),
		('1234567890',2)
GO

INSERT INTO Email(email,idPessoa)
VALUES	('johnemail@exemplo.com',1),
		('Maryemails@exemplo.com',2)
GO




		
	






                   