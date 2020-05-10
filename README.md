# Project Title
Team1 EventBrite

## Description:
This is a WebApplication, which allow users to discover popular local events happening around them and get tickets to events.</br>
It is Microservice Architecture based web application, running on Docker using Containers.

### Key Feature:
Browse popular local Events.</br>
Filter Events based on Type,Category,Location and Price.

### Components:
### 1. EventCatalogApi:</br>
Written in ASP.NET Core to render event picture and other information like event location, event time etc. 
### 2. WebMVC:</br>
MVC based design pattern, connects the front end to the backend Microservices.
### 3. TokenServiceApi:</br>
Service that identify the user by providing authentication token, who wish to access the cart,add items to the cart or checkout. 
### 4. Swagger:</br>
Implemeted Swagger to build REST API Documentation.
### 5.CartApi:</br>
Service that allow user to add item to the cart or update the existing item in the cart.
### 6.OrderApi:</br>
This service is being called when user make a payment and place their order.Integrating it with Stripe to process the payment.
### 7.Messaging:</br>
Rabbitmq message bus to communicate messages between Order Api and Cart Api.


# Contributors
Aijmal</br>
AyalewBinette</br>
Deepti</br>
Pooja</br>
Richa</br>
Saranya</br>

# Assignment 3c Video link:
https://www.youtube.com/watch?v=kZKZkwiMFns&feature=youtu.be

# Assignment 3b video link:
https://www.youtube.com/watch?v=P09spe2-3k4&feature=youtu.be </br>

# Assignment 3a Video link:
https://www.youtube.com/watch?v=tVFVrGEKxpw&feature=youtu.be










