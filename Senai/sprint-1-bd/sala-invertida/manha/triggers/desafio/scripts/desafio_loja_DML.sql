--INSERINDO VALORES NAS TABELAS
INSERT INTO Produtos (Nome, Preco)
VALUES ('Refrigerante', 7.50),
	   ('Bolacha', 3.50),
	   ('Arroz', 35),
	   ('Lasanha', 14.25),
	   ('Feijão', 7);

INSERT INTO ItensVendas (IdProduto, Quantidade)
VALUES (1, 30);

CREATE TRIGGER trg_PrecoFinal
ON ItensVendas
AFTER INSERT
AS
BEGIN
	DECLARE @Preco			DECIMAL(10, 2),
			@Quantidade		INT

	SELECT @Preco = Preco, 
		   @Quantidade = Quantidade
	FROM INSERTED
	INNER JOIN Produtos
	ON Produtos.IdProduto = INSERTED.IdProduto
	
	UPDATE ItensVendas
	SET PrecoFinal = @Preco * @Quantidade
	WHERE PrecoFinal IS NULL

	INSERT INTO Vendas (DataVenda) VALUES (GETDATE());
END

CREATE TRIGGER trg_AtualizaIdVenda
ON Vendas
AFTER INSERT
AS
BEGIN
	DECLARE @IdVenda		INT,
			@DATA			DATETIME

	SELECT @IdVenda = MAX(IdVenda) FROM Vendas

	UPDATE ItensVendas
	SET IdVenda = @IdVenda
	WHERE IdVenda IS NULL;
END

DROP TRIGGER trg_PrecoFinal;
DROP TRIGGER trg_AtualizaIdVenda;