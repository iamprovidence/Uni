DROP INDEX AuthorsName;

DROP INDEX BookName;

DROP INDEX BookAuthorIndex;

DROP INDEX ReaderIndex;

DROP INDEX AbonnementIndex;

CREATE INDEX AuthorsName
ON "Authors" ("name", "surname");

CREATE INDEX BookName
ON "Books" ("name");

CREATE INDEX BookAuthorIndex
ON "BookAuthor" ("isbn","author id");

CREATE INDEX ReaderIndex
ON "Readers" ("name","code");

CREATE INDEX AbonnementIndex
ON "Abonnement" ("reader code");

EXPLAIN SELECT "reader code" FROM "Abonnement";