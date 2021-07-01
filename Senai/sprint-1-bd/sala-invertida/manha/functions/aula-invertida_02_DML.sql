--entrar no banco de dados
USE Senai;

--inserir dados na tabela "Alunos"
INSERT INTO Alunos(Nome,Nota1,Nota2,Nota3,Nota4,Nota5)
VALUES ('Carlos',7,8,9,10,5)
	  ,('Leandro',9,9,9,10,6)
	  ,('Enzo',5,9,10,5,8)
	  ,('João',8,9,10,5,4)
	  ,('Camila',7,8,9,10,8)
	  ,('Rafael',9,9,9,10,8);

--inserir dados na tabela "DadosAlunos"
INSERT INTO DadosAlunos(IdAluno,Curso,Periodo)
VALUES (1,'DEV','Manhã')
	   ,(2,'Redes','Manhã')
	   ,(3,'DEV','Tarde')
	   ,(4,'Design','Tarde')
	   ,(5,'Mobile','Manhã')
	   ,(6,'Excel','Manhã');