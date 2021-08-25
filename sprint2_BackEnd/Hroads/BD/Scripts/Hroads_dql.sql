USE SENAI_HROADS_TARDE;

--Lista a habilidade com o seu respectivo tipo de habilidade;
SELECT Habilidades.NomeHabilidade, TiposHabilidade.NomeTipo FROM Habilidades
INNER JOIN TiposHabilidade
ON Habilidades.IdTipo = TiposHabilidade.IdTipo

--Selecionar todos os personagens;
SELECT * FROM Personagens;

--Selecionar todas as Classes
SELECT * FROM Classes;

--Selecionar todas as habilidades;
SELECT * FROM Habilidades;

--Seleciona todos os tipos de habilidades
SELECT * FROM TiposHabilidade;