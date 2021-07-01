USE Aula_Trigger;

INSERT INTO Estoque(Produto, Quantidade_no_Estoque)
VALUES	('PS5', 100);

CREATE TRIGGER att_Estoque
ON tlb_HistoricoVendas
FOR INSERT
AS
BEGIN
	DECLARE	@Quantidade INT
			,@Produto VARCHAR(200)

	SELECT @Quantidade = Quantidade_Vendida, @Produto = Prod_Vendido FROM inserted

	UPDATE Estoque
	SET	Quantidade_no_Estoque = Quantidade_no_Estoque - @Quantidade
	WHERE Produto = @Produto

END

INSERT INTO tlb_HistoricoVendas (Prod_Vendido, Quantidade_Vendida)
VALUES	('PS5', 30);