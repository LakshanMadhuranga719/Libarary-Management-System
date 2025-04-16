create table IRBook(
id int not null IDENTITY (1,1) primary key,
Std_no varchar (250)not null,
std_name varchar (250)not null,
Std_dep varchar (250)not null,
Std_sem varchar (250)not null,
Std_contact bigint not null,
Std_email varchar (250)not null,
Book_name varchar (250)not null,
Book_issue_date varchar (250) NOT NULL,
Book_return_date varchar (250),

);
select * from IRBook

SELECT* from IRBook where Std_no = '1234' and Book_return_date is null