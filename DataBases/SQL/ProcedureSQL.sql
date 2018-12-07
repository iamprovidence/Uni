-- SELECT BEST AUTHOR
CREATE OR REPLACE FUNCTION GET_TOP_AUTHOR (amount INT)
RETURNS TABLE
(
	"id" int,
	"name" NAME_DATA,
	"surname" NAME_DATA,
	"book taken" int
)
AS $$
BEGIN
	RETURN QUERY
	SELECT 
		A."id",
		A."name", 
		A."surname", 
		Sum(AB."book amount")::int AS "book taken"
	FROM "Authors" AS A
	JOIN "BookAuthor" AS BA ON BA."author id" = A."id"
	JOIN "Books" AS B ON BA."isbn" = B."isbn"
	JOIN "Abonnement" AS AB ON AB."isbn" = B."isbn"
	GROUP BY A."id", A."name", A."surname"
	ORDER BY "book taken" DESC
	LIMIT amount;
END; 
$$
LANGUAGE 'plpgsql';

-- SELECT BOOK BY AUTHOR NAME
CREATE OR REPLACE FUNCTION GET_BOOK_BY_AUTHOR (name_pattern VARCHAR) 
RETURNS 
TABLE 
(
	"id" int,
	"isbn" ISBN_DATA,
	"name" BOOK_TITLE,
	"year" smallint,
	"total amount" int,
	"amount ot read home" int,
	"amount to repair" int,
	"author name" NAME_DATA,
	"author surname" NAME_DATA	
) 
AS $$
BEGIN
	RETURN QUERY 
	SELECT B.*, A."name" AS "author name", A."surname" AS "author surname"
	FROM "Books" AS B
	LEFT JOIN "BookAuthor" AS BA ON B."isbn" = BA."isbn"	
	LEFT JOIN "Authors" AS A ON A."id" = BA."author id"
	WHERE A."name" LIKE name_pattern OR A."surname" LIKE name_pattern;
END; 
$$
LANGUAGE 'plpgsql';

CREATE OR REPLACE FUNCTION GET_BOOK_BY_AUTHOR (name_pattern NAME_DATA, surname_pattern NAME_DATA) 
RETURNS 
TABLE 
(
	"id" int,
	"isbn" ISBN_DATA,
	"name" BOOK_TITLE,
	"year" smallint,
	"total amount" int,
	"amount ot read home" int,
	"amount to repair" int,
	"author name" NAME_DATA,
	"author surname" NAME_DATA
) 
AS $$
BEGIN
	RETURN QUERY 
	SELECT B.*, A."name" AS "author name", A."surname" AS "author surname"
	FROM "Books" AS B
	LEFT JOIN "BookAuthor" AS BA ON B."isbn" = BA."isbn"	
	LEFT JOIN "Authors" AS A ON A."id" = BA."author id"
	WHERE A."name" LIKE name_pattern OR A."surname" LIKE surname_pattern;
END; 
$$
LANGUAGE 'plpgsql';

-- SELECT BOOK BY PUBLISHING HOUSE
CREATE OR REPLACE FUNCTION GET_BOOK_BY_PUBLISHING_HOUSE (name_pattern VARCHAR) 
RETURNS 
TABLE 
(
	"id" int,
	"isbn" ISBN_DATA,
	"name" BOOK_TITLE,
	"year" smallint,
	"total amount" int,
	"amount ot read home" int,
	"amount to repair" int,
	"publishing house" NAME_DATA
) 
AS $$
BEGIN
	RETURN QUERY 
	SELECT B.*, PH."name" AS "publishing house" FROM "Books" AS B
	LEFT JOIN "BookPublishingHouse" AS BPH ON B."isbn" = BPH."isbn"	
	LEFT JOIN "Publishing house" AS PH ON PH."id" = BPH."publishing house id"
	WHERE PH."name" LIKE name_pattern;
END; 
$$
LANGUAGE 'plpgsql';

--DROP FUNCTION GET_BOOK_BY_PUBLISHING_HOUSE (name_pattern VARCHAR);

