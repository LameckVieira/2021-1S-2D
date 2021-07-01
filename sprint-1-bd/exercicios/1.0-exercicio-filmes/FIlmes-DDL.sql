--Cria um banco de dados chamado Filmes 
CREATE DATABASE Filmes;

--Definir o BD Filmes como o que será usado
USE Filmes;

CREATE TABLE Generos
(
	idGenero	INT PRIMARY KEY IDENTITY
	,Nome		VARCHAR(200) NOT NULL	
);
CREATE TABLE Filmes
(
	idFIlmes	INT PRIMARY KEY IDENTITY
	,idGenero	INT FOREIGN KEY REFERENCES Generos (idGenero)
	,Titulo		VARCHAR(150) NOT NULL
);