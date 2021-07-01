USE Clientes

--CRIAR PROCEDIMENTO SEM PARÂMETROS
CREATE PROCEDURE SelecionarClientes
AS
SELECT * FROM InformacoesClientes
GO;
--EXECUTAR PROCEDIMENTO
EXEC SelecionarClientes

--CRIAR PROCEDIMENTO COM 1 PARÂMETRO
CREATE PROCEDURE SelecionarPais (@Pais varchar(30))
AS
SELECT * FROM InformacoesClientes WHERE Pais = @Pais
GO
--EXECUTAR PROCEDIMENTO
EXEC SelecionarPais @Pais = 'Brasil';

--CRIAR PROCEDIMENTO COM 2 PARÂMETROS
CREATE PROCEDURE SelecionarPaisCodigo @Pais varchar(30), @CodigoPostal INT
AS
SELECT * FROM InformacoesClientes WHERE Pais = @Pais AND CodigoPostal = @CodigoPostal
GO

--EXECUTAR PROCEDIMENTO

EXEC SelecionarPaisCodigo @Pais = 'Brasil', @CodigoPostal = 2564;











