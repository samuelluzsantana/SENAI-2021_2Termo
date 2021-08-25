USE WishList
GO

INSERT INTO Usuarios(nomeUsuario,email,senha)
VALUES	('Felipe','felipe@email.com', '1234'),
		('Samuel','samuel@uol.com', '5678')
GO

INSERT INTO Desejos(idUsuario,descricao)
VALUES	(1, 'me tornar um desenvolvedor sênior'),
		(1, 'morar na praia'),
		(2, 'ficar milionário')