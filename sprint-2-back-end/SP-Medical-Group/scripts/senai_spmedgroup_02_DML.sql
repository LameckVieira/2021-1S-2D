USE SP_Med_Group;
GO

INSERT INTO tiposUsuarios (tituloTipoUsuario)
VALUES					  ('Administrador')
						 ,('Medico')
						 ,('Paciente');
GO

INSERT INTO clinicas (cnpj, razaoSocial, endereco)
VALUES				 ('86400902000130', 'SP Medical Group', 'Av Barão Limeira 532 SP');	
GO

INSERT INTO usuarios (idTipoUsuario, nome, email, senha)
VALUES				(1, 'admin', 'admim@adm.com', 'adm123')
				   ,(2, 'Ricardo Lemos', 'ricardo.lemos@spmedicalgroup.com.br', '123')
				   ,(2, 'Roberto Possarle', 'roberto.possarle@spmedicalgroup.com.br', '123')
				   ,(2, 'Helena Strada', 'helena.souza@spmedicalgroup.com.br', '123')
			 	   ,(3, 'Ligia', 'ligia@gmail.com', '123')
				   ,(3, 'Alexandre', 'alexandre@gmail.com', '123')
				   ,(3, 'Fernando', 'fernando@gmail.com', '123')
				   ,(3, 'Henrique', 'henrique@gmail.com', '123')
				   ,(3, 'João', 'joao@hotmail.com', '123')
				   ,(3,	'Bruno', 'bruno@gmail.com', '123')
				   ,(3,	'Mariana', 'mariana@outlook.com', '123');

GO

INSERT INTO pacientes (idUsuario, dataNascimento, telefone, rg, cpf, endereco)
VALUES				  (5, '13/10/1983',	'1134567654',	'435225435', '94839859000', 'R Estado de Israel 240, São Paulo, Estado de São Paulo, 04022-000')
					 ,(6, '23/07/2001', '11987656543', '326543457', '73556944057', 'Av. Paulista, 1578 - Bela Vista, São Paulo - SP, 01310-200')
					 ,(7, '10/10/1978', '11972084453', '546365253', '16839338002', 'Av. Ibirapuera - Indianópolis, 2927,  São Paulo - SP, 04029-200')
					 ,(8, '13/10/1985', '1134566543',	'543663625', '14332654765', 'R. Vitória, 120 - Vila Sao Jorge, Barueri - SP, 06402-030')
					 ,(9, '27/08/1975',	'1176566377',	'325444441', '91305348010', 'R. Ver. Geraldo de Camargo, 66 - Santa Luzia, Ribeirão Pires - SP, 09405-380')
					 ,(10, '21/03/1972', '11954368769',	'545662667', '79799299004', 'Alameda dos Arapanés, 945 - Indianópolis, São Paulo - SP, 04524-001')
					 ,(11, '05/03/2018', NULL, '545662668', '13771913039', 'R Sao Antonio, 232 - Vila Universal, Barueri - SP, 06407-140');

GO

INSERT INTO especialidades (tituloEspecialidade)
VALUES					   ('Acupuntura')
						  ,('Anestesiologia')
						  ,('Angiologia')
						  ,('Cardiologia')
						  ,('Cirurgia Cardiovascular')
						  ,('Cirurgia da Mão')
						  ,('Cirurgia do Aparelho Digestivo')
						  ,('Cirurgia Geral')
						  ,('Cirurgia Pediátrica')
						  ,('Cirurgia Plástica')
						  ,('Cirurgia Torácica')
						  ,('Cirurgia Vascular')
						  ,('Dermatologia')
						  ,('Radioterapia')
						  ,('Urologia')
						  ,('Pediatria')
						  ,('Psiquiatria');
GO

INSERT INTO medicos (idUsuario, idEspecialidade, idClinica, crm)
VALUES				(2,	2,	1,	'54356-SP')
				   ,(3,	17,	1,	'53452-SP')
				   ,(4,	16,	1,	'65463-SP');

GO

INSERT INTO consultas (idPaciente, idMedico, dataConsulta, situacao)
VALUES				  (1, 3, '20/01/2020 15:00', 'Realizada')
					 ,(2, 2, '06/01/2020 10:00', 'Cancelada')
					 ,(3, 2, '07/02/2020 11:00', 'Realizada')
					 ,(2, 2, '06/02/2018 10:00', 'Realizada')
					 ,(4, 1, '07/02/2019 11:00', 'Cancelada')
					 ,(1, 3, '08/03/2020 15:00', 'Agendada')
					 ,(4, 1, '09/03/2020 11:00', 'Agendada');							
GO
