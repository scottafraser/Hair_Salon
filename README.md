# Hair Salon Mgmt

#### Epicodus C# - Week 3 Independent Project

#### By Scott Fraser

## Exercise with Databases with C#
This is a program set to mimic a stylist/client management web app for employees of a hair salon.

## User Stories
1. As a salon employee, I need to be able to see a list of all our stylists.
1. As an employee, I need to be able to select a stylist, see their details, and see a list of all clients that belong to that stylist.
1. As an employee, I need to add new stylists to our system when they are hired.
1. As an employee, I need to be able to add new clients to a specific stylist. I should not 1. be able to add a client if no stylists have been added.


| Behavior	| INPUT	| OUTPUT |
| :----------:| :-----: | :-------:|
|User can input a stylist| type "Jessica" into form | Jessica displays on stylist list |
|User can input a client tied to a specific stylist from a dropdown menu| select: "Jessica", type "Rob" into form| Creates Rob, tied to Jessica as his stylist|
|If user enters nothing in either form, or doesn't select a stylist there is an error message | "" | "something went wrong" |
|The user can delete individual clients| remove "Rob"| Rob is removed from database|
|The user can delete all clients| click "remove all"| all clients are removed from database|
|The user can delete individual stylist, and corresponding clients are removed as well| remove "Jessica"| Jessica and Rob are removed from database|

## Setup/Contribution Requirements

1. Go to the repo in GitHub
1. Select Import Database tab and select the "scott_fraser" file
1. Clone the repo
1. Open Solutions folder in Visual Studio
1. Run the program on your local host
1. Enter a stylists
1. Enter a client
1. Enter another client
1. Remove a client
1. Terminate a stylists

## Database Setup for New Database

1. Using MySql in the command prompt;
1. In the command prompt> CREATE DATABASE Hair_Salon;
1. In the command prompt> USE Hair_Salon;
1. In the command prompt> CREATE TABLE clients (id serial PRIMARY KEY, name VARCHAR(255), stylist_id INT(11));
1. In the command prompt> CREATE TABLE stylist (id serial PRIMARY KEY, description VARCHAR(255));

## Technologies Used

* C# / .net
* Visual Studio
* Atom (for README)
* MySql
* MAMP
* phpAdmin

## Links

* https://github.com/scottafraser/Hair_Salon.git

## License

This software is licensed under the MIT license.

Copyright (c) 2018 **Scott Fraser**
