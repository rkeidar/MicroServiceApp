Updating readme Running Mongo DB
==================
docker run --name mongodb -d -p 27017:27017 mongo

UserService : Port 5000

>>
docker-compose -f docker-compose.yml -f docker-compose.override.yml up -d

>> http://localhost:8000/swagger/index.html -> UserService
>> http://localhost:8001/swagger/index.html -> AlertService


Mongo:
- docker pull mongo
Redis:
- docker pull redis
