-- DROP TABLE "Books";

CREATE TABLE "Books"
(
	"id" SERIAL UNIQUE,
	"isbn" ISBN_DATA PRIMARY KEY,
	"name" BOOK_TITLE,
	"year" SMALLINT NULL,
	"total amount" INTEGER NOT NULL CHECK ("total amount" > 0),
	"amount to read home" INTEGER NOT NULL CHECK ("amount to read home" <= "total amount"),
	"amount to repair" INTEGER NOT NULL CHECK ("amount to repair" <= "total amount")
);


INSERT INTO "Books"
	("isbn", "name", "year", "total amount", "amount to read home", "amount to repair")
VALUES 	('978-666-14-6279-1', 'The Call of Cthulhu', 1826, 30, 23, 1),
	('952-966-14-2279-2', 'Dracula', 1897, 50, 40, 3),
	('932-966-14-6229-3', 'The Picture of Dorian Gray', 1891, 80, 12, 1),
	('978-122-14-3279-4', 'The Raven', 1845, 15, 0, 0),
	('978-965-18-6279-5', 'Masque of the Red Death', 1842, 30, 23, 1),
	('978-966-13-6279-6', 'Unwritten', 1666, 100, 0, 0),
	('968-996-14-6229-7', 'Collection 1', 2012, 30, 23, 1),
	('968-966-14-4289-8', 'Collection 2', 2018, 30, 23, 1);

SELECT * FROM "Books";

SELECT COUNT("id") FROM "Books";

SELECT SUM("total amount") AS "total book amount" FROM "Books";

SELECT SUM("amount to read home") AS "amount to read home" FROM "Books";

SELECT SUM("amount to repair") AS "amount to repair" FROM "Books";

SELECT SUM("total amount" - "amount to repair") AS "book available" FROM "Books";

SELECT "name" AS "title", 
"total amount" - "amount to read home" AS "book available to take home" 
FROM "Books"
ORDER BY "book available to take home" DESC;

SElECT * FROM "Books"
WHERE "name" LIKE '%ct%';
