-- DROP TABLE "Readers";

CREATE TABLE "Readers"
(
	id SERIAL PRIMARY KEY,
	
	"name" CHARACTER VARYING(30) NOT NULL,
	surname CHARACTER VARYING(30) NOT NULL,
	age INTEGER  CHECK (Age > 7 AND Age < 18) DEFAULT 8 NOT NULL,
	
	"city name" CHARACTER VARYING(30) NULL,
	"phone number" CHARACTER VARYING(12) NULL UNIQUE,
	code CHARACTER VARYING(12) NOT NULL UNIQUE	 
);


INSERT INTO "Readers" 
	("name", surname, age, "city name", "phone number", code)
VALUES  ('Sophia', 'Smith', 12, 'Lviv', '380928547663', '1a2d-adas-d2'),
	('Mia', 'Johnson', 9, 'Lviv' , '380964235864', '1234-asdq-6a'),
	('Isabella', 'Williams', 12, 'Kyiv' , '380965235864', '1964-asdq-6a'),
	('Emma', 'Jones', 10, 'Kyiv' , '380964235894', '123a-a86q-6a'),
	('Olivia', 'Davis', 16, 'Kyiv' , '380964236898', '1s34-asdq-6a'),
	('Ethan', 'Miller', 15, 'Orleon' , '380964735844', 'd234-asdq-6a'),
	('Jacob', 'Wilson', 13, 'Kyiv' , '380964239164', '12q4-asdq-6a'),
	('Mason', 'Moore', 12, 'Kyiv' , '380964236364', '12w4-asdq-6a'),
	('David', 'Taylor', 14, 'Orleon' , '380964335264', 'a234-asdq-6a'),
	('Chloe', 'Anderson', 17, 'Kyiv' , '380964935564', 'z234-asdq-6a'),
	('Lily', 'Thomas', 17, 'Kyiv' , '380964235764', '123a-asdq-6a'),
	('Avery', 'White', 16, 'Lviv' , '380964265464', '12s4-asdq-6a'),
	('David', 'Harris', 12, 'Orleon' , '380994296864', 'we34-asdq-6a'),
	('Liam', 'Marthin', 9, 'Orleon' , '380984235324', '1qw4-asdq-6a'),
	('Logan', 'Thompson', 8, 'Lviv' , '380964235336', '1as4-asdq-6a'),
	('Elijah', 'Garcia', 9, 'Lviv' , '380969235123', '1zc4-asdq-6a'),
	('Zoey', 'Clarck', 12, 'Kyiv' , '380989235321', '12a4-a5dq-6a');
# test insert
INSERT INTO "Readers"
	("name", surname, age, "city name", "phone number", code)
VALUES  ('', '', , '', '', '');

SELECT * FROM "Readers";

SELECT "name" FROM "Readers"
WHERE "city name" = 'Lviv';

SELECT * FROM "Readers"
WHERE age > 12
ORDER BY "name";

SELECT COUNT (DISTINCT age) FROM "Readers";

SELECT "name", surname, age FROM "Readers"
WHERE age BETWEEN 10 AND 12
ORDER BY "name", surname;

SELECT Avg(age) AS "Average readers age" FROM "Readers";

SELECT CONCAT ("name", ' ' , "city name", ' ', "phone number" )
AS "contact" FROM "Readers"
ORDER BY "city name";