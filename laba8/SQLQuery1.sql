create database asp8;
drop table users;

create table Users (
	id int primary key,
	lastName nvarchar(50),
	firstName nvarchar(50),
	email nvarchar(50),
	password nvarchar(50),
	status nvarchar(10),
	role nvarchar(10) CHECK (role IN('admin', 'user'))
)