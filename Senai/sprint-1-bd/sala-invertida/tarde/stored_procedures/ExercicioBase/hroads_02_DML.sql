USE SENAI_HROADS_TARDE;
-- exercicio 3
INSERT INTO TipoHabilidade    (Tipo)
VALUES                        ('Ataque')
                            ,('Defesa')
                            ,('Cura')
                            ,('Magia');

INSERT INTO Habilidades        (Habilidade, idTipo)
VALUES                        ('Lança Mortal', 1)
                            ,('Escudo Supremo', 2)
                            ,('Recuperar Vida', 3);

INSERT INTO Classes            (Nome)
VALUES                        ('Bárbaro')
                            ,('Cruzado')
                            ,('Caçadora de Demônios')
                            ,('Monge')
                            ,('Necromante')
                            ,('Feiticeiro')
                            ,('Arcanista');

INSERT INTO ClassHab        (idClasse, idHabilidade)
VALUES                        (1, 1)
                            ,(1, 2)
                            ,(2, 2)
                            ,(3, 1)
                            ,(4, 2)
                            ,(4, 3)
                            ,(6, 3);

INSERT INTO Personagens        (Nome, CapacidadeMaxVida, CapacidadeMaxMana, DataAtualizacao, DataCriacao, idClasse)
VALUES                        ('DeuBug', '100', '80', '2021/03/01', '2019/01/18', 1)
                            ,('BitBug', '70', '100', '2021/03/01', '2016/03/17', 4)
                            ,('Fer8', '75', '60', '2021/03/01', '2018/03/17', 7);
-- exercicio 4
UPDATE Personagens
SET Nome = 'Fer7'
WHERE idPersonagem = 3
-- exercicio 5
UPDATE Classes
SET Nome = 'Necromancer'
WHERE idClasse = 5