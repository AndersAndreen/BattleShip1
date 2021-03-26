# Battleship 1
A C# console version of the classic game Battleship, with some slightly simplified rules.
I made it primarily to practice writing loosely coupled code with separations of concerns. This game is a demonstration of how one can separate user input, game display and game logic using interfaces and delegates. The game has two different input syntaxes and two different game boards that the player can switch back and forth whenever he/she likes while in the game without loosing data. This decoupling and flexibility is made possible by using interfaces and by injecting functions into other functions delegate style.

Rules of the game:
- Boats are randomly placed on a 11x7 grid by the program.
- Player enters coordinates in the form "a1", "k7" and so on.
- A miss is represented by at dot.
- If a boat is hit it sinks immediately and is displayed on screen as rows of X-es.
- All commands are displayed to the right of the game board.




