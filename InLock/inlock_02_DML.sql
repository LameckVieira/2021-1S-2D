USE InLock_Games_Manha;
GO

INSERT INTO Estudios(nomeEstudio)
VALUES  ('Blizzard'),
		('Rockstar Studios'),
		('Square Enix');
GO

INSERT INTO Jogos(idEstudio, nomeJogo, descricao, dataLancamento, valor)
VALUES  (1, 'Diablo 3', 'é um jogo que contém bastante ação e é viciante, seja você um novato ou um fã.', '15/05/2012', 99.00 ),
		(2, 'Red Dead Redemption II', 'jogo eletrônico de ação-aventura western.', '26/08/2018', 120.00);
GO

INSERT INTO TipoUsuario(titulo)
VALUES  ('Administrador'),
		('Cliente');
GO
INSERT INTO Usuario(idTipoUsuario, email, senha)
VALUES  (1, 'admin@admin.com', 'admin'),
		(2, 'cliente@cliente.com', 'cliente');
GO

--DROP DATABASE InLock_Games_Manha;