USE Pessoas;
GO

INSERT INTO Pessoas (Nome)
VALUES				('Saulo')
				   ,('Caique');
GO

INSERT INTO Telefones (Descricao, IdPessoa)
VALUES				  ('99999999', 1)
					 ,('88888888', 1)
				     ,('77777777', 2);
GO

INSERT INTO Emails (Descricao, IdPessoa)
VALUES			   ('s.santos@email.com', 1)
				  ,('c.zaneti@email.com', 2);
GO

INSERT INTO CNHs (Descricao, IdPessoa)
VALUES			 ('1234', 1)
				,('4334', 2);
GO