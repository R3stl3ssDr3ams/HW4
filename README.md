# HW4
## Devlog
The model-view-control pattern is which actions done by the user, controller, manipulates the data that models what is ultimately being presented to them, the view. Within this minigame 
specifically, players are in direct control of the Player class, and through events, those actions manipulate data between several scripts to present a dynamic gameplay loop. While most of 
the view is being frontloaded by the GameController class, with it manipulating the display of points and the activity of the scene by allowing players to restart upon failure, the Pipe class 
also presents feedback by playing audio upon player scoring throing _Coinaudio.Play().

## Open-Source Assets
If you added any other assets, list them here!
- [Brackey's Platformer Bundle](https://brackeysgames.itch.io/brackeys-platformer-bundle) - sound effects
- [2D pixel art seagull sprites](https://elthen.itch.io/2d-pixel-art-seagull-sprites) - seagull sprites