USE ProjetoAula;

INSERT INTO Escolas(NomeEscola)
values               ('Marina Cintra')
					,('Aracy Leme Da Veiga Ravache')
					,('Sesi 167');


INSERT INTO Materias(NomeMateria )
values               ('Matematica')
					,('Portugues')
					,('Historia')
					,('Artes')
					,('Ciencias')
					,('Quimica')
					,('Fisica');



INSERT INTO Aluno(NomeAluno,Responsavel)
VALUES              ('Chris','Rogerinha')
					,('Giovanni','Marcela')
					,('Alan','Claudio')
					,('Brenda','Brendo')
					,('Viana','Flavia')
					,('Maiara','MC Livinho')
					,('João','Joana');

INSERT INTO Professores(IdEscola,idMateria,NomeProfessor,Idade)
VALUES              ( 1,1 , 'Roger',30)
					,(1,2 , 'Ramirez',37)
					,(1,3, 'Zubumafu',42)
					,(1,4, 'Clotilde',60)
					,(1,5, 'Maria',23)
					,(1,6, 'Vitoria',28)
					,(1,7, 'Jubileia',25);


INSERT INTO Professores(IdEscola,idMateria,NomeProfessor,Idade)
VALUES              ( 2,1 , 'Cleiton',45)
					,(2,2 , 'Maria',29)
					,(2,5, 'Viviana',34);


INSERT INTO Professores(IdEscola,idMateria,NomeProfessor,Idade)
VALUES              ( 3,1 , 'Mc Livinho',90)
					,(3,2 , 'Claudiano',50)
					,(3,3, 'Marcelina',59)
					,(3,4, 'Rogerio',40);


INSERT INTO Sala(idAluno,idProfessor,NumeroSala,Serie, Periodo)
values               (1,3,1,9,'M')
					,(3,14,3,7,'T')
					,(5,9,7,3,'M')
					,(7,6,2,5,'N')
					,(6,5,5,2,'T')
					,(4,11,6,6,'M')
					,(2,13,9,4,'T');

