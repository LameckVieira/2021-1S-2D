SELECT * FROM clinica;
SELECT * FROM tiposUsuarios;
SELECT * FROM especialidade;
SELECT * FROM usuario;
SELECT * FROM paciente;
SELECT * FROM medico;
SELECT * FROM consulta;

--3. O administrador poderá cancelar o agendamento;
--Para cancelar o agendamento selecione o idConsulta da consulta a ser cancelada, exemplo a seguir:
UPDATE consulta
SET situacao = 'Cancelada'
WHERE idConsulta = '1';

--5. O médico poderá ver os agendamentos (consultas) associados a ele;

--Administração consegue ver todas as consultas por médico
SELECT medico.idMedico, usuario.nomeUsuario Medico, consulta.idConsulta, consulta.dataConsulta FROM consulta
INNER JOIN medico
ON consulta.idMedico = medico.idMedico
INNER JOIN usuario
ON medico.idUsuario = usuario.idUsuario
ORDER BY idMedico;

--Cada médico ve as consultas associadas ao seu ID
SELECT medico.idMedico, usuario.nomeUsuario Medico, consulta.idConsulta, consulta.dataConsulta FROM consulta
INNER JOIN medico
ON consulta.idMedico = medico.idMedico
INNER JOIN usuario
ON medico.idUsuario = usuario.idUsuario
WHERE consulta.idMedico LIKE '1';

--6. O médico poderá incluir a descrição da consulta que estará vinculada ao paciente (prontuário);
ALTER TABLE consulta ADD descricao VARCHAR(200);
GO
UPDATE consulta
SET descricao = 'O paciente apresentava sintomas semelhantes ao da COVID 19, foi encaminhado para os exames apropriados'
WHERE idConsulta = '1';
GO

--7. O paciente poderá visualizar suas próprias consultas;
--Administração consegue ver todas as consultas por paciente
SELECT paciente.idPaciente, usuario.nomeUsuario Paciente, consulta.idConsulta, consulta.dataConsulta FROM consulta
INNER JOIN paciente
ON consulta.idPaciente = paciente.idPaciente
INNER JOIN usuario
ON paciente.idUsuario = usuario.idUsuario
ORDER BY idPaciente;

--Cada paciente ve as consultas de acordo com o seu id (exemplo paciente id 2)
SELECT paciente.idPaciente, usuario.nomeUsuario Paciente, consulta.idConsulta, consulta.dataConsulta FROM consulta
INNER JOIN paciente
ON consulta.idPaciente = paciente.idPaciente
INNER JOIN usuario
ON paciente.idUsuario = usuario.idUsuario
WHERE consulta.idPaciente LIKE '2';
