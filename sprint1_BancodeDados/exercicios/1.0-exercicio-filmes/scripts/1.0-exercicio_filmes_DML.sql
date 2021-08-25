
USE Filmes;
GO

INSERT INTO generos(nomegenero)
VALUES		('acão'),
			('aventura'),
			('comedia')
			
GO

INSERT INTO filmes(nomeFilme,idGenero)
VALUES		('Rambo',1),
			('John wick',1),
			('Como gente grande',3),
			('Viagem ao centro da terra',2)
GO

			

	