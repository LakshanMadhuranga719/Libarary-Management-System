
create table logintable(
id int not null identity (1,1)primary key ,
username varchar (150) not null,
pass varchar (150) not null,
)
insert into logintable (username,pass) values ('madhuranga','pass');


select*
from logintable