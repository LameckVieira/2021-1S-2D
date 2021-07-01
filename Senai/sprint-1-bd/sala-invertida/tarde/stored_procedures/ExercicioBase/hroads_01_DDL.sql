-- exercicio 1
CREATE DATABASE SENAI_HROADS_TARDE;

USE SENAI_HROADS_TARDE;

-- exercicio 2
CREATE TABLE TipoHabilidade
(
    idTipo    INT PRIMARY KEY IDENTITY
    ,Tipo    VARCHAR (50) NOT NULL
);

CREATE TABLE Habilidades
(
    idHabilidade    INT PRIMARY KEY IDENTITY
    ,idTipo            INT FOREIGN    KEY REFERENCES TipoHabilidade(idTipo)
    ,Habilidade        VARCHAR(200) NOT NULL
);

CREATE TABLE Classes
(
    idClasse            INT PRIMARY KEY IDENTITY
    ,Nome                VARCHAR(50)
);

CREATE TABLE ClassHab
(
    idClassHab        INT PRIMARY KEY IDENTITY
    ,idClasse        INT FOREIGN KEY REFERENCES Classes(idClasse)
    ,idHabilidade    INT FOREIGN KEY REFERENCES Habilidades(idHabilidade)
);

CREATE TABLE Personagens
(
    idPersonagem    INT PRIMARY KEY IDENTITY
    ,Nome            VARCHAR (20) NOT NULL
    ,CapacidadeMaxVida    INT
    ,CapacidadeMaxMana    INT
    ,DataAtualizacao    DATE
    ,DataCriacao        DATE
    ,idClasse        INT FOREIGN KEY REFERENCES Classes(idClasse)
);