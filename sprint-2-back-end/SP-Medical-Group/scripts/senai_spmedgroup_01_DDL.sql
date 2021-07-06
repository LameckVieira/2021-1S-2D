CREATE DATABASE SP_Med_Group;
GO

USE SP_Med_Group;
GO

CREATE TABLE tiposUsuarios
(
	idTipoUsuario			INT PRIMARY KEY IDENTITY
	,tituloTipoUsuario		VARCHAR(200) UNIQUE NOT NULL
);
GO

CREATE TABLE clinicas
(
	idClinica				INT PRIMARY KEY IDENTITY
	,cnpj					CHAR(14) UNIQUE NOT NULL
	,razaoSocial			VARCHAR(200) NOT NULL
	,endereco				VARCHAR(200) UNIQUE NOT NULL
);
GO

CREATE TABLE usuarios
(
	idUsuario				INT PRIMARY KEY IDENTITY
	,idTipoUsuario			INT FOREIGN KEY REFERENCES tiposUsuarios(idTipoUsuario)
	,nome					VARCHAR(200) NOT NULL
	,email					VARCHAR(200) UNIQUE NOT NULL
	,senha					VARCHAR(200) NOT NULL
);
GO

CREATE TABLE pacientes
(
	idPaciente				INT PRIMARY KEY IDENTITY
	,idUsuario				INT FOREIGN KEY REFERENCES usuarios(idUsuario)
	,dataNascimento			DATE NOT NULL
	,telefone				VARCHAR(14)
	,rg						VARCHAR(9) UNIQUE NOT NULL
	,cpf					VARCHAR(11) UNIQUE NOT NULL
	,endereco				VARCHAR(255) NOT NULL
);
GO

CREATE TABLE especialidades
(
	idEspecialidade 		INT PRIMARY KEY IDENTITY
	,tituloEspecialidade	VARCHAR(200) UNIQUE NOT NULL
);
GO

CREATE TABLE medicos
(
	idMedico				INT PRIMARY KEY IDENTITY
	,idUsuario				INT FOREIGN KEY REFERENCES usuarios(idUsuario)
	,idEspecialidade		INT FOREIGN KEY REFERENCES especialidades(idEspecialidade)
	,idClinica				INT FOREIGN KEY REFERENCES clinicas(idClinica)
	,crm					VARCHAR(30) UNIQUE NOT NULL
);
GO

CREATE TABLE consultas
(
	idConsulta				INT PRIMARY KEY IDENTITY
	,idPaciente				INT FOREIGN KEY REFERENCES pacientes(idPaciente)
	,idMedico				INT FOREIGN KEY REFERENCES medicos(idMedico)
	,dataConsulta			DATETIME NOT NULL
	,situacao				VARCHAR(200) NOT NULL
	,descricao				VARCHAR(200)
);
GO