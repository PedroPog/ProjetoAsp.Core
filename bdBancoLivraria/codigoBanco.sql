create database bancolivraria;
use bancolivraria;

create table status_tb(
idstatus int primary key auto_increment,
namestatus varchar(50)
);

insert into status_tb values(default,'Disponível'),(default,'Indisponível');

select * from status_tb;

create table autor_tb (
idautor int primary key auto_increment,
nameautor varchar(50),
status int,
foreign key (status) references status_tb (idstatus)
);

create table livro_tb(
idlivro int primary key auto_increment,
namelivro varchar(50),
idautor int,
foreign key (idautor) references autor_tb (idautor)
);

insert into autor_tb (nameautor, status) values ('Machado de Assis',1);
insert into autor_tb (nameautor, status) values ('Érico Veríssimo',1);
insert into autor_tb (nameautor, status) values ('Guimarães Rosa',1);
insert into autor_tb (nameautor, status) values ('Carlos Drummond de Andrade',2);
insert into autor_tb (nameautor, status) values ('Clarice Lispector',1);
insert into autor_tb (nameautor, status) values ('Paulo Coelho',1);
insert into autor_tb (nameautor, status) values ('Manuel Bandeira',2);
insert into autor_tb (nameautor, status) values ('Vinicius de Moraes',2);
insert into autor_tb (nameautor, status) values ('Monteiro Lobato',2);

select * from autor_tb;
select * from livro_tb;

