CREATE TABLE Mercadorias
(
	IdMercadoria	INT PRIMARY KEY IDENTITY,
	Nome			VARCHAR(100),
	Preco			DECIMAL(10, 2),
	PrecoComDesc	DECIMAL(10, 2)
);

DROP TABLE Mercadorias;
DROP TRIGGER trg_AplicaDesconto