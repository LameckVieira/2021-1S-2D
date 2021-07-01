-- TRIGGER AFTER
CREATE TRIGGER trg_mensagem_after -- Nome do trigger
ON Produtos -- Atribuição à tabela produtos
AFTER INSERT -- Após a inserção de um novo registro
AS
PRINT 'Produto inserido com sucesso!'; -- Código do trigger



DELETE FROM Produtos;




-- INSERIR DADOS NA TABELA PRODUTOS
INSERT INTO Produtos (Nome, Preco)
VALUES ('Refrigerante', 7.50);

-- EXIBIR DADOS DA TABELA PRODUTOS
SELECT Nome AS Produto, FORMAT(Preco, 'c', 'pt-br') AS [Preço] FROM Produtos;