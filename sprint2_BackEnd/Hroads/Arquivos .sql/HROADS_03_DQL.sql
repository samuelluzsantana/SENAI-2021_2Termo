USE SENAI_HROADS_TARDE;

--Lista a habilidade com o seu respectivo tipo de habilidade;
SELECT Habilidades.NomeHabilidade, TiposHabilidade.NomeTipo FROM Habilidades
INNER JOIN TiposHabilidade
ON Habilidades.IdTipo = TiposHabilidade.IdTipo

--Seleciona todos os usuarios e quais suas permissões
SELECT Usuarios.Nome, Usuarios.Email, Usuarios.Senha, TiposUsuario.Tipo FROM Usuarios
INNER JOIN TiposUsuario
ON Usuarios.IdTipoUsuario = TiposUsuario.IdTipoUsuario

--Selecionar todos os personagens e suas classes;
SELECT Personagens.IdPersonagem, Classes.NomeClasse AS Classe, Personagens.NomePersonagem, Personagens.CapacidadeMAXVida, Personagens.CapacidadeMAXMana, Personagens.DataAtualizacao, Personagens.DataCriacao FROM Personagens
INNER JOIN Classes
ON Personagens.IdClasse = Classes.IdClasse


--Selecionar todas as Classes
SELECT * FROM Classes;

--Selecionar todas as habilidades;
SELECT * FROM Habilidades;

--Seleciona todos os tipos de habilidades
SELECT * FROM TiposHabilidade;

--Seleciona todos os tipos de usuario
SELECT * FROM TiposUsuario

--Seleciona todos os usuarios
SELECT * FROM Usuarios

