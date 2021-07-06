USE SP_Med_Group;
GO

SELECT nome, dataConsulta, situacao FROM usuarios
INNER JOIN pacientes
ON usuarios.idUsuario = pacientes.idUsuario
INNER JOIN consultas
ON pacientes.idPaciente = consultas.idPaciente
INNER JOIN medicos
ON consultas.idMedico = medicos.idMedico
WHERE email = 'alexandre@gmail.com' AND senha = '123';

SELECT nome, dataConsulta, situacao FROM usuarios
INNER JOIN medicos
ON usuarios.idUsuario = medicos.idUsuario
INNER JOIN consultas
ON medicos.idMedico = consultas.idMedico
WHERE email = 'roberto.possarle@spmedicalgroup.com.br' AND senha = '123';


