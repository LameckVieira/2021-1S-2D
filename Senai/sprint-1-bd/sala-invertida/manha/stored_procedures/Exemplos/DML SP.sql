
USE Clientes


INSERT INTO InformacoesClientes  (NomeCliente, NomeContato, Endereco, Cidade, CodigoPostal, Pais)
								 ('Alfreds Futterkiste', 'Maria Anders', 'Obere Str. 57', 'Berlin', 12209, 'Alemanha' )
								,('Ana Trujillo Emparedados y helados','Ana Trujillo','Avda. de la Constitución 2222','México D.F.',05021,'México')
								,('Antonio Moreno','Antonio Moreno', 'Mataderos 2312', 'México D.F', 05023, 'México')
								,('Tomás Santos Silva', 'Tomás Silva', 'Morumbi 253', 'São Paulo', 02564, 'Brasil')
								,('Cristina Silveira Santos','Cristina Silveira','','Rio de Janeiro', 05684,'Brasil')


UPDATE InformacoesClientes
SET CodigoPostal = 02564
WHERE ClienteID  = 5
SELECT * FROM InformacoesClientes