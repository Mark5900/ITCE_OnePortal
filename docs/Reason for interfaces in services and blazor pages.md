# Reason for interfaces in services and blazor pages
Through out the app will you see that we use the interface instead of the classes wtih all the code. Example we use `ISkoleData`instead of `SkoleData`.

## Reason
Not in all casses but in some we will encounter the following error:
```
/workspaces/ITCE_OnePortal/OnePortal/Components/Pages/SkoleDataCreate.razor(60,19): error CS1061: 'SkoleData' does not contain a definition for 'InsertSkoleData' and no accessible extension method 'InsertSkoleData' accepting a first argument of type 'SkoleData' could be found (are you missing a using directive or an assembly reference?) [/workspaces/ITCE_OnePortal/OnePortal/OnePortal.csproj]
/workspaces/ITCE_OnePortal/OnePortal/Components/Pages/SkoleData.razor(75,30): error CS1061: 'SkoleData' does not contain a definition for 'GetSkoleData' and no accessible extension method 'GetSkoleData' accepting a first argument of type 'SkoleData' could be found (are you missing a using directive or an assembly reference?) [/workspaces/ITCE_OnePortal/OnePortal/OnePortal.csproj]
```
The methode `InsertSkoleData`and `GetSkoleData` does exist but for some reason the code fails because it can't see these methodes.

## Where to insert the interfaces 
### DataAccessLibrarry
Create the interface in the folder `Interfaces`and use it on the class in the root folder. Example `.\SkoleData.cs` and the interface is `.\Interfaces\ISkoleData.cs`

### Oneportal
Add the DB connection as a service in `Program.cs` example:
```c3
builder.Services.AddTransient<ISkoleData, SkoleData>();
```

Use the service on a page like so:
```c#
@inject ISkoleData _db
```