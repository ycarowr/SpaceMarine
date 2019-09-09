# SpaceMarine

The repository contains the game ilustrated by the video below: 

![alt text](https://github.com/ycarowr/SpaceMarine/blob/master/Assets/Textures/spacemarine.gif)

## Game's Architecture:

Since there are a few things to cover I split it into four parts which I will talk separately:
1. The Scenes of the game;
2. The [MVC](https://en.wikipedia.org/wiki/Model%E2%80%93view%E2%80%93controller) of the game;
3. The entity system: player, enemies, doors, bullets and the game mechanics;
4. The initialization of the systems;
5. [Submodule](https://github.com/ycarowr/Tools) with Tools to speed up the implementation and make every thing more generic.


### Scenes
The game is separated in two different [scenes](https://github.com/ycarowr/SpaceMarine/tree/master/Assets/Scenes) that work idenpendenly: 
  1. __Opening__ - It contains a short introduction of the game, displaying a cut scene with a background, a spacecraft and text dialogs that receives input to go ahead and write the next piece of text. The scene ends with a dark screen fade which makes transition to the playable game. The scene is mostly driven by the script [OpenSceneSequence](https://github.com/ycarowr/SpaceMarine/blob/master/Assets/Scripts/Data/Sequences/Opening/OpeningSceneSequence.cs), which contains the instructions to move the spacecraft and show the text dialog.
  2. __Game__ - Contains the playable part of the game: monsters, player, doors, rooms and elevator are all here. 
  
### The MVC 
  
The [Model](https://github.com/ycarowr/SpaceMarine/tree/master/Assets/Scripts/Model) and [UI/View](https://github.com/ycarowr/SpaceMarine/tree/master/Assets/Scripts/Ui) communication is done using the following [interfaces/Events](https://github.com/ycarowr/SpaceMarine/blob/master/Assets/Scripts/GameEvents/GameEvent.cs) and the [Observer Pattern](https://github.com/ycarowr/Tools/blob/3be2788408fd80bcd3c4a849bb0a7161230d944a/Patterns/Observer/Observer.cs) which allows to remove dependencies/coupling between both layers of the application. In shorter words, the UI scripts implement an interface and subscribe the events they are interested into, the Model classes dispatch those events when they happen.

Most of the simple elements of the UI inherit from [UiGameEventListener](https://github.com/ycarowr/Tools/blob/3be2788408fd80bcd3c4a849bb0a7161230d944a/Patterns/GameEvents/UiGameEventListener.cs) and are attached to the observer automatically, however more complex entities that have their own base class perform their own subscription, such as [UiRoom](https://github.com/ycarowr/SpaceMarine/blob/master/Assets/Scripts/Ui/Entities/Rooms/UiRoom.cs). 

As the [Observer](https://github.com/ycarowr/Tools/blob/3be2788408fd80bcd3c4a849bb0a7161230d944a/Patterns/Observer/Observer.cs) code shows, once a listener subscribes the event register, all its events/interfaces are now ready to be notified by the game model.

At the bottom of the class [Door](https://github.com/ycarowr/SpaceMarine/blob/master/Assets/Scripts/Model/Mechanics/Door.cs) we have an example of the model code notifying the events that handle the door damage and destruction, _OnTakeDamage()_ and _Destroy()_ methods respectively.
  
### The Entity System
  
  //TODO
  
### The Mechanics
  
  //TODO
  
### The Initialization
  
  //TODO
  
Assets by: http://pixelgameart.org/web/

