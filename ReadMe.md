This Project is written in .NET CORE
The project was written in the following languages:
HTML
CSS
Javascript
JQuery
Ajax
C#
SQL
NLog

The project consists of a frontend, backend and database project.
The UI calls their respective contoller which then calls the Component class.
The Component class is used to call its respective dependencies such as the SQL Reposiotry.
Dapper is being used in the SQL Repository class.

For the Database project called dbPhonebook, it consists of two tables and two stored procedures.
tblEntry has an PhoneNumber column which is the primary key and a Name column which is a foreign key that has reference or relation to tblPhoneBook.
tblPhoneBook has a Name column which is its Primary Key.


