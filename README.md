-- Every source file for the project can be accessed by Assets/ Scripts --

## Playtesting Reports:

### Playtest 1
- **Objective:** Incomplete “Tutorial” level with 3 platforms. Testing player mechanics rather than player interaction with the game world. No specific protocols.
- **Players:**
  - Peyton Turner - Found controls intuitive but suggested a slight increase in jump height for better maneuverability.
  - My Dad (Jong Youl Kim) - Appreciated simplicity of mechanics but felt character's movement speed could be faster.
  - Connor Waddell - Liked the stealth aspect but recommended adding a visual cue when character is in danger of being spotted.
  - Safia Dada - Suggested incorporating a brief on-screen tutorial to explain controls before starting the level.
- **Changes / Reflection:**
  - Increased character's jump height and length slightly.
  - Adjusted character's movement speed to be faster (2.5 → 4).
  - Implemented on-screen tutorial that briefly explains controls before level starts.

### Playtest 2
- **Objective:** Completed tutorial level with one enemy. Testing enemy’s player detection. No specific protocols.
- **Players:**
  - Peyton Turner - Noted that instant death mechanic was too harsh and suggested a warning or a brief grace period before player dies.
  - My Mom (Un Kyung Kim) - Appreciated concept but felt instant death mechanic led to frustration and suggested implementing a stealth indicator.
  - Safia Dada – Suggested concept of a “wall” where players can use their environment to hide behind a game object.
  - Rachel Kim – Suggested using prefabs instead of game objects for every object in the item and noted wrong usage of tile palettes and tiles/grids.
- **Changes / Reflection:**
  - Instead of instant death, player now has a small chance to dodge projectiles shot by the enemy.
  - Refactored Tutorial level to use prefabs instead of game objects for everything.

### Final Playtest
- **Objective:** Level 1 where enemies can shoot projectiles, player has a chance to dodge them, and walls are added to block enemy’s line of sight from seeing the player.
- **Players:**
  - Connor Waddell – Noted difficulty in seeing where he is going due to camera view.
  - Zacharia Kornas – Found game to be short and suggested adding more content or extending the levels.
  - Hui Xie – Found players can get “stuck” a lot and suggested finding a way to “die fast” so the game is always on action.
  - Safia Dada – Liked the wall aspect of the game.
- **Changes / Reflection:**
  - Increased camera size avoided to keep the game challenging.
  - Added fall damage or trap so players can die immediately when they fall into something where they cannot get out, avoiding situations where players cannot win or lose.
