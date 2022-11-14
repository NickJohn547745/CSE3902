# CSE3902 Interactive Systems Project
##### Authors: Nick Johnson, Will Blanton, Nathan Rogers, Andrew Wilkes, Evan Skripac
##### Date: November 14, 2022

# Sprint4:

## Controls:
### Player controls
* W - move Link up, make Link face up
* Up arrow - move Link up, make Link face up
* A - move Link left, make Link face left
* Left arrow - move Link left, make Link face left
* S - move Link down, make Link face down
* Down arrow - move Link down, make Link face down
* D - move Link right, make Link face right
* Right arrow - move Link right, make Link face right
* Z - make Link attack with sword
* N - make Link attack with sword
* 1 - Use Link’s bomb ability
* 2 - Use Link’s wooden boomerang ability
* 3 - Use Link’s magical boomerang ability
* 4 - Use Link’s wooden arrow ability
* 5 - Use Link’s silver arrow ability
* 6 - Use Link’s fireball ability
* K - Move to previous room
* L - Move to next room
* Left Click - Move to previous room
* Right Click - Move to next room

### Other controls
* G - spawn Bow to test item pickup
* Q - quit game
* R - reset the program to its initial state
* M - mute sound
* Escape - pause game

## Known Bugs
* Link moves across screen when walking through doors
* Link gets pushed back when using sword on enemy (could reduce player hitbox or make player invincible in sword animation)
* Swapping rooms with mouse can look weird if done quickly
* Health not currently drawn on HUD
* HUD values not dynamic
* Holding WASD + Arrow Key can speed up movement
* Clicking to change rooms breaks doors
* Moving through the top door causes a downwards room transition
* HUD should be at top of screen (at least it is in the actual game)
* Player can shoot an arrow during room transition (fix in transition state refactor
* Player sometimes disappears when movig between rooms while damaged (or allow player to move around screen during transition)
* Room transitions sometimes spawn player in tile
* Boomerang should be able to fly over "water" tiles in certain rooms
* Boomerang should return to player, not just initial position
