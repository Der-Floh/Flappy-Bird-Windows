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

## Installation
1. Go to the [Latest Release](https://github.com/Der-Floh/Flappy-Bird-Windows/releases/latest)
2. Download either `Flappy-Bird-Windows` zip or msi depending on whether you want the portable (zip) or installed (msi) Version
3. - **For MSI Installer:** Execute the installer and follow the instructions. After the installation the Game is installed just as any other App on your PC
   - **For ZIP Portable:** Extract the contents of the zip file using the program of your choice to anywhere you want. In the extracted Folder execute the `Flappy_Bird_Windows.exe` file to start the Game

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
