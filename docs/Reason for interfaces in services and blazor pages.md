# Reasons for Using Interfaces in Services and Blazor Pages

Throughout the app, you will see that we use interfaces instead of the classes with all the code. For example, we use `ISkoleData` instead of `SkoleData`.

## Reason
Not in all cases, but in some, we will encounter the following error:
```
/workspaces/ITCE_OnePortal/OnePortal/Components/Pages/SkoleDataCreate.razor(60,19): error CS1061: 'SkoleData' does not contain a definition for 'InsertSkoleData' and no accessible extension method 'InsertSkoleData' accepting a first argument of type 'SkoleData' could be found (are you missing a using directive or an assembly reference?) [/workspaces/ITCE_OnePortal/OnePortal/OnePortal.csproj]
/workspaces/ITCE_OnePortal/OnePortal/Components/Pages/SkoleData.razor(75,30): error CS1061: 'SkoleData' does not contain a definition for 'GetSkoleData' and no accessible extension method 'GetSkoleData' accepting a first argument of type 'SkoleData' could be found (are you missing a using directive or an assembly reference?) [/workspaces/ITCE_OnePortal/OnePortal/OnePortal.csproj]
```
The methods `InsertSkoleData` and `GetSkoleData` do exist but for some reason, the code fails because it can't see these methods.

## Where to Insert the Interfaces 
### DataAccessLibrary
Create the interface in the folder `Interfaces` and use it on the class in the root folder. For example, `.\SkoleData.cs` and the interface is `.\Interfaces\ISkoleData.cs`.

### OnePortal
Add the DB connection as a service in `Program.cs`. Example:
```c#
builder.Services.AddTransient<ISkoleData, SkoleData>();
```

Use the service on a page like so:
```c#
@inject ISkoleData _db
```