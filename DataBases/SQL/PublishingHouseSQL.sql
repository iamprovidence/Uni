-- DROP TABLE "Publishing house";

CREATE TABLE "Publishing house"
(
	"id" SERIAL PRIMARY KEY,
	"name" NAME_DATA UNIQUE,
	"country" VARCHAR(30) NOT NULL
);

INSERT INTO "Publishing house"
	("name", "country")
VALUES  ('One Day Night','UK'),
	('4Square','USA'),
	('Morning','Ukraine'),
	('Basis','Ukraine');

SELECT * FROM "Publishing house";

SELECT "name" FROM "Publishing house"
WHERE "country" = 'Ukraine';
