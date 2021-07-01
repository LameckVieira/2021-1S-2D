--CRIANDO UM NOVO TRIGGER...
CREATE TRIGGER trg_AplicaDesconto
ON Mercadorias
--INSTEAD OF 'INSERT' = AO INVÉS DE 'INSERIR'
INSTEAD OF INSERT
AS
BEGIN -- Nesse caso, como utilizamos mais de um comando, é necessario coloca-los entre begin e end
--  DECLARA     VARIÁVEL		DO TIPO
	DECLARE		@Nome			VARCHAR(100),
				@Preco			DECIMAL(10,2),
				@PrecoComDesc	DECIMAL(10,2)

--  COLETAMOS OS DADOS INSERIDOS PELO INSERT E ATRIBUI AS VARIÁVEIS
	SELECT	@Nome = Nome, @Preco = Preco FROM INSERTED

	IF @Preco >= 15 AND @Preco < 30
		SELECT @PrecoComDesc = @Preco * 0.95
	ELSE IF @Preco >= 30
		SELECT @PrecoComDesc = @Preco * 0.90
	ELSE 
		SELECT @PrecoComDesc = @Preco

--	INSERE OS VALORES ATUALIZADOS
	INSERT INTO Mercadorias (Nome, Preco, PrecoComDesc)
	VALUES (@Nome, @Preco, @PrecoComDesc);
END



INSERT INTO Mercadorias (Nome, Preco)
VALUES ('Arroz', 10);

SELECT * FROM Mercadorias;








DELETE FROM Mercadorias;
DROP TRIGGER trg_AplicaDesconto;