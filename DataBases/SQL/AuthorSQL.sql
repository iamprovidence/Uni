-- DROP TABLE "Authors";

CREATE TABLE "Authors"
(
	"id" SERIAL PRIMARY KEY,
	"name" NAME_DATA,
	"surname" NAME_DATA
);

INSERT INTO "Authors" 
	("name", "surname")
VALUES  ('Howard', 'Lovecraft'),
	('Edgar', 'Poe'),
	('Abraham', 'Stoker'),
	('Oscar', 'Wilde');

SELECT * FROM "Authors";
