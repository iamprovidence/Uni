-- DROP TABLE "Authors";

CREATE TABLE "Authors"
(
	id SERIAL PRIMARY KEY,
	"name" VARCHAR(30) NOT NULL,
	surname VARCHAR(30) NOT NULL
);

INSERT INTO "Authors" 
	("name", surname)
VALUES  ('Howard', 'Lovecraft'),
	('Edgar', 'Poe'),
	('Abraham', 'Stoker'),
	('Oscar', 'Wilde');

SELECT * FROM "Authors";