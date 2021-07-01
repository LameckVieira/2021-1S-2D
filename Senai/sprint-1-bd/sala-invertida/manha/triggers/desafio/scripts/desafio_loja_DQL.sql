USE Aula_Trigger;

SELECT Nome AS Produto, FORMAT(Preco, 'c', 'pt-br') AS [Preço] FROM Produtos;
SELECT * FROM Vendas;
SELECT * FROM ItensVendas;

SELECT Produtos.Preco FROM IVenda
INNER JOIN Produtos
ON Produtos.IdProduto = IVenda.IdProduto