# SQLQueryCreator - Coding Assignment

Instructions
· Please ensure that you have installed Visual Studio or another IDE on your computer before embarking on this assignment.
· You may take a maximum of 16-20 hour to complete this assignment.
· Create object-oriented, scalable, loosely-coupled code and try to look for opportunities to reuse code.
· Use Design patterns wherever appropriate.
· Use the best industry practices for commenting, code layout, coding style and naming of objects, members and methods.
· Please provide your solutions as C#/Java code.
· A simple console application will suffice, with simple unit test cases.
· Please share the completed solutions via GitHub(rajeshvinaygam-lab) also share us the JSON file that you had created during this assignment.

Problem 1: Create a SQL query supporting various operators ( IN, LIKE, =, <=, >= , <>, BETWEEN etc)
Assume the application you write can have a JSON in the below format to parse and create the expression( the JSON Schema provided here is just a reference, you can come up with your own schema to accommodate various use cases)
{"columns":[{"operator":"IN","fieldName":"column1","fieldValue":"value"},{"operator":"Equal","fieldName":"column2","fieldValue":"value"}}
As part of your assignment, please write C#/Java code to implement the following functionalities: -
· Read the JSON file.
· Create an SQL QUERY as an output.

Problem 2: Extend the program further to support querying from multiple tables i.e., add support for sub-query or joins in the query builder
The idea of this problem should be to provide a generic solution to build SQL Query supporting any number of tables.
