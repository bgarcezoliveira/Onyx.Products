# Onyx.Products

## How to run

### Step 1. Configure Multiple Starter projects: 
- Onyx.Client
- Onyx.IDP
- Onyx.Products.API

### Step 2. Client should start and present the indentity openid dialog
- There are 2 preconfigured user accounts:
	- user1 / password123 -> configured as a 'publicuser' user
	- user2 / passowrd345 -> configuired as an 'admin' user
	
### Step 3. After successful authentication identity openid will return to the client the "access code" for the current user
INFO: The client interaction with the API wasn't fully integrated for this concept application

### Step 4. Copy the "access code" into postman to configure a get request to the available endpoints
- Postman requests should be configured as below:
	- GET https://localhost:7217/api/products					(Secured endpoint, only accessible by the Admin user - user2)
	- GET https://localhost:7217/api/products/color/{color}		(Secured endpoint, accessible by PublicUser and Admin - user1, user2)
	- GET https://localhost:7217/api/healthz					(Public health status endpoint)
	
	The access code should be pasted into the "Authorization" section for type "Bearer", for the secured endpoints


