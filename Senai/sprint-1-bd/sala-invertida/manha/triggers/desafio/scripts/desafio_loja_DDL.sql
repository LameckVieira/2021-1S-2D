USE Desafio;

CREATE TABLE Produtos
(
	IdProduto			INT PRIMARY KEY IDENTITY,
	Nome				VARCHAR(33),
	Preco				DECIMAL(10, 2)
);

CREATE TABLE Vendas
(
	IdVenda			INT PRIMARY KEY IDENTITY,
	DataVenda		DATETIME
);

CREATE TABLE ItensVendas
(
	IdProduto			INT FOREIGN KEY REFERENCES Produtos (IdProduto),
	IdVenda				INT FOREIGN KEY REFERENCES Vendas (IdVenda),
	Quantidade			INT,
	PrecoFinal			DECIMAL(10,2)
);

DROP TABLE Produtos;
DROP TABLE Vendas;
DROP TABLE ItensVendas;