# sql-random-insert-generator

## Creators
[David Steven Montoya](https://github.com/DSMontoyaP/) - [Marco Fidel Vásquez](https://github.com/MarcoFidelVasquezRivera/)

## General Info
The aim of this project is to create a tool that helps an user to convert a .csv file into a randomized "INSERTS.sql" archive,
which will help the user quickly add information to a previously created Oracle SQL Developer database based on an exercise.

## Programming Language Used
C#

## Usage

The first step is to localize the .csv file that comes with the download of this repository, it will be on "./sql-random-insert-generator/data/datos.csv" folder.

![imagen](https://user-images.githubusercontent.com/55026204/116793224-19811c80-aa8b-11eb-86ec-5530cf2efe74.png)

You will need to copy the absolute path of this location and paste it on the code "path" variable.

![imagen](https://user-images.githubusercontent.com/55026204/116793529-e049ac00-aa8c-11eb-9ff8-1436c6048e10.png)


Finally, when you run the code it will create an "INSERTS.sql" looking like this:

![imagen](https://user-images.githubusercontent.com/55026204/116793376-18042400-aa8c-11eb-8435-597fd3f5a154.png)

Which will work to add new info into the sql.

## Extra
If you want to add more information to the .csv keep in mind the separation of each column, for example, if you want to add a new address you
will need to leave department,fName,lName and position empty such as:

(;;;;"WallStreet lower")
