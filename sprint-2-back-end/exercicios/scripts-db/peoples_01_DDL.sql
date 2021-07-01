CREATE DATABASE Peoples;

USE Peoples;


CREATE TABLE Funcionarios
(
	IdFuncionario	INT PRIMARY KEY IDENTITY,
	Nome			VARCHAR(200),
	Sobrenome		VARCHAR(255)
);