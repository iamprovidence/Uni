-- DROP TABLE "Abonnement";

CREATE TABLE "Abonnement"
(
	"id" SERIAL PRIMARY KEY,
	"reader code" CODE_DATA,
	"isbn" ISBN_DATA,
	"book amount" INTEGER NOT NULL DEFAULT 1,
	"take book date" DATE NOT NULL,
	"return book date" DATE NULL CHECK ("return book date" >= "take book date"),

	FOREIGN KEY ("reader code") 
	REFERENCES "Readers" (code) ON DELETE CASCADE ON UPDATE CASCADE,
	FOREIGN KEY ("isbn") 
	REFERENCES "Books" ("isbn") ON DELETE CASCADE ON UPDATE CASCADE
);

INSERT INTO "Abonnement"
	("reader code", "isbn", "take book date", "return book date")
VALUES	('1a2d-adas-d2','978-666-14-6279-1', '10/4/2018', '11/4/2018'),
	('123a-a86q-6a','978-666-14-6279-1', '10/4/2018', '11/4/2018'),
	('123a-a86q-6a','978-965-18-6279-5', '10/5/2018', NULL),
	('12q4-asdq-6a','968-966-14-4289-8', '10/5/2018', NULL),
	('12w4-asdq-6a','978-966-13-6279-6', '10/6/2018', NULL),
	('12s4-asdq-6a','932-966-14-6229-3', '10/6/2018', NULL),
	('we34-asdq-6a','978-965-18-6279-5', '10/6/2018', NULL),
	('we34-asdq-6a','968-966-14-4289-8', '10/6/2018', NULL);

SELECT * FROM "Abonnement";

SELECT * FROM "Abonnement"
WHERE "return book date" IS NULL;

SELECT TRUNC(DATE_PART('day', "return book date"::timestamp - "take book date"::timestamp)) AS "Delay"
FROM "Abonnement"
WHERE "return book date" IS NOT NULL;

UPDATE "Abonnement"
SET "return book date" = '11/6/2018'
WHERE "id" = 15;

DELETE FROM "Abonnement"
WHERE "id" = 16;
