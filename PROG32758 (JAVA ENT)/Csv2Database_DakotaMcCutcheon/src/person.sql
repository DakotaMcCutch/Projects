use dev;

drop table if exists Person;
CREATE TABLE Person (
  id int NOT NULL AUTO_INCREMENT PRIMARY KEY,
  firstName VARCHAR(25) NOT NULL,
  lastName VARCHAR(25) NOT NULL,
  companyName VARCHAR(50) NOT NULL,
  address VARCHAR(50) NOT NULL,
  city VARCHAR(50) NOT NULL,
  province VARCHAR(25) NOT NULL,
  postal VARCHAR(7) NOT NULL,
  phone1 VARCHAR(25) NOT NULL,
  phone2 VARCHAR(25) NOT NULL,
  email VARCHAR(50) NOT NULL,
  web VARCHAR(50) NOT NULL
);