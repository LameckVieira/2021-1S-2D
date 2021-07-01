use feira;

insert into Dono (nomeDono) values 
		('Joao'),
		('Marcos');

insert into tipoFruta (tipoFruta) values
			('Doce'),
			('Azeda');

insert into Fruta (tipoFruta, nomeFruta) values
					(1, 'Maçã'),
					(2, 'Abacaxi');

insert into Barraca (idDono, idFruta) values
						(1, 1),
						(2, 2);

