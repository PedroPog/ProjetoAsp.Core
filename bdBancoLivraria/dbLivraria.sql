create database bdLivraria;

use bdLivraria;

create table tbStatus(
codStatus int primary key auto_increment,
sta varchar(50)
);

insert into tbStatus values(default,'Disponível'),(default,'Indisponível');

select * from tbStatus;

create table tbAutor (
codAutor int primary key auto_increment,
nomeAutor varchar(50),
sta int,
foreign key (sta) references tbStatus (codStatus)
);

create table tbLivro(
codLivro int primary key auto_increment,
nomeLivro varchar(50),
codAutor int,
foreign key (codAutor) references tbAutor (codAutor)
);

insert into tbAutor (nomeAutor, sta) values ('Machado de Assis',1);
insert into tbAutor (nomeAutor, sta) values ('Érico Veríssimo',1);
insert into tbAutor (nomeAutor, sta) values ('Guimarães Rosa',1);
insert into tbAutor (nomeAutor, sta) values ('Carlos Drummond de Andrade',2);
insert into tbAutor (nomeAutor, sta) values ('Clarice Lispector',1);
insert into tbAutor (nomeAutor, sta) values ('Paulo Coelho',1);
insert into tbAutor (nomeAutor, sta) values ('Manuel Bandeira',2);
insert into tbAutor (nomeAutor, sta) values ('Vinicius de Moraes',2);
insert into tbAutor (nomeAutor, sta) values ('Monteiro Lobato',2);

select * from tbAutor;
select * from tbLivro;

