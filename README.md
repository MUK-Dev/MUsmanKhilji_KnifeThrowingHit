# M Usman Khilji - Knife Throwing Hit
 Throw knives at board to destroy it

## Steps taken for making this
- Created board in blender with cuts and textured it
- Made prefab from of the board
- Imported a dagger and made its prefab
- Places all objects in the scene suitable for the camera view
- Applied rigid body & mesh collider to all the pieces of objects of the cutting board and sphere collider to the parent and made it a trigger
- Added rigid body and box collider to the dagger
- Made a dagger spawner that spawns a dagger as its child
- On mouse click made the dagger go up
- If the dagger collides with a trigger then it hit the board and its parent is changed to the board from the dagger spawner
- If the dagger collides with a collider then it hit another dagger and player loses the game
- Made the board rotate
- Made 3 modes for the board
- Linear keeps rotating in a single direction
- Random changes rotation after a random interval
- Reactive changes rotation when player clicks the mouse
- Added game over and game won UI texts
- Polished the game with different levels, sounds, and particle system.
