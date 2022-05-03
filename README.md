Testning av API genom Postman:

1
GET https://localhost:44370/api/persons
2
GET https://localhost:44370/api/persons/hobbies/1
3
GET https://localhost:44370/api/persons/links/1
4
POST https://localhost:44370/api/personhobbies { "personId": 5, "person": null, "hobbyId": 2, "hobby": null }
5
POST https://localhost:44370/api/links { "url": "schack.se/", "personId": 2, "person": null, "hobbyId": 1, "hobby": null }
