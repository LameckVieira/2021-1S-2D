USE ProjetoAula;


SELECT * FROM Escolas;
SELECT * FROM Materias;
SELECT * FROM Aluno;
SELECT * FROM Professores;
SELECT * FROM Sala;

--Cume_Dist
SELECT
NomeProfessor,
 Idade,
 ROW_NUMBER() OVER (ORDER BY Idade) row_num,
 CUME_DIST() OVER (ORDER BY Idade) cume_dist_val
FROM
Professores;

--LAG
SELECT NumeroSala, Periodo, Serie,   
       LAG(NumeroSala, 1,9) OVER (ORDER BY NumeroSala) AS Salas 
FROM Sala  ;  

--Last Value
SELECT
 NomeProfessor,
 
 LAST_VALUE(NomeProfessor) OVER (ORDER BY NomeProfessor
 RANGE BETWEEN
 UNBOUNDED PRECEDING AND
 UNBOUNDED FOLLOWING
 ) highest_overtime_employee
FROM
 Professores;

 --Last Value 2
 SELECT
 Professores.NomeProfessor AS Professor,Sala.NumeroSala,Sala.Serie, Aluno.NomeAluno AS Aluno,
 LAST_VALUE(NumeroSala) OVER (PARTITION BY NomeProfessor 
 ORDER BY NomeAluno RANGE BETWEEN UNBOUNDED PRECEDING AND UNBOUNDED FOLLOWING) most_overtime_employee
FROM Sala
 INNER JOIN Professores
ON Professores.IdProfessor= Sala.IdProfessor
INNER JOIN Aluno
ON Aluno.IdAluno= Sala.IdAluno;

--Rank
SELECT   Professores.NomeProfessor AS Professor,Sala.NumeroSala,Sala.Serie, Aluno.NomeAluno AS Aluno, Aluno.Responsavel
    ,RANK() OVER   
    ( ORDER BY Serie DESC) AS Rank  
FROM	 Sala   
INNER JOIN Professores
ON Professores.IdProfessor= Sala.IdProfessor
INNER JOIN Aluno
ON Aluno.IdAluno= Sala.IdAluno
WHERE NumeroSala <5 
ORDER BY NumeroSala;  

--Ntile
SELECT Professores.NomeProfessor AS Professor, Escolas.NomeEscola AS Escola, Materias.NomeMateria 
    ,NTILE(4) OVER(ORDER BY NomeProfessor DESC) AS Quartile   
    ,CONVERT(NVARCHAR(4),NomeProfessor,1) No
FROM Professores    
INNER JOIN Materias   
    ON Professores.idMateria = Materias.idMateria 
INNER JOIN Escolas   
    ON Professores.IdEscola = Escolas.IdEscola ; 

	--Row Number
	SELECT ROW_NUMBER() OVER(ORDER BY Responsavel DESC) AS Row,   
    NomeAluno, Responsavel,  ROUND(Sala.NumeroSala,2,1) AS Sala   
FROM Aluno  
INNER JOIN Sala
ON Aluno.IdAluno=Sala.IdAluno;


--Dense Rank
SELECT  Escolas.NomeEscola,Sala.NumeroSala,Sala.Periodo,Sala.Serie,Aluno.NomeAluno AS Aluno, Professores.NomeProfessor AS Professor, Materias.NomeMateria  
    ,DENSE_RANK() OVER   
    ( ORDER BY NuMeroSala DESC) AS Rank  
FROM Sala 
INNER JOIN Aluno  
    ON Aluno.idAluno = Sala.idAluno
	INNER JOIN Professores   
    ON Professores.idProfessor = Sala.idProfessor 
	INNER JOIN Materias  
    ON Materias.idMateria = Professores.idMateria
	INNER JOIN Escolas   
    ON Professores.IdEscola = Escolas.IdEscola; 

	--COUNT
	SELECT COUNT(*) AS NumeroDeProfesores 
FROM Professores; 