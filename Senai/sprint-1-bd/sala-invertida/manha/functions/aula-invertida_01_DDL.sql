--criado banco de dados
CREATE DATABASE Senai;

--entrar no banco de dados
USE Senai;

--criado tabela "Alunos"
CREATE TABLE Alunos
(
	IdAluno INT PRIMARY KEY IDENTITY
	,Nome VARCHAR(100) NOT NULL
	,Nota1 TINYINT NOT NULL
	,Nota2 TINYINT NOT NULL
	,Nota3 TINYINT NOT NULL
	,Nota4 TINYINT NOT NULL
	,Nota5 TINYINT NOT NULL
);

--criado tabela DadosAlunos
CREATE TABLE DadosAlunos
(
	IdDadoAluno INT PRIMARY KEY IDENTITY
	,IdAluno INT FOREIGN KEY REFERENCES	Alunos(IdAluno)
	,Curso VARCHAR(100) 
	,Periodo VARCHAR(100)
);

--função escalar
--criado função "Media"
CREATE FUNCTION Media (@Nome VARCHAR(50))
RETURNS	REAL
AS
	BEGIN
		DECLARE @Media REAL
		SELECT @Media = (Nota1 + Nota2 + Nota3 + Nota4 + Nota5)/5
		FROM Alunos
		WHERE Alunos.Nome  = @Nome
       	RETURN @Media
    END

--função Embutida
--criado função "MostrarNota"
CREATE FUNCTION MostrarNota (@Valor REAL)
RETURNS TABLE
AS
	RETURN(
		SELECT Alunos.Nome,     Alunos.Nota5 
		FROM Alunos
		WHERE Alunos.Nota5 > @Valor);

--função multi-instruções
--criar função "Multitabelas" - sem parâmetros nesse exemplo (é possível)
CREATE FUNCTION  MultiTabelas()
        --variável de tabelas 
RETURNS @Valores TABLE
		--essa variável vai receber os dados que se deseja provenientes de outras tabelas ("Alunos" e "DadosAlunos")
		(Nome VARCHAR(100),Nota1 TINYINT,Curso VARCHAR(100),Periodo VARCHAR(100))
AS
	BEGIN
		--inserir dentro da variável os dados abaixo
		INSERT @Valores(Nome,Nota1,Curso,Periodo)
			--os dados vem de onde? --> das tabelas "Alunos" e "DadosAlunos"
			SELECT Alunos.Nome,Alunos.Nota1,DadosAlunos.Curso,DadosAlunos.Periodo
			FROM Alunos
			--fazendo uma junção da tabela Alunos com a tabela DadosAlunos
			INNER JOIN DadosAlunos
			--onde o Id do Aluno da tabela aluno seja igual ao Id do aluno na tabela DadosAlunos
			ON Alunos.IdAluno = DadosAlunos.IdAluno;
		RETURN
	END


--exemplo de uso de uma função dentro de outra
CREATE FUNCTION  MultiTabelas1()
        --variável de tabelas 
RETURNS @Valores TABLE
		--essa variável vai receber os dados que se deseja provenientes de outras tabelas ("Alunos" e "DadosAlunos") e da função "Media"
		(Nome VARCHAR(100),Nota1 TINYINT,Curso VARCHAR(100),Periodo VARCHAR(100),Media TINYINT)
AS
	BEGIN
		--inserir dentro da variável os dados abaixo
		INSERT @Valores(Nome,Nota1,Curso,Periodo,Media)
			--os dados vem de onde? --> das tabelas "Alunos" e "DadosAlunos" e da função "Media"
			SELECT Alunos.Nome,Alunos.Nota1,DadosAlunos.Curso,DadosAlunos.Periodo,dbo.Media(Alunos.Nome)
			FROM Alunos
			--fazendo uma junção da tabela Alunos com a tabela DadosAlunos
			INNER JOIN DadosAlunos
			--onde o Id do Aluno da tabela aluno seja igual ao Id do aluno na tabela DadosAlunos
			ON Alunos.IdAluno = DadosAlunos.IdAluno ;
		RETURN
	END
	
	
	
