-- GENERAL

-- select book by author name
SELECT * FROM "Books"
WHERE "isbn" IN (
	SELECT "isbn" FROM "BookAuthor"
	WHERE "author id" IN( 
		SELECT id FROM "Authors"
		WHERE "name" = 'Howard' AND "surname" = 'Lovecraft')
);

-- same

SELECT * 
	FROM 
		"Books" AS B,
		"BookAuthor" AS BA,
		"Authors" AS A
WHERE 
	(A.name = 'Howard' AND A.surname = 'Lovecraft')
	AND A.id = BA."author id" AND BA.isbn = B.isbn;

-- select book name and author name
SELECT  b.name AS "book name",
	CONCAT(a.name, ' ', a.surname) AS "author name"
FROM 
	"Books" AS b,
	"BookAuthor" AS ba, 
	"Authors" AS a
WHERE b.isbn = ba.isbn AND ba."author id" = a.id;

-- select book by publishing house id
SELECT * FROM "Books"
WHERE "isbn" IN (
	SELECT "isbn" FROM "BookPublishingHouse"
	WHERE "publishing house id" = 2
);

-- select book name and publishing house name
SELECT 
	B.name,
	PH.name
FROM 
	"Books" AS B,
	"BookPublishingHouse" AS BPH,
	"Publishing house" AS PH
WHERE B.isbn = BPH.isbn AND BPH."publishing house id" = PH.id;
-- select book name and publishing house
SELECT	B."name", PH."name"
FROM	"Books" AS B
JOIN	"BookPublishingHouse" AS BPH
ON 	BPH."isbn" = B."isbn"
JOIN	"Publishing house" AS PH
ON	BPH."publishing house id" = PH."id";
-- same
SELECT 
	B."id", B."name", PH."name" AS "Publishing house name"
FROM 
	"Books" AS B
JOIN "BookPublishingHouse" AS BPH ON BPH."isbn" = B."isbn"
JOIN "Publishing house" AS PH ON BPH."publishing house id" = PH."id";

/*
 select author name, book name, publishing house name 
 published in Ukraine
 ordered by author name
*/
-- 15408 ms without index
-- 500 ms with index
SELECT 
	CONCAT(a.name, ' ', a.surname) AS "author name",
	B.name AS "book name",
	PH.name AS "publishing house name"
FROM 
	"Books" AS B,
	"BookPublishingHouse" AS BPH,
	"Publishing house" AS PH,
	"Authors" AS A,
	"BookAuthor" AS BA
WHERE 
	B.isbn = BPH.isbn 
	AND BPH."publishing house id" = PH.id
	AND PH.country = 'Ukraine'
	AND B.isbn = BA.isbn
	AND BA."author id" = A.id
ORDER BY A.name;

-- select readear contact which has not return book and delay in day
-- 12684 ms without index
SELECT 
	CONCAT("name", ' ' ,"phone number", ' ', "city name") AS "Reader contact",
	A."take book date" AS "book taken",
	TRUNC(DATE_PART('day', 
	 now()::timestamp - A."take book date"::timestamp ))::INTEGER AS "Delay"
FROM 
	"Readers" AS R ,
	"Abonnement" AS A
WHERE 
	A."reader code" = R."code"
	AND A."return book date" IS NULL;

-- select book name and their author
SELECT
	B."name" AS "Book name", 
	A."name", 
	A."surname"
FROM 
	"Books" AS B
JOIN	"BookAuthor" AS BA 	
ON	BA."isbn" = B."isbn"
JOIN 	"Authors" AS A
ON	A."id" = BA."author id";

-- select author name, and the number of their taken book
-- order by book taken
-- 5582 ms without index
-- 2337 ms with index
SELECT A."name", A."surname", Sum(AB."book amount")::int AS "Book taken"
FROM "Authors" AS A
JOIN "BookAuthor" AS BA ON BA."author id" = A."id"
JOIN "Books" AS B ON BA."isbn" = B."isbn"
JOIN "Abonnement" AS AB ON AB."isbn" = B."isbn"
GROUP BY A."name", A."surname"
ORDER BY "Book taken" DESC;
-- select publishing house name and their book released amount
SELECT 
	PH."name", 
	Count(PH."name") AS "Book variety", 
	Sum(B."total amount") AS "Total book released"
FROM "Publishing house" AS PH
JOIN "BookPublishingHouse" AS BPH ON PH."id" = BPH."publishing house id"
JOIN "Books" AS B ON BPH."isbn" = B."isbn"
GROUP BY PH."name"
ORDER BY PH."name";
