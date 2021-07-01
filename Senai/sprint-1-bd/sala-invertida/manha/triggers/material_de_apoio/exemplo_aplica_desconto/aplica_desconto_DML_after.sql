INSERT INTO Mercadorias (Nome, Preco)
VALUES ('Feijão', 7);

SELECT * FROM Mercadorias;

DELETE FROM Mercadorias;

DROP TRIGGER trg_AplicaDesconto;

CREATE TRIGGER trg_AplicaDesconto
ON Mercadorias
--AFTER 'INSERT' = DEPOIS DE 'INSERIR' ou DEPOIS QUE UM REGISTRO É FEITO
AFTER INSERT
AS
BEGIN
--  DECLARA     VARIÁVEL		DO TIPO
	DECLARE		@Nome			VARCHAR(100),
				@Preco			DECIMAL(10,2),
				@PrecoComDesc	DECIMAL(10,2)

--  COLETAMOS OS DADOS INSERIDOS PELO INSERT E ATRIBUI AS VARIÁVEIS
	SELECT @Nome = Nome, @Preco = Preco FROM INSERTED

	IF @Preco >= 15 AND @Preco < 30
		SELECT @PrecoComDesc = @Preco * 0.95
	ELSE IF @Preco >= 30
		SELECT @PrecoComDesc = @Preco * 0.90
	ELSE 
		SELECT @PrecoComDesc = @Preco

--	ATUALIZA OS VALORES NA TABELA MERCADORIAS
	UPDATE Mercadorias
	SET PrecoComDesc = @PrecoComDesc
	WHERE PrecoComDesc IS NULL;
END
