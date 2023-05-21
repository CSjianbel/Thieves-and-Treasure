using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    Player [] players;
    SquareScript [] squares;
    DiceAnimation diceAnimation;
    DiceFaces [] diceFaces;
    // Start is called before the first frame update
    const int numPlayers = 4;
    const int numSquares = 100;
    int currentPlayer;
    bool rolling;
    int diceFace;

    void Start()
    {
        currentPlayer = 0;
        diceFace = 1;
        rolling = false;

        // Get diceFaces
        diceFaces = GetComponentsInChildren<DiceFaces>();
        // Hide all the other faces except for the 1st one
        for (int i = 1; i < diceFaces.Length; i++) {
            diceFaces[i].hide();
        }

        // Get Dice Animation
        diceAnimation = GetComponentInChildren<DiceAnimation>(); 
        // Hide the animation object
        diceAnimation.hide();

        // Get squares
        squares = GetComponentsInChildren<SquareScript>();
        // Get Players
        players = GetComponentsInChildren<Player>();
        foreach (Player player in players) {
            player.setPosition(squares[player.getSquare()].getPosition());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnDiceRollButtonPress() {
        if (!rolling) {
            // Hide the dice face
            diceFaces[diceFace - 1].hide();
            // Show the animation
            diceAnimation.roll();
            diceAnimation.show();
            rolling = true;
        }
    }

    public void FinishedAnimation() {
        diceAnimation.hide();
        rolling = false;
        diceFace = Random.Range(1, 7);
        // Move the players position
        int newSquare = Mathf.Min(numSquares - 1, players[currentPlayer].getSquare() + diceFace);
        players[currentPlayer].move(newSquare, squares[newSquare].getPosition());
        // Move to next Player
        nextPlayer();
        diceFaces[diceFace - 1].show();
    }

    void nextPlayer() {
        currentPlayer = (currentPlayer + 1) % numPlayers;
        Debug.Log(currentPlayer);
    }
}
