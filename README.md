# Rocket_Rest_API

<!-- ABOUT THE PROJECT -->
## About The Project

Rocket Elevators Rest API is the 6th project for the Odyssey 14 weeks program in CodeBoxx. 

By the 5th week We have added APIs using Ruby on Rails to the website created in the Genesis Program. 

website used: [rocketelevators-jt.com/](http://rocketelevators-jt.com/)

##

For the 6th week, we have created a rest API with 9 endpoints and a graphql API. They are both deployed on Microsoft Azure.

<br>

##  Required Rest API endpoints exemples

- Retrieving the current status of a specific Battery
  > https://rocketelevatorsapi.azurewebsites.net/api/batteries/1/status
 
- Changing the status of a specific Battery
  > https://rocketelevatorsapi.azurewebsites.net/api/batteries/update/1/online

- Retrieving the current status of a specific Column
  > https://rocketelevatorsapi.azurewebsites.net/api/columns/1/status

- Changing the status of a specific Column
  > https://rocketelevatorsapi.azurewebsites.net/api/columns/update/1/online

- Retrieving the current status of a specific Elevator
  > https://rocketelevatorsapi.azurewebsites.net/api/elevators/1/status

- Changing the status of a specific Elevator
  > https://rocketelevatorsapi.azurewebsites.net/api/elevators/update/1/online

- Retrieving a list of Elevators that are not in operation at the time of the request
  > https://rocketelevatorsapi.azurewebsites.net/api/elevators/offline

- Retrieving a list of Buildings that contain at least one battery, column or elevator requiring intervention
  > https://rocketelevatorsapi.azurewebsites.net/api/buildings

- Retrieving a list of Leads created in the last 30 days who have not yet become customers
  > https://rocketelevatorsapi.azurewebsites.net/api/leads


## Addtional Rest API endpoints

- Get all leads
    > https://rocketelevatorsapi.azurewebsites.net/api/leads/all
- Get all customers
    > https://rocketelevatorsapi.azurewebsites.net/api/customers/all
- Get all elevators
    > https://rocketelevatorsapi.azurewebsites.net/api/elevators/all
- Get all columns
    > https://rocketelevatorsapi.azurewebsites.net/api/columns/all
- Get all batteries
    > https://rocketelevatorsapi.azurewebsites.net/api/batteries/all
- Get all builddings
    > https://rocketelevatorsapi.azurewebsites.net/api/buildings/all

- Get lead by id
    > https://rocketelevatorsapi.azurewebsites.net/api/leads/1
- Get customer by id
    > https://rocketelevatorsapi.azurewebsites.net/api/customers/1
- Get elevator by id
    > https://rocketelevatorsapi.azurewebsites.net/api/elevators/1
- Get column by id
    > https://rocketelevatorsapi.azurewebsites.net/api/columns/1
- Get battery by id
    > https://rocketelevatorsapi.azurewebsites.net/api/batteries/1
- Get all building by id
    > https://rocketelevatorsapi.azurewebsites.net/api/buildings/1


CONSOLIDATION END POINTS


- Get Pending Interventions
    > https://rocketelevatorsapi.azurewebsites.net/api/interventions
- Put To inProgress
    > https://rocketelevatorsapi.azurewebsites.net/api/interventions/1/inprogress
- Put to Completed
    > https://rocketelevatorsapi.azurewebsites.net/api/interventions/1/completed


## Contributors

- **[Ted Lemy](https://github.com/lemyted)**
- **[Alex Wallot](https://github.com/AlexWallot)**
- **[Luka Trudel](https://github.com/LukaTrudel)**
- **[Rafik Hoceini](https://github.com/rafikhoceini)**
- **[Armughan Ayaz Janjua](https://github.com/armughanayaz)**




