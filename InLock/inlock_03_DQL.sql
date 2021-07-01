USE InLock_Games_Manha
GO

SELECT * FROM Usuario;

SELECT * FROM Estudios;

SELECT * FROM Jogos;

SELECT * FROM Jogos
INNER JOIN Estudios
ON Jogos.idEstudio = Estudios.idEstudio;

SELECT * FROM Jogos
FULL OUTER JOIN Estudios
ON Jogos.idEstudio = Estudios.idEstudio;

SELECT * FROM Usuario
WHERE email = 'admin@admin.com' AND senha = 'admin';

SELECT * FROM Jogos
WHERE idJogo = 1;

SELECT * FROM Estudios
WHERE idEstudio = 1;
