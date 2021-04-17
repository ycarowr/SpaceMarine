[![Unity Version](https://img.shields.io/badge/Unity-2019.1.12f1%2B-blue.svg)](https://unity3d.com/get-unity/download)
[![Twitter](https://img.shields.io/twitter/follow/ycarowr.svg?label=Follow@ycarowr&style=social)](https://twitter.com/intent/follow?screen_name=ycarowr)

# Space Marine Project.
The repository contains the game illustrated gifs below, the assets are free and can be found on [PixelGameArt](http://pixelgameart.org/web/). 

![alt text](https://github.com/ycarowr/SpaceMarine/blob/master/Assets/Textures/door.gif)
![alt text](https://github.com/ycarowr/SpaceMarine/blob/master/Assets/Textures/elevator.gif)
![alt text](https://github.com/ycarowr/SpaceMarine/blob/master/Assets/Textures/level2.gif)
![alt text](https://github.com/ycarowr/SpaceMarine/blob/master/Assets/Textures/level3.gif)
![alt text](https://github.com/ycarowr/SpaceMarine/blob/master/Assets/Textures/robot.gif)
![alt text](https://github.com/ycarowr/SpaceMarine/blob/master/Assets/Textures/spacecraft.gif)
![alt text](https://github.com/ycarowr/SpaceMarine/blob/master/Assets/Textures/terminal.gif)

My main goal when I first started this game was to make a 2d-platformer with a decent code architecture, something which I would be able to reuse code in the future or extend to a "real project". By no means, I wanna say a real project has to have a perfect architecture or be completely extendable. I believe every project has its purpose and by the time I started this one I wanted to make it as much maintainable, manageable and clean as possible. Something 100% doable!

I wanted as well to apply the appropriated [design patterns](https://github.com/ycarowr/Unity-Design-Pattern) to the common problems I would have during the development. Because its super easy to do, they are very well documented everywhere! 

All of it respecting perfectly the [SOLID](https://en.wikipedia.org/wiki/SOLID) principles of [OOP](https://en.wikipedia.org/wiki/Object-oriented_programming) and maybe doing some TDD too ...

As you can tell this point, as I progressed over time, I've found more things to do in my life and I couldn't keep the same excitement as I had at the beginning. The project definitely doesn't have the "best ofs", but in my point of view its good enough to be maintainable and extendable, the code is also clean and well organized, I have implemented a few patterns for common problems and I tried to respect SOLID as much as possible, but for sure someone can find mistakes here and there. In my defense, a few facts have to be taken into account, this is a project done in a few months during my free time on the weekends, early mornings or evenings after working 8h and with no hopes to make money from it.

A final note, the game is still unfinished, there is plenty of stuff that can be done regarding the behaviors or the enemies, guns, upgrades, achievements, craft system, audio and all the game design stuff that demands a lot of tweaks and is time consuming. Feel free to make pull requests and contribute. I eventually will make some progress on my own, but don't expect a release date.

With that being said, let's get into it.

## The Game's Architecture Overview:
Since there are a few things to cover I split it into different parts which I will talk separately:
1. The [Scenes](https://github.com/ycarowr/SpaceMarine/tree/master/Assets/Scenes) of the game;
2. The [MVC](https://en.wikipedia.org/wiki/Model%E2%80%93view%E2%80%93controller) of the game;
3. The entity system: player, enemies, doors, bullets and game mechanics;
4. The initialization of the systems and the static data;

### Scenes
The game is separated into two different [scenes](https://github.com/ycarowr/SpaceMarine/tree/master/Assets/Scenes) that work independently: 
  1. __Opening__ - It contains a short introduction of the game, displays a cut scene with a background, a spacecraft and text dialogs that receive input to go ahead and write the next sentence. The presentation ends with a dark screen fade which makes the transition to the playable part of the game. The scene is mostly driven by the script [OpenSceneSequence](https://github.com/ycarowr/SpaceMarine/blob/master/Assets/Scripts/Data/Sequences/Opening/OpeningSceneSequence.cs), which contains the instructions to move the spacecraft and show the text dialog.
  2. __Game__ - Contains the playable part of the game: monsters, player, doors, rooms and elevator are all here. 
  
### The MVC and Communication between Model and View
  
The [Model](https://github.com/ycarowr/SpaceMarine/tree/master/Assets/Scripts/Model) is mostly driven by a pure C# class named [Game](https://github.com/ycarowr/SpaceMarine/blob/master/Assets/Scripts/Model/Game.cs) and the implementation follows the [component pattern](https://github.com/QianMo/Unity-Design-Pattern/blob/master/Assets/Game%20Programming%20Patterns/Component%20Pattern/Example/ComponentPatternExample.cs) splitting all the [game mechanics](https://github.com/ycarowr/SpaceMarine/tree/master/Assets/Scripts/Model/Mechanics) into smaller classes and injecting their dependencies through the constructor.

The [UI](https://github.com/ycarowr/SpaceMarine/tree/master/Assets/Scripts/Ui) elements that in someways interact with the player inherit from these two [base classes](https://github.com/ycarowr/SpaceMarine/tree/master/Assets/Scripts/Ui/Entities/Base), the first always interact with the player and the second has states and can be switched on, off or inactive.
  
The Model and UI communication is done using the following [Interfaces/Events](https://github.com/ycarowr/SpaceMarine/blob/master/Assets/Scripts/GameEvents/GameEvent.cs) and the [Observer Pattern](https://github.com/ycarowr/Tools/blob/3be2788408fd80bcd3c4a849bb0a7161230d944a/Patterns/Observer/Observer.cs) which allows to remove the [coupling](https://en.wikipedia.org/wiki/Coupling_(computer_programming)) between both layers of the application. In shorter words, the UI scripts implement an interface and subscribe to the events they are interested in, and the Model classes dispatch those events when they happen.

As the [Observer](https://github.com/ycarowr/Tools/blob/3be2788408fd80bcd3c4a849bb0a7161230d944a/Patterns/Observer/Observer.cs) code shows, once a listener subscribes the event register, all its events/interfaces are now ready to be notified by the game model.

Quick examples: 

1. Most of the simple elements of the UI inherit from [UiGameEventListener](https://github.com/ycarowr/Tools/blob/3be2788408fd80bcd3c4a849bb0a7161230d944a/Patterns/GameEvents/UiGameEventListener.cs) and subscribe to the observer after the _Start()_ engine callback. However, more complex entities that have their own base class and perform their own subscription, such as [UiRoom](https://github.com/ycarowr/SpaceMarine/blob/master/Assets/Scripts/Ui/Entities/Rooms/UiRoom.cs). 

2. At the bottom of the class [Door](https://github.com/ycarowr/SpaceMarine/blob/master/Assets/Scripts/Model/Entities/Door.cs) we have an example of the model code notifying the events that handle the door damage and destruction, _OnTakeDamage()_ and _Destroy()_ methods respectively.
  
### The Game Entities

Inside the model, enemies inherit from the base class [RuntimeEnemy](https://github.com/ycarowr/SpaceMarine/blob/master/Assets/Scripts/Model/Entities/Enemies/RuntimeEnemy.cs) conceiving the [Subclass Sandbox Pattern](https://gameprogrammingpatterns.com/subclass-sandbox.html). Doors and Enemies can be shot, in that way, both implement [IAttackable](https://github.com/ycarowr/SpaceMarine/blob/master/Assets/Scripts/Model/Interfaces.cs) interface. Rooms are populated with doors and enemies during the initialization, then events are emitted to instantiate the views of these entities which are [Prefabs](https://github.com/ycarowr/SpaceMarine/tree/master/Assets/Prefabs/Ui) kept by an [Object Pool](https://gameprogrammingpatterns.com/object-pool.html) where the code can be found [here](https://github.com/ycarowr/Tools/tree/3be2788408fd80bcd3c4a849bb0a7161230d944a/Patterns/GenericPrefabPooler).

In order to use some gizmos and make the placing of the objects in the world easier all the UI of the rooms are already in the scene with their own IDs set when the editor starts, with that and reading the static [Data](https://github.com/ycarowr/SpaceMarine/blob/master/Assets/Scripts/Data/Room/RoomData.cs) used to initialize each room the gizmos elements appear in the scene according to each door, enemy, floor, position of the camera and walls present in the UIRoom. See picture below.

![alt text](https://github.com/ycarowr/SpaceMarine/blob/master/Assets/Textures/img_gizmos.png) 

Although I didn't tweak values of the jump, movement and gun, The [player UI](https://github.com/ycarowr/SpaceMarine/tree/master/Assets/Scripts/Ui/Player) is mostly done but not all the enemies are implemented, I stopped the work on the [Bipedal UI](https://github.com/ycarowr/SpaceMarine/tree/master/Assets/Scripts/Ui/Entities/Enemies/Bipedal) behaviors and other [four enemies](https://github.com/ycarowr/SpaceMarine/tree/master/Assets/Scripts/Ui/Entities/Enemies) still have to be done. 
  
### The Initialization

Besides the internal initialization of each Monobehavior done on the _Awake()_ method, the main initialization is done by the __GameController__ instance placed in the scene, see below:

![alt text](https://github.com/ycarowr/SpaceMarine/blob/master/Assets/Textures/gamecontroller.JPG)

The script [GameData](https://github.com/ycarowr/SpaceMarine/blob/master/Assets/Scripts/GameController/GameData.cs) receives the unity callback _Start()_, then creates an instance of the game model and broadcasts the game event _ICreateGame_.
  
The [GameController](https://github.com/ycarowr/SpaceMarine/blob/master/Assets/Scripts/GameController/GameController.cs) script receives the _ICreateGame_ event and then starts the game properly.

To initialize most of the game entities some external information is needed, this data means different things for different entities, they could be the position where a enemy would be placed, the total health, an ids or all the enemies inside the room. All these [meta data](https://github.com/ycarowr/SpaceMarine/tree/master/Assets/Scripts/Data) about an object is stored into a specific scriptable object which is shared across all the entities of that type, as the constructor of the class [enemy](https://github.com/ycarowr/SpaceMarine/blob/master/Assets/Scripts/Model/Entities/Enemies/RuntimeEnemy.cs) illustrates, the data is a dependency injected during the creation of the object.

A playable version is available [here](https://ycarowr.itch.io/space-marine).

See you space cowboy
  

