CREATE DATABASE Aula_Trigger;

USE Aula_Trigger;

CREATE TABLE Estoque
(
	idProduto INT PRIMARY KEY IDENTITY
	, Produto VARCHAR(200)
	, Quantidade_no_Estoque INT
);

CREATE TABLE tlb_HistoricoVendas
(
	idVenda INT PRIMARY KEY IDENTITY
	, Prod_Vendido VARCHAR (200)
	, Quantidade_Vendida INT
);