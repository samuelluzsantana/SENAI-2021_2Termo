-- DML

USE CZBooks;
GO


INSERT INTO TipoUsuarios(nomeTipo)
VALUES	('administrador'),
		('autor'),
		('usuario')
GO



INSERT INTO Usuarios(idTipoUsuario,nomeUSuario, email, senha)
VALUES	(1, 'Adm','adm@email.com', 'ricardo123'),
		(2, 'George Orwell', 'george@email.com', 'senha123'),
		(2, 'Machado de Asis', 'Machado@email.com', 'machadinho'),
		(3, 'Usuario', 'usuario@email.com', 'usuario123')
GO



INSERT INTO Autores(idTipoUsuario, nomeAutor)
VALUES	(2, 'George Orwell'),
		(2, 'Machado de Asis')
GO



INSERT INTO Generos(nomeGenero)
VALUES	('Romance'),
		('ficção Politica')
GO



INSERT INTO Intituicoes(nomeFantasia,cnpj,endereco)
VALUES	('CZBooks', '74948512000110','Rua Maça com pera 124')
GO


INSERT INTO Livros (idAutor, titulo,idGenero,idIntituicao, sinopse, dataPublicacao,preco)
VALUES	(1,'1984',2,1,'O livro narra a história de Winston Smith, homem de meia idade e membro do Partido Externo. Trabalhava como funcionário do Ministério da Verdade, 
						  onde reescrevia e alterava dados de acordo com os interesses do Partido.','1949','15,00'),

		(2,'Don Casmurgo',1,1,'O livro conta a história de Bento Santiago (Bentinho), apelidado de Dom Casmurro por ser calado e introvertido. Na adolescência,
		apaixona-se por Capítu, abandonando o seminário e, com ele, os desígnios traçados por sua mãe, Dona Glória, para que se tornasse padre.','1899','19,99')
GO