-- SELECT author name, book name, book id, book isbn, publishing house name 
-- published in COUNTRY
-- ordered by author name
CREATE OR REPLACE FUNCTION GET_BOOK_INFO_BY_COUNTRY (name_pattern VARCHAR) 
RETURNS 
TABLE 
(
	"id" int,
	"isbn" ISBN_DATA,
	"name" BOOK_TITLE,
	"publishing house" NAME_DATA,	
	"author name" NAME_DATA,
	"author surname" NAME_DATA
) 
AS $$
BEGIN
	RETURN QUERY 
	SELECT 
		B."id",
		B."isbn",
		B."name",
		PH.name AS "publishing house",
		A."name" AS "author name", 
		A."surname" AS "author surname"		
	FROM 
		"Books" AS B
	LEFT JOIN "BookPublishingHouse" AS BPH ON B."isbn" = BPH."isbn"
	LEFT JOIN "Publishing house" AS PH ON BPH."publishing house id" = PH."id"
	LEFT JOIN "BookAuthor" AS BA ON B."isbn" = BA."isbn"
	LEFT JOIN "Authors" AS A ON BA."author id" = A."id"
	WHERE PH.country LIKE name_pattern
	ORDER BY A.name, A.surname;
END; 
$$
LANGUAGE 'plpgsql';

-- SELECT reader contact, taken book date, daley day
-- by delay day
CREATE OR REPLACE FUNCTION GET_READER_WITH_DELAY (delay INT) 
RETURNS 
TABLE 
(
	"id" int,
	"name" NAME_DATA,
	"phone number" character varying(12),
	"city name" NAME_DATA,
	"book taken" date,
	"Delay" int
) 
AS $$
BEGIN	
	RETURN QUERY 
	SELECT 
		R."id",
		R."name",
		R."phone number",
		R."city name",
		A."take book date" AS "book taken",
		TRUNC(DATE_PART('day', 
		 now()::timestamp - A."take book date"::timestamp ))::INTEGER AS "Delay"
	FROM 
		"Readers" AS R
	LEFT JOIN "Abonnement" AS A ON A."reader code" = R."code"
	WHERE A."return book date" IS NULL
		AND TRUNC(DATE_PART('day', 
		 now()::timestamp - A."take book date"::timestamp ))::INTEGER >= delay
	ORDER BY "Delay" DESC;
END; 
$$
LANGUAGE 'plpgsql';

SELECT
 *
FROM GET_READER_WITH_DELAY(10);

-- SELECT READERS BY THEIR AGE
CREATE OR REPLACE FUNCTION GET_READERS_BY_AGE (reader_age INT) 
RETURNS 
TABLE 
(
	"id" int,
	"name" NAME_DATA,		
	"surname" NAME_DATA,
	"age" int,
	"phone number" varchar(12),
	"city name" NAME_DATA,
	"code" CODE_DATA
) 
AS $$
BEGIN	
	RETURN QUERY 
	SELECT 
		R.*
	FROM 
		"Readers" AS R
	WHERE
		R."age" = reader_age;
	
END; 
$$
LANGUAGE 'plpgsql';

SELECT * FROM GET_READERS_BY_AGE(17);

-- GET RANDOM STRING
CREATE OR REPLACE FUNCTION RANDOM_STRING(length INT) 
RETURNS TEXT 
AS $$
DECLARE
  chars text[] := '{0,1,2,3,4,5,6,7,8,9,A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z,a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,x,y,z}';
  result text := '';
  i integer := 0;
BEGIN
	if length <= 0 then
		raise exception 'Given length cannot be less than 0';
	end if;
	
	for i in 1..length loop
		result := result || chars[1+random()*(array_length(chars, 1)-1)];
	end loop;
	return result;
END;
$$
LANGUAGE 'plpgsql';

-- GET RANDOM NAME
CREATE OR REPLACE FUNCTION RANDOM_NAME() 
RETURNS TEXT 
AS $$
DECLARE
  names_arr text[] := 
	'{﻿Bennie,
	Wan,
	Neil,
	Lynna,
	Chrissy,
	Vivienne,
	Ambrose,
	Salina,
	Thelma,
	Joellen,
	Donovan,
	Margarita,
	Eliseo,
	Lavada,
	Letitia,
	Kayleen,
	Hermine,
	Yvette,
	Dino,
	Tabitha,
	Margareta,
	Jordon,
	Loree,
	Crystle,
	Darcey,
	Tameika,
	Josiah,
	Kathie,
	Galen,
	Chauncey,
	Jeannetta,
	Sharonda,
	Petra,
	Victor,
	Vida,
	Corinna,
	Dee,
	Pia,
	Carry,
	Hipolito,
	Colleen,
	Katelynn,
	Henry,
	Argelia,
	Rossie,
	Lavonia,
	Zena,
	Ashleigh,
	Annmarie,
	Debbra}';
BEGIN
	return names_arr[1+random()*(array_length(names_arr, 1)-1)];
END;
$$
LANGUAGE 'plpgsql';

-- GET RANDOM SURNAME
CREATE OR REPLACE FUNCTION RANDOM_SURNAME() 
RETURNS TEXT 
AS $$
DECLARE
  surnames_arr text[] := 
	'{﻿Dovecot,
