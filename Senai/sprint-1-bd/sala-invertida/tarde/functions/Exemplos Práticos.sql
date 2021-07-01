-- Função Escalar
CREATE FUNCTION SomarVidaMana(
	@IDPersonagem INT
)
RETURNS DECIMAL(7,2)
AS
	BEGIN
		DECLARE @SomaVidaMana AS DECIMAL(7,2)
		SET @SomaVidaMana = (SELECT CapMaxVida + CapMaxMana FROM dbo.Personagens
			WHERE idPersonagem = @IDPersonagem)
		RETURN @SomaVidaMana
	END
SELECT	FuncaoTeste = dbo.SomarVidaMana(2)

		
CREATE FUNCTION SomarDoisValores(
	@valor1 INT,
	@valor2 INT
)
RETURNS INT
AS 
	BEGIN
		DECLARE @soma AS INT
		SET @soma = @valor1 + @valor2
		RETURN @soma
	END

SELECT Soma = dbo.SomarDoisValores(3, 5)

-- Inline
CREATE FUNCTION VidaMaiorQue (
	@VidaPersonagem INT
)
RETURNS TABLE
AS
RETURN
(
	SELECT Classes.Classe, Personagens.Nome, Personagens.CapMaxVida
	FROM Classes
	INNER JOIN Personagens ON Personagens.CapMaxVida > @VidaPersonagem AND Personagens.idClasse = Classes.idClasse
);
SELECT * FROM dbo.VidaMaiorQue(80)

-- Multi-Statement
CREATE FUNCTION dbo.Forca
(
@VidaBase INT
) 
RETURNS @ResultTable TABLE
( 
CharacterName VARCHAR(50), Health DECIMAL(7,2), StatusVida VARCHAR(50)
) AS BEGIN
        INSERT INTO @ResultTable
            SELECT Nome, CapMaxVida,  NULL
                FROM dbo.Personagens
UPDATE @ResultTable
            SET StatusVida = 
            CASE WHEN Health < @VidaBase THEN 'Fraco'
            ELSE 'Normal'
            END
RETURN
END

SELECT * FROM dbo.Forca(80)