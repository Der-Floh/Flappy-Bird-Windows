# Flappy Bird Windows
Hey its Flappy Bird but with Windows... on Windows

![game-screenshot](https://github.com/Der-Floh/Flappy-Bird-Windows/blob/master/Resources/screenshot-game.png?raw=true)

## Controls
- Player 1: Space
- Player 2: Up Arrow
- Player 3: NumPad 8
- GameOver: Esc
- Pause: P

Feel free to drag the windows around. Shrink and grow. It just works.

## Configuration
There is a config file called `config.ini` in the root folder.

```ini
[controls]
player1key=space
player2key=up
player3key=numpad8
gameoverkey=escape
pausekey=p

[gameplay]
birdgravity=1
birdflappower=30
birdmaxfallspeed=30
pipescreendistancemin=157
pipegapmin=450
pipegapmax=600
pipegapshiftmin=100
pipegapshiftmax=300
pipemovespeed=5
pipespawnoffset=0
pipedespawnoffset=0
pipespawndelay=3000
scoremultiplier=1
instantrestart=false
closeonloose=false
taptostart=true

[program]
alwaysontop=true
savescore=true
savedscoresmax=1000
```
