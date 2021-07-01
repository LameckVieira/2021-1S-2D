use feira;

select * from Barraca;
select * from Fruta;
select * from tipoFruta;
select * from Dono;

select Dono.nomeDono, Fruta.nomeFruta, tipoFruta.tipoFruta from Barraca
inner join Dono
on Barraca.idDono = Dono.idDono
inner join Fruta
on Barraca.idFruta = Fruta.idFruta
inner join tipoFruta
on Fruta.tipoFruta = tipoFruta.idTipoFruta;