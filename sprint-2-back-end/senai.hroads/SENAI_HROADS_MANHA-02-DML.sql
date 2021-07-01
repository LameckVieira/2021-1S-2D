--3.	Inserir os registros conforme descrição no próprio texto (classes, habilidades, tipos de habilidades e personagens);
USE Hroads;

INSERT INTO Jogo(NomeJogo)
VALUES ('Hroads');

INSERT INTO Classe(NomeClasse)
VALUES ('Bárbaro')
	  ,('Monge')
	  ,('Arcanista')
	  ,('Cruzado')
	  ,('Caçadora de Demônios')
	  ,('Necromante')
	  ,('Feiticeiro');

--SELECT * FROM Classe;

INSERT INTO Tipo(NomeTipo)
VALUES ('Ataque')
	  ,('Defesa')
	  ,('Cura')
	  ,('Magia');

INSERT INTO Habilidade(idTipo, NomeHabilidade)
VALUES (1, 'Lança Mortal')
	  ,(2, 'Escudo Supremo')
	  ,(3, 'Recuperar Vida');

INSERT INTO ClasseHabilidade(idClasse, idHabilidade)
VALUES (1,1)
	  ,(2,2)
	  ,(3,3);

INSERT INTO ClasseHabilidade(idClasse, idHabilidade)
VALUES (1,2)
	  ,(2,3);

INSERT INTO ClasseHabilidade(idClasse, idHabilidade)
VALUES (4,2)
	  ,(5,1);
	  
/*SELECT * FROM ClasseHabilidade;
DELETE FROM ClasseHabilidade;*/

INSERT INTO Personagem(idJogo, idClasse, NomePersonagem, CapacidadeMaximaDeVida, CapacidadeMaximaDeMana, DataAtualizacao, DataCriacao)
VALUES (1, 1, 'DeuBug', 100, 80, '02/03/2021', '18/01/2019')
	  ,(1, 2, 'BitBug', 70, 100, '02/03/2021', '17/03/2016')
	  ,(1, 3, 'Fer8', 75, 60, '02/03/2021', '18/03/2018');

--SELECT * FROM Personagem;

--4.	Atualizar o nome do personagem Fer8 para Fer7;
UPDATE Personagem
SET NomePersonagem = 'Fer7'
WHERE idPersonagem = 3;

--5.	Atualizar o nome da classe de Necromante para Necromancer;
UPDATE Classe
SET NomeClasse = 'Necromancer'
WHERE idClasse = 6;