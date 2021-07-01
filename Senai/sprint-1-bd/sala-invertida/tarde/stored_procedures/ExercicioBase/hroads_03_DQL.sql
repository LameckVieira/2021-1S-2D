USE SENAI_HROADS_TARDE;

-- exercicio 6
SELECT * FROM Personagens;

-- exercicio 7
SELECT * FROM Classes;

-- exercicio 8
SELECT Classes.Nome FROM Classes;

-- exercicio 9
SELECT * FROM Habilidades;

-- exercicio 10
SELECT COUNT(idHabilidade) AS Habilidades_Cadastradas FROM Habilidades

-- exercicio 11
SELECT idHabilidade FROM Habilidades
ORDER BY idHabilidade ASC

-- exercicio 12
SELECT * FROM TipoHabilidade

-- exercicio 13
SELECT Habilidades.Habilidade, TipoHabilidade.Tipo FROM Habilidades
LEFT JOIN TipoHabilidade
ON Habilidades.idTipo = TipoHabilidade.idTipo

-- exercicio 14
SELECT Personagens.Nome, Classes.Nome FROM Personagens
INNER JOIN Classes
ON Personagens.idClasse = Classes.idClasse

-- exercicio 15
SELECT Personagens.Nome, Classes.Nome FROM Personagens
RIGHT JOIN Classes
ON Personagens.idClasse = Classes.idClasse

-- exercicio 16
SELECT Classes.Nome AS Classe, Habilidades.Habilidade FROM ClassHab
RIGHT JOIN Classes
ON ClassHab.idClasse = Classes.idClasse
LEFT JOIN Habilidades
ON ClassHab.idHabilidade = Habilidades.idHabilidade

-- exercicio 17
SELECT Habilidades.Habilidade,  Classes.Nome AS Classe FROM ClassHab
INNER JOIN Habilidades
ON ClassHab.idHabilidade = Habilidades.idHabilidade
INNER JOIN Classes
ON ClassHab.idClasse = Classes.idClasse

-- exercicio 18
SELECT Habilidades.Habilidade,  Classes.Nome AS Classe FROM ClassHab
LEFT JOIN Habilidades
ON ClassHab.idHabilidade = Habilidades.idHabilidade
RIGHT JOIN Classes
ON ClassHab.idClasse = Classes.idClasse





-- PROCEDURE
USE SENAI_HROADS_TARDE;

CREATE PROCEDURE Exemplo_1
AS
SELECT * FROM Habilidades;


EXECUTE Exemplo_1

CREATE PROCEDURE Exemplo_2
@idHabilidade INT
AS
SELECT * FROM Habilidades
WHERE idHabilidade = @idHabilidade;

EXECUTE Exemplo_2 2

ALTER PROCEDURE Exemplo_2
AS
SELECT Habilidades.Habilidade, TipoHabilidade.Tipo FROM Habilidades
LEFT JOIN TipoHabilidade
ON Habilidades.idTipo = TipoHabilidade.idTipo;

EXECUTE Exemplo_2