HTTP Method	Route	Description	Role Required	Request Body	Expected Response
POST	/api/auth/register	Registers a new user account as either Organiser or Participant.	None (Public)	{ "fullName", "email", "password", "role" }	201 Created with user object / 400 Bad Request
POST	/api/auth/login	Authenticates user credentials and issues JWT token.	None (Public)	{ "email", "password" }	200 OK with JWT token / 401 Unauthorized
GET	/api/users/profile	Retrieves current logged-in user's profile details.	Organiser, Participant	None	200 OK with profile object / 401 Unauthorized
PUT	/api/users/profile	Updates current logged-in user's profile information.	Organiser, Participant	{ "fullName", "email" }	200 OK with updated profile / 400 Bad Request
GET	/api/events	Retrieves all upcoming sports events.	None (Public)	None	200 OK with event array
GET	/api/events/{id}	Retrieves full details for a single event.	None (Public)	None	200 OK with event object / 404 Not Found
POST	/api/events	Creates a new event with name, description, date, location, distance, and event type.	Organiser	{ "name", "description", "eventDate", "location", "distanceKm", "eventType" }	201 Created with event details / 403 Forbidden
PUT	/api/events/{id}	Updates an existing event's details.	Organiser	{ "name", "description", "eventDate", "location", "distanceKm", "eventType" }	200 OK / 404 Not Found
DELETE	/api/events/{id}	Deletes an event from the system.	Organiser	None	200 OK / 404 Not Found
GET	/api/events/{eventId}/categories	Retrieves all age/distance categories for a specific event.	None (Public)	None	200 OK with categories array
POST	/api/events/{eventId}/categories	Defines a new age or distance category for an event.	Organiser	{ "categoryName", "distanceKm", "entryFee" }	201 Created / 400 Bad Request
POST	/api/enrolments	Enrols a Participant into an event by selecting a category.	Participant	{ "eventId", "categoryId" }	201 Created / 409 Conflict (Already enrolled)
GET	/api/enrolments/my-enrolments	Retrieves all event enrolments for the logged-in Participant.	Participant	None	200 OK with enrolment array
GET	/api/events/{eventId}/enrolments	View all participant enrolments for an event.	Organiser	None	200 OK with enrolment array / 403 Forbidden
POST	/api/results	Captures finish time and finishing positions for a participant.	Organiser	{ "enrolmentId", "finishTime", "overallPosition", "categoryPosition" }	201 Created / 400 Bad Request
GET	/api/results/my-results	Retrieves performance and result history for the logged-in Participant.	Participant	None	200 OK with result array

