# Domain Models

## Menu

```csharp

class Menu
{
    Menu Create();
    void AddDinner(Dinner dinner);
    void RemoveDinner(Dinner dinner);
    void UpdateSection(MenuSection menuSection);
}
```

```json
{
    "id" : "000000-0000-0000-000000",
    "name":"Menu 1",
    "description" : "Menu 1 description",
    "hostId": "000000-0000-0000-000000",
    "averageRating" : 4.5,
    "sections": [
        "id" : "000000-0000-0000-000000",
        "name" : "Appetizer",
        "description" : "Appetizer served warm",
        "items" :[
            "id": "000000-0000-0000-000000",
            "name" : "Fried Pickles",
            "description" : "Deep Fried, Pickles",
            "price" : 5.99
        ]
    ],
    "createDateTime" : "2023-01-01T00:00:00.0000000Z",
    "updateDateTime" : "2023-01-01T00:00:00.0000000Z",
    "dinnerIds" : [
        "000000-0000-0000-000000",
        "000000-0000-0000-000000"
    ],
    "menuReviewIds":[
        "000000-0000-0000-000000",
        "000000-0000-0000-000000"
    ],

}
```