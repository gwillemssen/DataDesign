using Week3TextFiles;

// See https://aka.ms/new-console-template for more information

//create monster list and populate it with monsters in stats file
List<Monsters> monsterList = ReadFile.GetMonsters();

//create new game
Game game = new Game(monsterList);
//create a new player
Player player = new Player();

//run game
game.GameObserver(player);