/* Change Password */
ALTER USER 'root'@'localhost' IDENTIFIED 
WITH mysql_native_password BY 'asd0986458212';

/* Reset AutoNum */
ALTER TABLE Names AUTO_INCREMENT = 1;

/* Build */
CREATE DATABASE TestDB;
CREATE TABLE NAMES (id varchar(255), name int);

/* Safty Mode */
SET SQL_SAFE_UPDATES = 0;

/* CRUD */
INSERT INTO NAMES (id , name) VALUES ('Amy', 20);

SELECT * FROM NAMES;

UPDATE NAMES SET id = 'Amy', name = 20 WHERE id = 'Johnny';

DELETE FROM NAMES WHERE id='Amy';