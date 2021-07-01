USE Pclinics;
GO

INSERT INTO Clinicas(RazaoSocial, CNPJ, Endereco)
VALUES				('Meu Pimpão','99999999999999','Av. Barão de Limeira, 539');
GO

INSERT INTO TiposPets(Descricao)
VALUES				 ('Cachorro')
					,('Gato');
GO

INSERT INTO Racas(Descricao, IdTipoPet)
VALUES			 ('Poodle', 1)
				,('Labrador', 1)
				,('SRD', 1)
				,('Siamês', 2);
GO

INSERT INTO Donos(Nome)
VALUES			 ('Paulo')
				,('Odirlei');
GO

INSERT INTO Pets(Nome, DataNascimento, IdRaca, IdDono)
VALUES				('Junior', '10/10/2018', 1, 1)
				   ,('Loli', '18/05/2017', 4, 1)
				   ,('Sammy', '16/06/2016', 1, 2);
GO

INSERT INTO Veterinarios(Nome, CRMV, IdClinica)
VALUES					('Saulo', '432551', 1)
					   ,('Caique', '653655', 1);
GO

INSERT INTO Atendimentos(Descricao, DataAtendimento, IdVeterinario, IdPet)
VALUES					('Restam 10 dias de vida', '22/01/2019', 1, 1)
					   ,('O paciente está ok', '21/01/2019', 2, 2)
					   ,('O paciente está ok', '22/01/2019', 2, 1);
GO