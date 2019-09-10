# SpaceMarine and why I made it.

The repository contains the game illustrated by the video below, the assets are free and come from [PixelGameArt](http://pixelgameart.org/web/)

![alt text](https://github.com/ycarowr/SpaceMarine/blob/master/Assets/Textures/spacemarine.gif)

My main goal when I first started this game was to make a 2d-platformer with a decent code architecture, which I would be able to reuse code in the future or extend to a "real project". 

By no means I wanna say every real project has to have a perfect architecture or be completely extendable, I believe every project has it's purpose in life and by the time I started this one I wanted to make it as much maintainable, manageable and clean as possible. 100% doable!

I wanted as well to apply the [design patterns](https://github.com/ycarowr/Unity-Design-Pattern) appropriated to the problems I would have during the development. Because its super easy to do, they are very well documented everywhere! 

All of it respecting perfectly the [SOLID](https://en.wikipedia.org/wiki/SOLID) principles of [OOP](https://en.wikipedia.org/wiki/Object-oriented_programming).

As you can tell this point, as I progressed with it over time, I've found more things to do in my life and I believe I couldn't keep the same excitement as I had at the beginning. The project definitely doesn't have the "best ofs", but in my point of view its good enough to be maintainable and extendable, the code is also clean and organized, I have implemented a few patterns but not all, I tried to respect SOLID as much as possible but for sure someone can find mistakes here and there. 

Here you can also count the fact that this is a project done in a few months during my free time at the weekends, early mornings or evenings after work 8h. And no hopes to make money with it. All for learning purposes.

## The Game's Architecture:

Since there are a few things to cover I split it into four parts which I will talk separately:
1. The Scenes of the game;
2. The [MVC](https://en.wikipedia.org/wiki/Model%E2%80%93view%E2%80%93controller) of the game;
3. The entity system: player, enemies, doors, bullets and game mechanics;
4. The initialization of the systems;
5. [Submodule](https://github.com/ycarowr/Tools) with Tools to speed up the implementation and make everything more generic.


### Scenes
The game is separated into two different [scenes](https://github.com/ycarowr/SpaceMarine/tree/master/Assets/Scenes) that work indenpendenly: 
  1. __Opening__ - It contains a short introduction of the game, displaying a cut scene with a background, a spacecraft and text dialogs that receives input to go ahead and write the next piece of text. The scene ends with a dark screen fade which makes the transition to the playable game. The scene is mostly driven by the script [OpenSceneSequence](https://github.com/ycarowr/SpaceMarine/blob/master/Assets/Scripts/Data/Sequences/Opening/OpeningSceneSequence.cs), which contains the instructions to move the spacecraft and show the text dialog.
  2. __Game__ - Contains the playable part of the game: monsters, player, doors, rooms and elevator are all here. 
  
### The MVC and Communication between Model and View

I won't be able to get into what is a [MVC](https://en.wikipedia.org/wiki/Model%E2%80%93view%E2%80%93controller) here, there is a ton of content regarding this subject online, it for sure won't be difficult to find information.
  
The [Model](https://github.com/ycarowr/SpaceMarine/tree/master/Assets/Scripts/Model) and [UI/View](https://github.com/ycarowr/SpaceMarine/tree/master/Assets/Scripts/Ui) communication is done using the following [interfaces/Events](https://github.com/ycarowr/SpaceMarine/blob/master/Assets/Scripts/GameEvents/GameEvent.cs) and the [Observer Pattern](https://github.com/ycarowr/Tools/blob/3be2788408fd80bcd3c4a849bb0a7161230d944a/Patterns/Observer/Observer.cs) which allows to remove the [coupling](https://en.wikipedia.org/wiki/Coupling_(computer_programming)) between these layers of the application. In shorter words, the UI scripts implement an interface and subscribe to the events they are interested in, the Model classes dispatch those events when they happen.

As the [Observer](https://github.com/ycarowr/Tools/blob/3be2788408fd80bcd3c4a849bb0a7161230d944a/Patterns/Observer/Observer.cs) code shows, once a listener subscribes the event register, all its events/interfaces are now ready to be notified by the game model.

Quick examples: 

1. Most of the simple elements of the UI inherit from [UiGameEventListener](https://github.com/ycarowr/Tools/blob/3be2788408fd80bcd3c4a849bb0a7161230d944a/Patterns/GameEvents/UiGameEventListener.cs) and are attached to the observer after the _Start()_ engine callback. However, more complex entities that have their base class perform their subscription, such as [UiRoom](https://github.com/ycarowr/SpaceMarine/blob/master/Assets/Scripts/Ui/Entities/Rooms/UiRoom.cs). 

2. At the bottom of the class [Door](https://github.com/ycarowr/SpaceMarine/blob/master/Assets/Scripts/Model/Mechanics/Door.cs) we have an example of the model code notifying the events that handle the door damage and destruction, _OnTakeDamage()_ and _Destroy()_ methods respectively.
  
### The Entity System
  
  //TODO
  
### The Mechanics
  
  //TODO
  
### The Initialization
  
  //TODO
  

