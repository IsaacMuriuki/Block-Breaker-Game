# Block Breaker Game
A 2D Block Breaker Game written in C#, using Unity Engine.

The objective of the game is to use the ball to destroy all the breakable blocks at the current level while preventing the ball from going below the paddle to progress to the next level
The user manipulates the position of the paddle by moving the mouse over the game screen left and right. The paddle's position reflects the mouses position on the x axis
At the beginning of a level the ball is stuck to the paddle, click anywhere on the screen to launch the ball off the paddle to start the game

The game can be played [here](https://simmer.io/@iso/block-breaker-game) 

Features include
- Breakable and Unbreakable Blocks 
  - Breakable blocks that have higher tiers of damage in higher levels i.e they require more than one hit from the ball to be destroyed
- When a player loses (i.e the ball goes below the paddle) the level is automatically reset
- A score system 
  - Increases by 25 for eavy brocken block 
  - When the next level is progressed to the previous level's score is carried over. Implemented using `DontDestroyOnLoad`
  - Score resets when the player loses
- Visual effects when a block is broken
- Audio effects when the ball collides with a wall or a block
- Ability to change the game speed
- Prevention of 
  - Boring ball loops 
  - The ball getting stuck at a position where it will not return to the bottom of the screen

### In-game screenshots

## The start game sreen
<img src="Screenshots/Start%20Menu.png">

## Level 1
<img src="Screenshots/Level%201.png">

## Level 2
<img src="Screenshots/Level%202.png">

## Level 3
<img src="Screenshots/Level%203.png">

## Level 4
<img src="Screenshots/Level%204.png">

## Level 5
<img src="Screenshots/Level%205.png">

## Game over screen
<img src="Screenshots/Game%20Over%20Menu.png">

## TODO
- Add more levels
- Add menu when in a level
- Add high score
- Add customizable boards and balls
- When a player loses give them the option to return to main menu
