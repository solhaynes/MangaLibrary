#Manga Library

##Purpose

The goal of this project is to create a website where a user can add to and search through a 
library of manga series and the books within them.  Within this library are tables for Book, Series,
Author, and Genre entities.  The relationships between these tables can be seen in the link to the db diagram below:

https://dbdiagram.io/d/Manga-Library-66aae0438b4bb5230ee76a42 

##Tables

**Book**
- Id (int) (pk)
- SeriesId (string) (fk)
- Volume (int)
- Chapters (string)
- ReleaseDate (DateTime)
- ImageLink (string)

**Series**
- Id (int) (pk)
- Title (string)
- AuthorId (int) (fk)
- GenreId (int) (fk)
- Description (string)
- ImageLink (string)

**Author**
- Id (int) (pk)
- Name (string)
- DateOfBirth (DateTime)
- ImageLink (string)

**Genre**
- Id (int)(pk)
- Name (string)
- Description (string)

##MVP

The MVP needs to be able to Create, Read, Update, and Delete from each table.  This goal was achieved. The CRUD functions
are something I'd prefer to only be available for users with Admin access. The average user shouldn't be able to add, update, or
delete from the database.  

Link to Trello Board: https://trello.com/b/1nDbPpz0/final-project
