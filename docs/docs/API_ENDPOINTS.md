# RaceDay RESTful API Endpoint Specification

## Events Endpoint
* `GET /api/events` - Retrieve all events
* `GET /api/events/{id}` - Retrieve event by ID
* `POST /api/events` - Create a new event
* `PUT /api/events/{id}` - Update existing event
* `DELETE /api/events/{id}` - Remove an event

## Categories Endpoint
* `GET /api/categories` - List event categories
* `POST /api/categories` - Add new category

## Enrolments Endpoint
* `POST /api/enrolments` - Register participant to an event category
* `GET /api/enrolments/participant/{id}` - Get participant enrolments
