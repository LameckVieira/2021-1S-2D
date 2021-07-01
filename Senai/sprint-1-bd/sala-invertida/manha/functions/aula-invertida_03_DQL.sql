--entrar no banco de dados 
USE Senai;

--consultar toda tabela "Alunos"
SELECT * FROM Alunos;

--Consultar toda tabela "DadosAlunos"
SELECT * FROM DadosAlunos;

--Consultar a média do aluno - function tipo escalar 
SELECT dbo.Media('Camila')AS [Média];

--Consultar nome e 5º nota do aluno que for maior do que o parâmetro 
-- function tipo Tabela embutida (Inline)
SELECT Nome,Nota5
FROM MostrarNota(3);

--Consultar nome,1º nota, curso e periodo que o aluno estuda
--function tipo multi-instruções (Multi-statement)
SELECT * FROM MultiTabelas();

--exemplo de função dentro de função
SELECT * FROM MultiTabelas1();
