# Pang
Classic pang game

As a part of the challenge of creating a prototype Pang game, I hereby describe some of the decisions made in the process.

Firsly, I wanted to create a game which will be easily extendible. 
That means adding and modifying levels, weapons, loots and numbers of players was intended to be easy and swift - 
preferebaly with no changes to the codebase.

Therefore, I decided to pursue an MVC design pattern path, where the Unity based visuals will feed off a data layer model.
That enabled the game to have different visual representations using the same Model code based (with very minor changes).
I am personally tend to go towards architecturally efficient styles, and long term thinking, and that is why I chose MVC
as the first extra path for this game.

Secondly, making levels easy to add, remove and modify seems to me like a good business decision which allows for early 
prototyping in a game which relies mostly on level progression. I also enjoyed the engineering aspects of making the levels
as modular, extendible and loosly coupled from the rest of the system as I could. These two motivations led me to take 
the next extra path of 3 consecutive levels.

Going on from there I felt that maintaining a Data-View seperation (as part of MVC) would naturally extend to the players,
leading to modularity of player data and player view. I pursued this direction keeping in mind the a local multiplayer will
benefit from such logical seperation. This motivated me to continue with the local multiplayer extra path.

* A note on the project directory structure:
The traditional Scenes, Scripts, Materials, Models etc. structure does not seem optimal to me 
(it's like keeping all the chairs in your home in the same room). I prefer dividing the project based on features and modules.
Thus the current project structure reflect this attempt at ordering based on context.
