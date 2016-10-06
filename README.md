<snippet>
  <content>

# Migration

##Implementation Structure

###Turtle
Handles movement of the turtle and collisions with inanimate game objects in the scene
The UrtleCode script is for our main character (Jami). This script manages the movements of the turtle and sets the conditions to trigger the corresponding animations. 
This code does not keep track of the game conditions that determine winning and losing. Instead, it calls functions from the game manger upon collisions with puzzle pieces, seaweed, and the level boundary that indicates that they have fallen off the scene. 

The turtle detects collisions and triggers because it is the only moving object in the scene directly controlled by the player. The turtle acts as the detector of the effect/collisions/trigger instead of the creator of such effects/collisions.
The turtle is a Rigidbody and Circle Collider. The turtle needs to be able to collide with the platforms and have some sense of gravity in order to act as a regular physical object. The turtle is able to move horizontally, jump, go up and down ladders, and slide down slides. 
The character controller on the turtle manages the animations for the turtle’s movements. These animations are set by conditions (primarily booleans). These conditions are set in the UrtleCode script, then the animations change accordingly. 

###Shark
Handles any interaction with any moving object and the shark, as well as automated horizontal movement of the shark.
The SharkCode is attached to the shark-prefab, which contains a shark sprite and 4 empty game objects attached to the upper level part of the shark to determine its weakpoints.
The shark platform has the shark, and two colliders for each edge of the platform as its child. This way, the shark can be spawned with the platform and will not move off of the platform. The shark has an automated horizontal movement with a set speed.
The shark controller is very simply and only consists of moving right and moving left. The two animations are triggered by boolean functions. There are two separate animations as opposed to the turtle that has one walk animation that is flipped. This is because the shark has fewer animations than the turtle and the movement doesn’t depend on user input. It was easy to set booleans for when the shark changes direction, so it made sense to make two separate animations. Then, the only movement we needed to consider for the shark was moving to the right end of the platform and moving to the left end of the platform -- no transformation of the image was necessary. 

###Game Manager
Controls the playing state of the game and all the general functionality, like game state, points, message text, etc.
The GameManager keeps track of the following conditions, which determine the playing state of the game: 
the number of puzzle pieces collected and total number of pieces to collect
the timer
addition of time if seaweed is collected 
Based on the above conditions, the GameManager handles winning and losing the game. 
This script handles transitions between scenes, which include restarting the game at any point, transitions from level 1 to level 2, losing, starting at the appropriate scene, and winning scenes. 
This script also controls all the text displayed on level 1 and level 2, corresponding to the timer and puzzle piece count. This allows the Game Manager to control all the elements of the game within any playing scene.

###Inanimate objects
####Puzzle Pieces
The objects in the game the turtle has to collect in order to win or go to the next level.
Puzzle pieces are box colliders detected by the turtle.
There is a PuzzlePieceSpawn script that spawns them into selected empty GameObject locations in the levels. That way the location of the pieces can be pre-determined instead of spawning at random locations that would not necessarily give any challenge to the player.
####Platform
The surfaces on which the turtle moves.
Platforms are Box Colliders with a one-way Platform Effector. This is because it would allow the turtle to only collide with the platform when it is on top of the platform and would be able to go through it anywhere else.
####Ladder
The objects the turtle utilices to go up and down platforms besides jumping and using slides.
Ladders are Box Colliders with a trigger feature. This way the turtle would detect when it needs to use a ladder and differentiate it from a simple collision with any other object.
####Seaweed
The power ups that on collision allow the turtle 10 seconds of extra time to collect pieces.
Seaweed objects are Circle Colliders that the turtle can detect.

####Start Scene/Story Scene
These are separate from the Game Manager as they are not dependent on the player’s progress in the game. The story scene does provide the option to skip the story if a player has already read it, thus facilitating the re-attempting of the levels. 

####Puzzle Piece Final Spawn/Reuniting Scene 
These are also separate from the GameManager and are only called upon completion of level 2. They are independent of all conditions of the game. They handle the winning game scenes, from the puzzles appearing in random locations on the screen, to the final, completed puzzle image, to Jami walking up the tree to join her family. 