Nymph,
Underbursar,
Unlathered,
Subclique,
Jetty,
Semihysterical,
Nontemptation,
Heliotyped,
Camorrism,
Unlubricating,
Nonnavigable,
Bayard,
Reequipping,
Aboveground,
Geraint,
Dissymmetrically,
Vinoba,
Unacceding,
Machineable,
Tetracyn,
Unscheduled,
Arctic,
Developed,
Corrector,
Cliffhanger,
Celeste,
Hypercheiria,
Zamboanga,
Preoutlining,
Etherizer,
Taiwan,
Explorable,
Mohels,
Newlon,
Flighter,
Gilsonite,
Intranuclear,
Punster,
Habbub,
Follicular,
Nondeceptive,
Tortiously,
Muriate,
Lazier,
Altigraph,
Softy,
Bolsheviks,
Thermoelectric,
Phantasmagoria,
Nematocystic,
Farterville,
Rexterous,
Grawnier,
Vedly,
Dargileh,
Iacchus,
Massimo,
Radiochemist,
Scopus,
Wainwright,
Lichenous,
Subtotem,
Sublimation,
Prebachelor,
Missending,
Lolland,
Uneschewed,
Zarf,
Reburying,
Couter,
Sensillum,
Unriveting,
Okie,
Canoness,
Tachycardia,
Hyalomere,
Oversimplify,
Eosine,
Preenlarging,
Townswoman,
Narmada,
Gasterocheires,
Furore,
Imploringness,
Europeanizing,
Ammunition,
Acrodrome,
Vaquero,
Galvanoscopic,
Augean,
Littb,
Corruptedly,
Cocoa,
Pseudoreformatory,
Unformidableness,
Invulnerability,
Anteorbital,
Brown,
Eagle}';
BEGIN
	return surnames_arr[1+random()*(array_length(surnames_arr, 1)-1)];
END;
$$
LANGUAGE 'plpgsql';

-- GET RANDOM NUMBER
CREATE OR REPLACE FUNCTION RANDOM_BETWEEN(low INT ,high INT) 
   RETURNS INT 
AS $$
BEGIN
   RETURN floor(random()* (high-low + 1) + low);
END;
$$ 
LANGUAGE 'plpgsql' STRICT;
-- ADD RANDOM BOOK
CREATE OR REPLACE FUNCTION ADD_RANDOM_BOOK(amount INT)
	RETURNS void
AS $$
DECLARE
	counter INT := 0;
	book_id INT := -1;
	author_id INT := -1;
	publishing_house_id INT := -1;
	country_id INT := -1;
	country_name TEXT := '';
	book_isbn TEXT := '';
BEGIN
	WHILE counter < amount LOOP
		-- generate book isbn
		book_isbn := concat(RANDOM_BETWEEN(100, 999), '-',
				    RANDOM_BETWEEN(100,999),  '-',
			            RANDOM_BETWEEN(10,99),    '-',
				    RANDOM_BETWEEN(1000,9999),'-', 
				    RANDOM_BETWEEN(1,9));

		
		-- insert book
		
		INSERT INTO "Books" 
		("isbn", "name", "year", "total amount", "amount to read home","amount to repair")
		VALUES(book_isbn, RANDOM_STRING(20),RANDOM_BETWEEN(1990, 2020) , RANDOM_BETWEEN(50, 60), RANDOM_BETWEEN(5, 6),RANDOM_BETWEEN(5, 6))
		RETURNING id INTO book_id;
		
		-- get country 		
		SELECT COUNT (*) INTO country_id FROM "country";

		country_id := RANDOM_BETWEEN(1, country_id);
		
		SELECT country INTO country_name FROM "country" 
		WHERE id = country_id;

		-- insert publishing house
		INSERT INTO "Publishing house" 
	        ("name", "country")
	        VALUES (RANDOM_STRING(20), country_name)
	        RETURNING id INTO publishing_house_id;

		-- link them
		INSERT INTO "BookPublishingHouse" ("isbn", "publishing house id")
		VALUES (book_isbn, publishing_house_id);

		-- insert author
		INSERT INTO "Authors"("name", "surname")
		VALUES (RANDOM_NAME(), RANDOM_SURNAME())
		RETURNING id INTO author_id;

		-- link them
		INSERT INTO "BookAuthor" ("isbn", "author id")
		VALUES (book_isbn, author_id);

		counter := counter + 1 ; 
	END LOOP;
END;
$$
LANGUAGE 'plpgsql';

select ADD_RANDOM_BOOK(4);

select count(*) from "Books";
