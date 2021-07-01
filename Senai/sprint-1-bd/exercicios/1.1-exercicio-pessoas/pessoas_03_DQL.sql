USE Pessoas;
GO

SELECT * FROM Pessoas;
GO

SELECT * FROM Telefones;
GO

SELECT * FROM Emails;
GO

SELECT * FROM CNHs;
GO

-- listar as pessoas em ordem alfabética reversa mostrando seus telefones, seus e-mails e suas CNHs
SELECT Pessoas.Nome, Telefones.Descricao AS Telefone, Emails.Descricao AS Email,
CNHs.Descricao AS CNH FROM Pessoas 
INNER JOIN Telefones
ON Pessoas.IdPessoa = Telefones.IdPessoa
INNER JOIN Emails
ON Pessoas.IdPessoa = Emails.IdPessoa
INNER JOIN CNHs
ON Pessoas.IdPessoa = CNHs.IdPessoa
ORDER BY Pessoas.Nome DESC;
GO