--VERIFICAR EXISTÊNCIA DE TRIGGERS

--NUMA TABELA ESPECÍFICA
EXEC sp_helptrigger @tabname = Produtos;

--NO BANCO DE DADOS TODO
USE Aula_Trigger
SELECT [name], is_disabled FROM sys.triggers
WHERE is_disabled = 1 or is_disabled = 0;

--0 = Habilitado
--1 = Desabilitado