--Soma
SELECT 7+7			 AS Resultado

SELECT 7+7+7		 AS Resultado

--Subtração
SELECT 27-7			 AS Resultado

SELECT 27-7-7		 AS Resultado

--Divisão
SELECT 50 / 2		 AS Resultado

SELECT 49 / 2		 AS Resultado

SELECT 49.99 / 2	 AS Resultado

--Multiplicação
SELECT 50 * 2        AS Resultado

--Potencialização / Vai resultar no quadrado do número
SELECT SQUARE(7)     AS Resultado   --Número x ele mesmo

--Número ao cubo
SELECT POWER (2, 3)  AS Resultado -- 2 x 2 x 2 

--Porcentagem
SELECT 100 * 0.1	 AS Resultado
SELECT 100 * 0.50    AS Resultado
SELECT 100 * 1.20    AS Resultado

--ABS / Número inteiro
SELECT ABS (10 - 30) AS Resultado
SELECT ABS (-30)     AS Resultado

--Raiz Quadrada
SELECT SQRT (36)     AS Resultado
SELECT SQRT (8)      AS Resultado

--Sinal / Ultilizamos para pegar o sinal do no numero
SELECT SIGN (10)     AS Resultado
SELECT SIGN (-10)    AS Resultado
SELECT SIGN (0)      AS Resultado
SELECT SIGN (Null)   AS Resultado

--SOMA
SELECT SUM  (1+1)    AS Resultado --Função de agregação