##Analysis
Although just a single player versus game 2D platformer, Migration has much more depth than that. The larger objective is to unite Jami the turtle with her family, who left while she was sleeping. The story scene outlines that conflict, but also outlines the other objectives and rules of the game. For example, “Help Jami collect the puzzle pieces to figure out where her family is waiting for her.” This hints that one of the objectives of this game is to find a solution. Each piece that you collect will eventually form the puzzle that shows you where the family is. Furthermore, the storyline hints that “a young turtle cannot survive in the wild by herself for too long.” This is a clue that the game will also have a race against time aspect. Once level 1 loads, the player will see that part of the point of the game is exploration. Learning the scene and puzzle piece layout is integral for completing the levels in time.

We did not outline any specific rules, but rather allowed the player to figure out how to use the controls and play the game by practice. We also used level design to teach him. He learns early on that you die if you fall off a platform and that some platforms are too far to reach by jumping. In level 2, you use the same controls, but are moving down (since you’re underwater) instead of up. You can also slide down in the second level. By level 2, the sharks are also introduced, but you can avoid them by building upon what you’ve learned in level 1. Additionally, as we’ll explain later, seaweed adds time, but the player needs to discover that himself.

This game is neither interesting nor feasible without its resources, the first being time and the second being seaweed, which is linked to time. The player only has a limited amount of time to complete each level, adding a dramatic effect (conflict). Seaweed is a necessary resource. We designed the game so that the player inadvertently discovers the purpose of it. When he collects his first piece of seaweed by colliding with it, text pops up alerting him that he just earned ten more seconds of time. It is extremely difficult to complete a level without collecting seaweed, but it is limited and scattered in positions that are difficult to reach. A key dimension of our game is that we relate to real-world, known scenarios. Besides the fact that sea turtles can’t climb ladders and would not hide in tree houses, they do collect seaweed for food, young ones cannot survive on their own for long, and they do get hunted by sharks. Each of these aspects makes the game more intuitive.
Time, in addition to being a resource, also contributes to the conflict. Without a time limit, the game would be MUCH more boring. Then the player would have all the time in the world to explore the scene (which would be fine if it were bigger) and make sure he collected every puzzle piece. There would be no uncertainty in the outcome. Of course he’d find every piece eventually. The time limit makes the player approach the game more strategically. If he misses a puzzle piece in one area, he probably wouldn’t have time to come back and find it later. He needs to come up with how he wants to approach the game, and he gets better as he slowly figures out the scene layout. Chances are, the player will not complete the levels the first few times around, but that’s real life -- and it keeps him engaged! By level 2, more conflict emerges -- sharks! What the player doesn’t know is that jumping on the shark actually kills it. It’s an added (and fun!) bonus if figured out, but isn’t necessary to complete the levels. You can just avoid them instead.

We realize that once you learn where the puzzle pieces are in this game, it becomes less complicated to complete. However, hopefully it will take the player a few rounds to master the levels, and they will be motivated to do so. We know that the game mechanics are not the most original in the world and that the game is not super action packed, but each one of our testers was determined to repeat each level until he or she was successful. We also thought that some might consider the lack of a health bar or “lives” as a downside, but since the game play on each level is relatively short, this did not seem to be an issue. It’s just as easy to restart a level.

We learned from several rounds of playtesting with friends that, depending on the nature of the player, he or she remains engaged for a variety of reasons. For most, it is the race against time and the competition that it creates. For others, it is the ability to kill sharks. For some, it is the story aspect and the desire to reunite Jami with her family and make sure she doesn’t die. The lesson from this is that the storyline adds flare. The physical locations of the levels, the seaweed, the shark, and the timer (based on survival in the wild) all make the game more exciting and logical. The three ways you can die (falling off, getting eaten, or running out of time) all related to the real world. Additionally, the vertical instead of horizontal movement adds a nice and original touch. It’s fun to be able to climb ladders and slide down platforms. All of these aspects take a simple game about a turtle and turn it into an engaging game that you can play multiple times.
</content>
</snippet>
