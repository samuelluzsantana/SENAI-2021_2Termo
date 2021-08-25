USE SENAI_HROADS_TARDE;

--Inserir os registros conforme descrição no próprio texto
INSERT INTO Classes (NomeClasse)
VALUES			   ('Barbaro')
				  ,('Cruzado')
				  ,('Caçadora de Demonios')
				  ,('Monge')
				  ,('Necromante')
				  ,('Feiticeiro')
				  ,('Arcanista')

INSERT INTO TiposHabilidade (NomeTipo)
VALUES					   ('Ataque')
						  ,('Defesa')
						  ,('Cura')
						  ,('Magia')

INSERT INTO Habilidades	(NomeHabilidade, IdTipo)
VALUES					('Lança Mortal', 1)
					   ,('Escudo Supremo', 2)
					   ,('Recuperar Vida', 3)

INSERT INTO Personagens	(NomePersonagem, IdClasse, CapacidadeMAXVida, CapacidadeMAXMana, DataAtualizacao, DataCriacao)
VALUES					('Strillex', 5, 70, 100, '02/03/2021','27/04/2021')
					   ,('Aphelios', 1, 100, 80, '02/03/2021', '27/04/2021')
					   ,('Fer8', 7, 75, 60, '02/03/2021', '18/03/2018')

INSERT INTO ClassesHabilidade (IdClasse, IdHabilidade)
VALUES					(1, 1)
					   ,(1, 2)
					   ,(2, 2)
					   ,(3, 1)
					   ,(4, 3)
					   ,(4, 2)
					   ,(5, NULL)
					   ,(6, 3)
					   ,(7, NULL)

INSERT INTO TiposUsuario (Tipo)
VALUES					('Administrador')
						,('Jogador')

INSERT INTO Usuarios(IdTipoUsuario,Nome,Email,Senha)
VALUES            (1,'Ademiro','adm@adm.com','adm123'),
                (2,'Strili','strili@gmail.com','strilli09'),
                (2,'samuca','samuce@gmail.com','cachorrospeludos87');
GO