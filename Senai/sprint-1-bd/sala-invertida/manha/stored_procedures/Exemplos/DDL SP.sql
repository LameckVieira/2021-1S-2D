
CREATE DATABASE Clientes
USE Clientes

CREATE TABLE InformacoesClientes(
ClienteID			INT PRIMARY KEY IDENTITY
,NomeCliente		VARCHAR(200) NOT NULL
,NomeContato		VARCHAR(100) NOT NULL
,Endereco			VARCHAR(200) NOT NULL
,Cidade				VARCHAR(100) NOT NULL
,CodigoPostal		INT			 NOT NULL 
)


