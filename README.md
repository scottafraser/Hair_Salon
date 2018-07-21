# Hair Salon Mgmt

#### Epicodus C# - Week 4 Independent Project

#### By Scott Fraser

## Exercise with Databases and Many to Many relationships with C#
This is a program set to mimic a stylist/client management web app for employees of a hair salon.

## User Stories
1. As a salon employee, I need to be able to see a list of all our stylists.
1. As an employee, I need to be able to select a stylist, see their details, and see a list of all clients that belong to that stylist.
1. As an employee, I need to add new stylists to our system when they are hired.
1. As an employee, I need to be able to add new clients to a specific stylist. I should not 1. be able to add a client if no stylists have been added.
1. As an employee, I need to be able to delete clients (all and single).
1. As an employee, I need to be able to view clients (all and single).
1. As an employee, I need to be able to edit the name of a stylist.
1. As an employee, I need to be able to edit ALL of the information for a client.
1. As an employee, I need to be able to add a specialty and view all specialties that have been added.
1. As an employee, I need to be able to add a specialty to a stylist.
1. As an employee, I need to be able to click on a specialty and see all of the stylists that have that specialty.
1. As an employee, I need to see the stylist's specialties on the stylist's details page.
1. As an employee, I need to be able to add a stylist to a specialty.


| Behavior	| INPUT	| OUTPUT |
| :----------:| :-----: | :-------:|
|User can input a stylist| type "Jessica" into form | Jessica displays on stylist list |
|User can input a client tied to a specific stylist from a dropdown menu| select: "Jessica", type "Rob" into form| Creates Rob, tied to Jessica as his stylist|
|If user enters nothing in either form, or doesn't select a stylist there is an error message | "" | "something went wrong" |
|The user can delete individual clients| remove "Rob"| Rob is removed from database|
|The user can delete all clients| click "remove all"| all clients are removed from database|
|The user can delete individual stylist, and corresponding clients are removed as well| remove "Jessica"| Jessica and Rob are removed from database|
|The user can edit information for clients and stylists| change "Jessica" to "Bob" | new name "Bob"|
|The user can create a specialty and associate it with a stylist | "Jessica, Beards" | Jessica's specialty is Beards|


## Setup/Contribution Requirements

1. Go to the repo in GitHub
1. Select Import Database tab and select the "scott_fraser" file
1. Clone the repo
1. Open Solutions folder in Visual Studio
1. Run the program on your local host


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
