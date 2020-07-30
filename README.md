# _Best Restaurant_
Epicodus Week 10  
Version 1.0 - Date July 27th, 2020

## _Project Description_
Practice in many to one database relationships.

## _Contributors_
JohnNils Olson  
Micheal Hansen

## _Usage_
A website where users can add their favorite restaurants based on the type of cuisine they offer.

## _Behavior Specifications_
| Behavior | Input | Output |
| ---- | ---- | ---- |
| User can add cuisine types to database | "Ethiopian" | Type "Ethiopian" is stored in cuisines table |
| Program displays list of cuisine types | Link - "Cuisines" | List of all cuisine types from database |
| User can add restaurants to cuisine types | "Ethiopian" -> "Restaurant" | Restaurant "Restaurant" is stored in the restaurants table with the cuisineId of "Ethiopian |
| Program displays list of restaurants by cuisine type | Link - "Restaurants" | List of all restaurants from database |
| User can add details to restaurants | "Address", "Phone", "Website" | - |
| Program displays restaurant details | Link - "Details" | "Restaurant", "Ethiopian", "Address", "Phone", "Website" |
| User can search for a restuarant by name | "Restaurant" | List of all database entries with the name "Restaurant"
| User can search for a restaurant by cuisine | "Ethiopian | List of all database entries with the cuisine type "Ethiopian"
| User can add reviews to restaurants | "Good Food" | - |
| Program displays list of reviews on restaurant details page | Link - "Details" | List of all reviews matching the restaurant |


## _Technologies Used_
C#  
.NETCore  
Entity Framework Core  
MySql Server

## _Installation Instructions_
* Cloning instructions.
  1. Open Git Bash.
  2. Change the current working directory to the location where you would like to clone the repository.
  3. Type "git clone" followed by "(https://github.com/JohnNilsOlson/BestRestaurant.Solution)" (without quotes) and hit enter.
  4. Open directory with code editor of choice.
  5. In the terminal, change working directory to ./BestRestaurant.
  6. Type "dotnet restore".
  7. Type "dotnet run".

* Download instructions.
  1. Visit "https://github.com/JohnNilsOlson/BestRestaurant.Solution.git)".
  2. Click the green "code" button and download zip file of project.
  3. Extract zip file to directory of choice.
  4. Open project directory in code editor of choice.

* Instructions to run WebApp
  1. In the terminal, change working directory to ./BestRestaurant.
  2. Type "dotnet restore".
  3. Type "dotnet run".

## _Bugs_
No known issues.

## _Contact Information_
JohnNils Olson - johnnils@gmail.com  

## _License_
The [MIT] license.
Copyright (c) 2020 JohnNils Olson