Create database library

Create table NewBook(
Bid int Not null identity(1,1) primary key,
BName varchar (150) not null,
BAuthor varchar (150) not null,
BPablication varchar (150) not null,
BDate varchar (150) not null,
BPrice bigint not null,
BQty bigint not null,)


select*
from NewBook