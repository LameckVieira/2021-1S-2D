-- DQL

-- Define o banco de dados que será utilizado
USE Gufi_manha;
GO

-- Lista todos os tipos de usuários
SELECT * FROM tiposUsuarios;

-- Lista todos os usuários
SELECT * FROM usuarios;

-- Lista todas as instituições
SELECT * FROM instituicoes;

-- Lista todos os tipos de eventos
SELECT * FROM tiposEventos;

-- Lista todos os eventos
SELECT * FROM Eventos;

-- Lista todas as presenças
SELECT * FROM Presencas;

-- Seleciona os dados dos usuários mostrando o tipo de usuário
SELECT idUsuario, tituloTipoUsuario, nomeUsuario, email FROM usuarios
INNER JOIN tiposUsuarios
ON usuarios.idTipoUsuario = tiposUsuarios.idTipoUsuario;

-- Seleciona os dados dos eventos, da instituição e dos tipos de eventos
SELECT nomeFantasia [Local], idEvento, tituloTipoEvento, nomeEvento, acessoLivre, 
dataEvento, descricao
FROM Eventos E
INNER JOIN tiposEventos TE
ON E.idTipoEvento = TE.idTipoEvento
INNER JOIN instituicoes I
ON E.idInstituicao = I.idInstituicao;

-- Seleciona os dados dos eventos, da instituição, dos tipos de eventos e dos usuários
SELECT nomeUsuario Usuario, email, nomeEvento Evento, tituloTipoEvento Tema, dataEvento [Data]
FROM usuarios U
INNER JOIN Presencas P
ON P.idUsuario = U.idUsuario
INNER JOIN Eventos E
ON P.idEvento = E.idEvento
INNER JOIN tiposEventos TE
ON E.idTipoEvento = TE.idTipoEvento;

-- Busca um usuário através do seu e-mail e senha
SELECT tituloTipoUsuario [Permissão], nomeUsuario, email 
FROM usuarios U 
INNER JOIN tiposUsuarios TU 
ON U.idTipoUsuario = TU.idTipoUsuario 
WHERE email = 'saulo@email.com' AND senha = 'saulo123';