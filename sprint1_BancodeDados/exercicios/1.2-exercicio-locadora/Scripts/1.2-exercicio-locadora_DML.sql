--DML

USE Locadora;
GO

INSERT INTO empresa(nomeEmpresa)
VALUES		('Unidas'),
			('Localiza');
GO

INSERT INTO marcas(nomeMarca)
VALUES		('Ford'),
			('GM'),
			('Fiat')
GO

INSERT INTO clientes(nomeCliente,CPF)
VALUES		('Saulo','50382757025'),
			('Caique','52018663011')
GO

INSERT INTO modelos(idMarca,descricao)
VALUES			   (1,'Fiesta'),
				   (1,'Onix'),
				   (2,'Argo');
GO

INSERT INTO veiculos(idEmpresa,idModelo,placa)
VALUES				(1,1,'HEL1805'),
					(1,2,'FER1010'),
					(2,3,'POR1978'),
					(2,1,'LEM9876')
GO

INSERT INTO alugueis(idCliete,idVeiculo,dataInicio,dataFim)
VALUES				(1,1,'19/01/2019','20/01/2019'),
					(1,2,'20/01/2019','21/01/2019'),
					(2,3,'21/01/2019','21/01/2019'),
					(2,2,'22/01/2019','22/01/2019')
GO
























