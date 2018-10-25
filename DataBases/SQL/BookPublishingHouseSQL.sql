-- DROP TABLE "BookPublishingHouse";

CREATE TABLE "BookPublishingHouse"
(
	"id" SERIAL PRIMARY KEY,
	"isbn" ISBN_DATA NOT NULL,
	"publishing house id" INTEGER NOT NULL,

	
	FOREIGN KEY ("isbn") 
	REFERENCES "Books" ("isbn") 
	ON DELETE CASCADE ON UPDATE CASCADE,
	
	FOREIGN KEY ("publishing house id") 
	REFERENCES "Publishing house" ("id")
	ON DELETE CASCADE ON UPDATE CASCADE
);


INSERT INTO "BookPublishingHouse" 
	("isbn", "publishing house id")
VALUES 	('978-666-14-6279-1', '1'),
	('952-966-14-2279-2', '3'),
	('932-966-14-6229-3', '4'),
	('978-122-14-3279-4', '2'),
	('978-965-18-6279-5', '2'),
	('978-966-13-6279-6', '2'),
	('968-996-14-6229-7', '1'),
	('968-966-14-4289-8', '2'),
	('968-966-14-4289-8', '3'),
	('968-966-14-4289-8', '4');

SELECT * FROM "BookPublishingHouse";
