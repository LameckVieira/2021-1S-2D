-- DDL

-- Cria o banco de dados nomeado Gufi_manha
CREATE DATABASE Gufi_manha;
GO

-- Define o banco de dados que será utilizado
USE Gufi_manha;
GO

-- Cria a tabela tiposUsuarios
CREATE TABLE tiposUsuarios
(
	idTipoUsuario			INT PRIMARY KEY IDENTITY
	,tituloTipoUsuario		VARCHAR(200) UNIQUE NOT NULL
);
GO

-- Cria a tabela usuarios
CREATE TABLE usuarios
(
	idUsuario			INT PRIMARY KEY IDENTITY
	,idTipoUsuario		INT FOREIGN KEY REFERENCES tiposUsuarios(idTipoUsuario)
	,nomeUsuario		VARCHAR(200) NOT NULL
	,email				VARCHAR(200) UNIQUE NOT NULL
	,senha				VARCHAR(200) NOT NULL
);
GO

-- Cria a tabela instituicoes
CREATE TABLE instituicoes
(
	idInstituicao		INT PRIMARY KEY IDENTITY
	,cnpj				CHAR(14) UNIQUE NOT NULL
	,nomeFantasia		VARCHAR(200) NOT NULL
	,endereco			VARCHAR(250) UNIQUE NOT NULL
);
GO

-- Cria a tabela tiposEventos
CREATE TABLE tiposEventos
(
	idTipoEvento		INT PRIMARY KEY IDENTITY
	,tituloTipoEvento	VARCHAR(200) UNIQUE NOT NULL
);
GO

-- Cria a tabela eventos
CREATE TABLE eventos
(
	idEvento		INT PRIMARY KEY IDENTITY
	,idTipoEvento	INT FOREIGN KEY REFERENCES tiposEventos(idTipoEvento)
	,idInstituicao	INT FOREIGN KEY REFERENCES instituicoes(idInstituicao)
	,nomeEvento		VARCHAR(250) NOT NULL
	,acessoLivre	BIT DEFAULT (1)
	,dataEvento		DATE NOT NULL
	,descricao		VARCHAR(255)
);
GO

-- Cria a tabela presencas
CREATE TABLE presencas
(
	idPresenca		INT PRIMARY KEY IDENTITY
	,idUsuario		INT FOREIGN KEY REFERENCES usuarios(idUsuario)
	,idEvento		INT FOREIGN KEY REFERENCES eventos(idEvento)
	,situacao		VARCHAR(250) NOT NULL
);
GO

-- Resuminho:
/*
	PRIMARY KEY = Chave Primária
	FOREIGN KEY = Chave Estrangeira
	IDENTITY	= Define que o campo será auto-incrementado e único
	NOT NULL	= Define que não pode ser nulo, ou seja, obrigatório
	UNIQUE		= Define que o valor do campo é único, ou seja, não se repete
	DEFAULT		= Define um valor padrão, caso nenhum seja informado
	GO			= Pausa a leitura e executa o bloco de código acima
*/