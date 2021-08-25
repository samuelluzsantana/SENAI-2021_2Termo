--DML

USE SENAI_HROADS_TARDE;

INSERT INTO TiposHabilidade(NomeTipo)
values               ('Ataque')
					,('Defesa')
					,('Cura')
					,('Magia');
GO

INSERT INTO Habilidades(IdTipo,NomeHabilidade)
values				(1,'Lança Mortal'),
					(2,'Escudo Supremo'),
					(3,'Recuperar Vida');
					
GO


INSERT INTO Classes	(NomeClasse)
values              ('Barbaro'),
					('Cruzado'),
					('Caçadora de Demonios'),
					('Monge'),
					('Necromante'),
					('Feiticeiro'),
					('Arcanista');
GO

INSERT INTO ClassesHabilidade(IdClasse,IdHabilidade )
values              (1,1),
					(1,3),
					(2,3),
					(3,1),
					(4,2),
					(4,3),
					(6,2);
GO

INSERT INTO ClassesHabilidade(IdClasse )
values   
						(5),
						(7);
GO


INSERT INTO Personagens   (NomePersonagem, IdClasse, CapacidadeMAXVida, CapacidadeMAXMana, DataAtualizacao, DataCriacao)
VALUES					  ('Strillex', 5, 70, 100, '02/03/2021','27/04/2021')
						,('Aphelios', 1, 100, 80, '02/03/2021', '27/04/2021')
						 ,('Fer8', 7, 75, 60, '02/03/2021', '18/03/2018')
GO

INSERT INTO TiposUsuario (Tipo)
VALUES			('Administrador'),
				('Jogador')
GO

INSERT INTO Usuarios(IdTipoUsuario,Nome,Email,Senha)
VALUES			(1,'Ademiro','adm@adm.com','adm123'),
				(2,'Strili','strili@gmail.com','strilli09'),
				(2,'samuca','samuce@gmail.com','cachorrospeludos87');
GO
