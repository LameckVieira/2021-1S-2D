USE Clinica_SP_Medical_Group
GO

INSERT INTO clinica (cnpj,nomeFantasia , endereco, dias, horarioabertura, horariofechamento, razaoSocial)
VALUES	('86400902000130', 'Clinica Possarle ', 'Av. Barão Limeira, 532, São Paulo, SP', 'Sengunda a Sexta', '08:00:00', '17:00:00','SP Medical Group');


INSERT INTO TiposUsuarios (tipoUsuario)
VALUES	('Administrador'),
		('Médico'),
		('Paciente');


INSERT INTO especialidade( nomeEspecialidade)
VALUES	('Acupuntura'),
		('Anestesiologia'),
		('Angiologia'),
		('Cardiologia'),
		('Cirurgia Cardiovascular'),
		('Cirurgia da Mão'),
		('Cirurgia do Aparelho Digestivo'),
		('Cirurgia Geral'),
		('Cirurgia Pediátrica'),
		('Cirurgia Plástica'),
		('Cirurgia Torácica'),
		('Cirurgia Vascular'),
		('Dermatologia'),
		('Radioterapia'),
		('Urologia'),
		('Pediatria'),
		('Psiquiatria');

INSERT INTO usuario(idTipoUsuario, nomeUsuario, email)
VALUES	(1, 'adm', 'adm@adm.com'),
		(2, 'Ricardo Lemos', 'ricardo.lemos@spmedicalgroup.com.br'),
		(2, 'Roberto Possarle', 'roberto.possarle@spmedicalgroup.com.br'),
		(2, 'Helena Strada', 'helena.souza@spmedicalgroup.com.br'),
		(3, 'Ligia', 'ligia@gmail.com'),
		(3, 'Alexandre', 'alexandre@gmail.com'),
		(3, 'Fernando', 'fernando@gmail.com'),
		(3, 'Henrique', 'henrique@gmail.com'),
		(3, 'João', 'joao@hotmail.com'),
		(3, 'Bruno', 'bruno@gmail.com'),
		(3, 'Mariana', 'mariana@outlook.com');

INSERT INTO paciente(idUsuario, dataNascimento, telefone, rg, cpf, endereco)
VALUES	(5, '13/10/1983', '11 3456-7654', '435225435', '94839859000', 'Rua Estado de Israel 240, São Paulo, Estado de São Paulo, 04022-000'),
		(6, '23/07/2001', '11 98765-6543', '326543457', '73556944057', 'Av. Paulista, 1578 - Bela Vista, São Paulo - SP, 01310-200'),
		(7, '10/10/1978', '11 97208-4453', '546365253', '16839338002', 'Av. Ibirapuera - Indianópolis, 2927, São Paulo - SP, 04029-200'),
		(8, '13/10/1985', '11 3456-6543', '543663625', '14332654765', 'R. Vitória, 120 - Vila Sao Jorge, Barueri - SP, 06402-030'),
		(9, '27/08/1975', '11 7656-6377', '325444441', '91305348010', 'R. Ver. Geraldo de Camargo, 66 - Santa Luzia, Ribeirão Pires - SP, 09405-380'),
		(10, '21/03/1972', '11 95436-8769', '545662667', '79799299004', 'Alameda dos Arapanés, 945 - Indianópolis, São Paulo - SP, 04524-001'),
		(11, '03/05/2018', '', '545662668', '13771913039', 'R Sao Antonio, 232 - Vila Universal, Barueri - SP, 06407-140');

INSERT INTO medico(idUsuario, idClinica, idEspecialidade, crm)
VALUES	(2, 1, 2, '54356-SP'),
		(3, 1, 17, '53452-SP'),
		(4, 1, 16, '65463-SP');
UPDATE  medico 
SET idEspecialidade = '1' 
WHERE idEspecialidade ='2';

INSERT INTO consulta(idPaciente, idMedico, dataConsulta, situacao)
VALUES	(14, 3, '20/01/2020 15:00:00', 'Realizada'),
		(14, 2, '01/06/2020  10:00:00', 'Cancelada'),
		(16, 2, '02/07/2020  11:00:00', 'Realizada'),
		(17, 2, '02/06/2018  10:00:00', 'Realizada'),
		(18, 1, '02/07/2019  11:00:00', 'Cancelada'),
		(19, 3, '03/08/2020  15:00:00', 'Agendada'),
		(20, 1, '03/09/2020  11:00:00', 'Agendada');