# Flappy Bird Windows
Hey its Flappy Bird but with Windows... on Windows

![screenshot_game.png](https://github.com/Der-Floh/Flappy-Bird-Windows/blob/master/Flappy_Bird_Windows/Resources/screenshot_game.png?raw=true)

## Controls
- Player 1: Space
- Player 2: Up Arrow
- Player 3: NumPad 8
- GameOver: Esc
- Pause: P
- FPS Counter: F3

Feel free to drag the windows around. Shrink and grow. It just works.

## Installation
1. Go to the [Latest Release](https://github.com/Der-Floh/Flappy-Bird-Windows/releases/latest)
2. Download `Flappy-Bird-Windows.exe`
3. Start the Game

## Configuration
You can change the config during the game start screen. When you do a `config.ini` file is created next to the game exe.

![screenshot_options.png](https://github.com/Der-Floh/Flappy-Bird-Windows/blob/master/Flappy_Bird_Windows/Resources/screenshot_options.png?raw=true)

```ini
[controls]
Player1=Space               ; Player 1 Flap Key (any key)
Player2=Up                  ; Player 2 Flap Key (any key)
Player3=NumPad8             ; Player 3 Flap Key (any key)
GameOver=Escape             ; Game Over Key (any key)
Pause=P                     ; Pause Key (any key)

[gameplay]
BirdGravity=1               ; Gravity / Fall speed as increase in pixels per 10 ms (any decimal value)
BirdFlapPower=30            ; Flap power in pixels (any decimal value)
BirdMaxFallSpeed=30         ; Max fall speed in pixels per 10 ms (any decimal value)
PipeScreenDistanceMin=157   ; The minimum distance in pixels the top of a pipe has to the screen = minimum pipe length (any integer value)
PipeGapMin=450              ; The minimum distance in pixels of the vertical gap between 2 pipes (any integer value)
PipeGapMax=600              ; The maximum distance in pixels of the vertical gap between 2 pipes (any integer value)
PipeGapShiftMin=100         ; The minium gap position change in pixels that the next pipe pair can have in comparison to the one before (any integer value)
PipeGapShiftMax=300         ; The maximum gap position change in pixels that the next pipe pair can have in comparison to the one before (any integer value)
PipeMoveSpeed=5             ; The move speed of all pipes in pixels per 10 ms (any integer value)
PipeSpawnOffset=0           ; The x offset in pixels of the spawned pipes related to the screen border (any integer value)
PipeDespawnOffset=0         ; The x offset in pixels of the despawned pipes related to the screen border (any integer value)
PipeSpawnDelay=3000         ; The delay in ms between each pipe pair spawn (any integer value)
ScoreMultiplier=1           ; The score multiplier (any integer value)
InstantRestart=false        ; Whether the game should instantly restart uppon game over (true or false)
CloseOnLoose=false          ; Whether the game should close itself uppon game over (true or false)
TapToStart=true             ; Whether the game should show the TapToStart window (true or false)

[program]
AlwaysOnTop=true            ; Whether game windows should always be on top of every other windows window (true or false)
SaveScore=true              ; Whether the game score should be saved (true or false)
SavedScoresMax=1000         ; The maximum amount of saved scores before old ones get deleted (any integer value)
```
*Yes 0 or negative numbers work ... in theory...*

<br>

[!["Buy me a Floppy Disk"](https://www.buymeacoffee.com/assets/img/custom_images/orange_img.png)](https://www.buymeacoffee.com/der_floh)
