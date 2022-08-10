# The flow of the game

### Click detection
The click detection is very simple using `OnMouseDown` in every Tile of the Playfield. After successfully clicking on a Tile, the next available player is selected.

### Successful click
A successful click is when the click lands on a tile which has no orbs, or has orbs from the player.

### Next player
Players can be imagined as they sit at a round table, and the next player is always to the right. If a player gets eliminated, they stand up from the table. In more concrete terms, that means that for every player, there is a hidden boolean `playerAlive` containing if they are still in-game (not eliminated), and when selecting the next player, an integer `currentPlayer` gets incremented until the player with idx `currentPlayer` is alive (has its `playerAlive` set to `true`). If `currentPlayer` holds the same value as `maxPlayers`, its value becomes `0`.

### On a successful click
- If the tile was empty, it will receive an orb with the color of the `currentPlayer`.
- If the tile isn't empty, it will get an additional orb.
If the tile becomes full (2 for corner tiles 3 for edge tiles and 4 for center tile), they will explode (**Tile Explosion** below).

### Exploding tile detection
Every tile on the playfield will get checked if they are full. If they are, they are added to a list containing the exploding tiles. If this list isn't empty, **Tile Explosion** happens. If it is empty, and a **Tile Explosion** has happened, **Player aliveness test** happens.

### Tile explosion
Every exploding tile will release an orb into every possible direction, and take over the tiles there. (their owner will become the exploding tile's owner.) Meanwhile, these tiles become empty.
After every explosion simulation, there is an **Exploding tile detection**, to ensure that the chain reaction of exploding tiles play properly.

### Player aliveness test
Running through every tile on the playfield, we check for every player if they have at least one orb.
If they don't, they become eliminated.
If there is only one player who has orbs, they will the game.