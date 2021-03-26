# Battleships
One way Battleships game in console and written in c#.

# Technologies
Following technologies were used and should be installed before compiling the app
* .NET 5 SDK
* Visual Studio 2019 or Rider 2020.3
* NUnit 3.13 for testing

# Setup
### From command line
To run the code you need to execute following commands from the command line in the root folder of cloned project
```
dotnet resotore
dotnet build
dotnet run --project Battleships.App
```

### From Visual Studio
After cloning the project onto your computer:
1. Open Battleships.snl from Visual Studio

![open-project](https://user-images.githubusercontent.com/15459502/112653238-82eb8b00-8e4e-11eb-9657-4eccbc61cf40.png)

2. Right click on solution in solution explorer and chose Restore nuget packages option

![restore-packages](https://user-images.githubusercontent.com/15459502/112652277-8599b080-8e4d-11eb-9957-d492e89df0b4.png)

3. After restoring packages completes, compile and run the app using green arrow in the toolbar. Make sure that the proper starting project is chosen to the left of the arrow

![compile-and-run](https://user-images.githubusercontent.com/15459502/112652642-e75a1a80-8e4d-11eb-9852-f150ba532233.png)

# Testing
To run tests enter command below into terminal from root folder of solution
```
dotnet test
```
or from Visual Studio

![testing](https://user-images.githubusercontent.com/15459502/112659541-c9dc7f00-8e54-11eb-88c0-3fcde43097a3.png)

# Notes
* Code in a master branch is a code made specifically to spec from this [article](https://medium.com/guestline-labs/hints-for-our-interview-process-and-code-test-ae647325f400). Because of the there is no support for resizable map and the user has no ability to chose the amount of ships that will spawn. To keep it simple some of the methods are hard coded, for example the method to draw a board with coordiantes. I made another version of the app that gives the user ability to resize the map and chose the amount of ships that he wants to spawn. Code for this version is available in "resizableMap" branch.

* I tried to keep the code simple and not overly fragmented. Because of that there are no Battleship and Destroyer classes that inherit from base Ship class. But doing so in the future shouldn't be overly hard, because I tried to keep in mind the ability to extend the code.

