create database feira;
use feira;

create table Dono
(
	idDono int primary key identity
	,nomeDono varchar (40) not null
)

create table tipoFruta
(
	idTipoFruta int primary key identity
	,tipoFruta varchar (40) not null
)

create table Fruta
(
	idFruta int primary key identity
	,tipoFruta int foreign key references tipoFruta(idTipoFruta)
	,nomeFruta varchar (40) not null
)

create table Barraca
(
	idBarra int primary key identity
	,idFruta int foreign key references Fruta(idFruta)
	,idDono  int foreign key references Dono(idDono)
)