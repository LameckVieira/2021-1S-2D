create database biblioteca;

use biblioteca;

create table livros (
	idlivro int primary key identity,
	titulo varchar(50),
	autor varchar(50),
	datadeentrada date,
	datadesaida date,
	editora varchar(30),
	qtdpaginas int,
	);