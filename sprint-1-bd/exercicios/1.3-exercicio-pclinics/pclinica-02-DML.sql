USE Clinica;

INSERT INTO Donos (Nome)
VALUES ('Gaby')
	   ,('Lameck');

INSERT INTO TiposDePet (Tipo)
VALUES ('dog')
	   ,('cat');

INSERT INTO Racas (Raca, IdTipo)
VALUES ('Yorkshire', 1)
	   ,('Sphynx', 2);

INSERT INTO Pets (Nome, DataDeNascimento, IdDono, IdRaca)
VALUES ('Sisou', '28/02/2021', 2, 1)
	   ,('Chico', '28/02/2021', 1, 2);

INSERT INTO Veterinarios (Nome)
VALUES ('CAIQUE')
	   ,('Saulo');

UPDATE Veterinarios SET Nome = 'CAIQUE' WHERE IdVeterinario = 1;

INSERT INTO Clinicas (Nome, Endereco)
VALUES ('Clínica Veterinária do LameckJunhor', 'Rua das pedras, 2');

INSERT INTO Consultas (IdClinica, IdVeterinario, IdPet, Valor, DataDaConsulta)
VALUES (1, 1, 1, 250, '28/02/2021'),
	   (2, 2, 2, 250, '28/02/2021');