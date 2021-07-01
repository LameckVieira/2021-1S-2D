USE Locadora;

INSERT INTO Empresas (Nome)
VALUES ('Decolar')
	   ,('Movida');

INSERT INTO Marcas (Nome)
VALUES ('NISSAN')
	  ,('HONDA');

INSERT INTO Modelos (Nome, IdMarca)
VALUES ('400', 1),
	   ('Up', 2);

INSERT INTO Veiculos (Placa, IdModelo, IdEmpresa)
VALUES ('LMK5555', 1, 1)
	   ,('MLK1236', 2, 2);

INSERT INTO Clientes (Nome, CPF)
VALUES ('CAIQUE', '12345678952')
	   ,('MACHINE', '25525263698');

INSERT INTO Alugueis (IdCliente, IdVeiculo, Valor, DataDeRetirada, DataDeEntrega)
VALUES (1, 3, 100, '28/02/2021', '28/02/2021')
	   ,(2, 2, 150, '28/02/2021', '28/02/2021');