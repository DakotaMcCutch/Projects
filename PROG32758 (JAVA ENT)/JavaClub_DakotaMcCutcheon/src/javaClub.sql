use dev;

drop table if exists User;
CREATE TABLE User
  (id VARCHAR(25) NOT NULL Primary KEY,
  password varchar(25) not null,
  firstName varchar(25) not null,
  lastName varchar(25) not null,
  email varchar(50) not null);

insert into user value ('asd','qwerty','d','d','d');