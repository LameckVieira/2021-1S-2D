CREATE DATABASE Clinica_SP_Medical_Group;
GO

USE Clinica_SP_Medical_Group;
GO

CREATE TABLE clinica
(
	 idClinica				INT PRIMARY KEY IDENTITY
	,nomeFantasia			VARCHAR(100) NOT NULL
	,cnpj					CHAR(14) UNIQUE NOT NULL
	,razaoSocial			VARCHAR(100) UNIQUE NOT NULL
	,endereco				VARCHAR(150) UNIQUE NOT NULL
	,dias					VARCHAR(150) NOT NULL
	,horarioabertura		TIME NOT NULL
	,horariofechamento		TIME NOT NULL
);
GO

CREATE TABLE tiposUsuarios
(
	 idTipoUsuario			INT PRIMARY KEY IDENTITY
	,tipoUsuario			VARCHAR(100) NOT NULL
);
GO

CREATE TABLE especialidade
(
	 idEspecialidade		INT PRIMARY KEY IDENTITY
	,nomeEspecialidade		VARCHAR(100) NOT NULL
);
GO

CREATE TABLE usuario
(
	idUsuario				INT PRIMARY KEY IDENTITY
	,idTipoUsuario			INT FOREIGN KEY REFERENCES tiposUsuarios(idTipoUsuario)
	,nomeUsuario			VARCHAR(150) NOT NULL
	,email					VARCHAR(150) UNIQUE NOT NULL
);
GO

CREATE TABLE paciente
(
	 idPaciente				INT PRIMARY KEY IDENTITY
	,idUsuario				INT FOREIGN KEY REFERENCES usuario(idUsuario)
	,dataNascimento			DATE NOT NULL
	,telefone				VARCHAR(20)
	,rg						CHAR(9) UNIQUE NOT NULL
	,cpf					CHAR(11) UNIQUE NOT NULL
	,endereco				VARCHAR(200) UNIQUE NOT NULL
);
GO

CREATE TABLE medico
(
	 idMedico				INT PRIMARY KEY IDENTITY
	,idUsuario				INT FOREIGN KEY REFERENCES usuario(idUsuario)
	,idClinica				INT FOREIGN KEY REFERENCES clinica(idClinica)
	,idEspecialidade		INT FOREIGN KEY REFERENCES especialidade(idEspecialidade)
	,crm					VARCHAR(20) UNIQUE NOT NULL
);
GO

CREATE TABLE consulta
(
	 idConsulta				INT PRIMARY KEY IDENTITY
	,idPaciente				INT FOREIGN KEY REFERENCES paciente(idPaciente)
	,idMedico				INT FOREIGN KEY REFERENCES medico(idMedico)
	,dataConsulta			DATETIME UNIQUE NOT NULL
	,situacao				VARCHAR(100) NOT NULL
);
GO