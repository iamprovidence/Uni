CREATE TABLE "Publishing house"
(
	id SERIAL PRIMARY KEY,
	"name" VARCHAR(30) NOT NULL UNIQUE,
	country VARCHAR(30)
);

INSERT INTO "Publishing house"
	("name", country)
VALUES  ('One Day Night','UK'),
	('4Square','USA'),
	('Morning','Ukraine'),
	('Basis','Ukraine');

SELECT * FROM "Publishing house";

SELECT "name" FROM "Publishing house"
WHERE country = 'Ukraine';