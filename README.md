# SpaceMarine

As shown in the following video, the repository contains a platformer in the Space.

![alt text](https://github.com/ycarowr/SpaceMarine/blob/master/Assets/Textures/spacemarine.gif)

About the game's architecture:

The game is separated in two different [scenes](https://github.com/ycarowr/SpaceMarine/tree/master/Assets/Scenes): 
  1. Opening - It contains a short introduction of the game, displaying a cut scene with a background, a spacecraft and text dialogs that receives input to go ahead and write the next piece of text. The scene ends with a dark screen fade which makes transition to the playable game. The scene is mostly driven by the script [OpenSceneSequence](https://github.com/ycarowr/SpaceMarine/blob/master/Assets/Scripts/Data/Sequences/Opening/OpeningSceneSequence.cs), which contains the instructions to move the spacecraft and show the text dialog.
  2. Game - Contains the playable part of the game. Monsters, player, doors and elevator are all here. Since its is quite big let's get an overview of the implementation I will split it into the [MVC](https://en.wikipedia.org/wiki/Model%E2%80%93view%E2%80%93controller) of the game and how I designed the entity system to support the player, enemies, doors, bullets etc and the Initialization of the systems.
  
The [Model](https://github.com/ycarowr/SpaceMarine/tree/master/Assets/Scripts/Model) and [UI/View](https://github.com/ycarowr/SpaceMarine/tree/master/Assets/Scripts/Ui) communication is done using the following interfaces/[Events](https://github.com/ycarowr/SpaceMarine/blob/master/Assets/Scripts/GameEvents/GameEvent.cs) and the [Observer Pattern](https://github.com/ycarowr/Tools/blob/3be2788408fd80bcd3c4a849bb0a7161230d944a/Patterns/Observer/Observer.cs) which allows to completely remove any dependency/coupling between both layers of the application. In shorter words, the UI scripts implement an interface and subscribe the events they are interested to, the Model classes dispatch those events when they happen. 
  
Assets by: http://pixelgameart.org/web/

