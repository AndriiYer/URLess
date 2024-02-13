# URL Shortener REST service called URLess
- URLs are shortened to 6 BASE64 symbols: http://urle.ss/aBc9D- 
- Single endpoint "/"

## GET /AbCdE1
- Returns 301(Moved Permanently) if URL exists. Header Location must contain a URL to redirect to 
- Returns 404 if does not exists 
## POST /
JSON in the body with a single field "url" that contains a URL to short 
Returns 201 Created and JSON of a created entity with "url" field that contains a shortened URL and "originalURL" 
Multiple POST with the same URL must return different shortened URLs. E.g. 3 POST with https://nice.com should return 3 different shortened URLs – http://urle.ss/AvCfA1, http://urle.ss/Jke12a, http://urle.ss/PoP123 

## Implementation notes: 
- Started with REST tests(e.g. WebApplicationFactory for C#) 
- For shortening next alg is used: 
- Take a URL and make SHA1 hash of it with transform string to byte array first 
- Transform hash to BASE64 
- Take the first 6 symbols of it 
- In case of collision, change a random byte in the byte array obtained from the URL string, then do hashing and BASE64. Repeat until we get a unique ID 
