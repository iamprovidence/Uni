-- select BOOK: id, isbn, name, author, publishing house
CREATE OR REPLACE VIEW BOOK_INFO AS
SELECT 
	B."id",
	B."isbn",
	B."name",
	A."name" AS "author name",
	A."surname" AS "author surname",
	PH."name" as "publishing house name"
FROM "Books" AS B
JOIN "BookAuthor" AS BA ON B."isbn" = BA."isbn"
JOIN "Authors" AS A ON A."id" = BA."id"
JOIN "BookPublishingHouse" AS BPH ON BPH."isbn" = B."isbn"
JOIN "Publishing house" AS PH ON BPH."publishing house id" = PH."id";

SELECT * FROM BOOK_INFO;

-- GET READERS THAT ARE DEBTORS
DROP MATERIALIZED VIEW DEBTORS;

CREATE MATERIALIZED VIEW DEBTORS AS
	SELECT
		R."id",
		R."name",
		R."surname",
		R."phone number",
		string_agg(B."name", ', ' ORDER BY B."name") AS "Book name"
	FROM "Readers" AS R
	JOIN "Abonnement" AS A ON R.code = A."reader code"
	JOIN "Books" AS B ON A.isbn = B.isbn
	WHERE A."return book date" IS NULL
	GROUP BY R."id",R."name", R."surname", R."phone number"
WITH DATA;

REFRESH MATERIALIZED VIEW DEBTORS;

SELECT * FROM  DEBTORS;

-- GET COUNTRY
CREATE OR REPLACE VIEW COUNTRY AS
	SELECT 
		row_number() OVER ( order by "country")::INT AS ID,
		"country"
	FROM "Publishing house"
	GROUP BY "country"
	ORDER BY "country";

SELECT * FROM COUNTRY;

-- GET CITY
CREATE OR REPLACE VIEW CITY AS
	SELECT 
		row_number() OVER ( order by "city name")::INT AS ID,
		"city name"
	FROM "Readers"
	GROUP BY "city name"
	ORDER BY "city name";

SELECT * FROM CITY;