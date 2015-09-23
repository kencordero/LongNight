using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class TextController : MonoBehaviour {

    public Text text;
    private enum GameStates { Awoken, Baby, Glasses, Sleep, Start, Time, PickUpBaby };
    private GameStates gameState;
    private bool hasGlasses;

	// Initialization
	void Start () {
        gameState = GameStates.Start;
        hasGlasses = false;
	}
	
	// Called once per frame
	void Update () {
        switch (gameState)
        {
            case GameStates.Awoken:
                text.text = "You awaken to loud shriek. You know not what time it is - it's still pitch black " +
                    "outside - but you have a pretty good idea where the sound is coming from.\n\n";
                displayOptions(new []{GameStates.Time, GameStates.Baby, GameStates.Sleep});
                break;
            case GameStates.Glasses:
                text.text = "You scrabble around on the night stand, but your glasses do not appear\n\n";
                displayOptions(new []{GameStates.Sleep});
                break;
            case GameStates.Sleep: 
                text.text = "You try to go back to sleep...";
                break;
            case GameStates.Start:
                text.text = "Welcome to The Long Night";
                displayOptions(new []{GameStates.Awoken});
                break;        
            case GameStates.Time:
                if (hasGlasses)
                {
                    text.text = "You look over at the clock and see that it is really late. It's so late, it's actually rather early.\n\n";
                    displayOptions(new []{GameStates.Sleep});
                }
                else
                {
                    text.text = "You don't have your glasses so you can't see the clock across " +
                        "the room. Why you keep the clock on the other side of the room is a " +
                        "question for another sleepless night.\n\n";
                    displayOptions(new []{ GameStates.Sleep });
                }
                break;
            case GameStates.Baby:
                text.text = "You enter your infant daughter's nursery room and she's suddenly quiet and still. " +
                    "Her eyes are fixed on you but she doesn't seem to be perturbed.\n\n";
                displayOptions(new []{GameStates.PickUpBaby});
                break;
            default:
                throw new NotImplementedException(gameState.ToString());
        }
	}
    
    void displayOptions(GameStates[] options)
    {
        foreach (var option in options)
        {
            switch(option)
            {
                case GameStates.Awoken:
                    text.text += "Press Space key to Start a New Game\n";
                    if (Input.GetKeyDown(KeyCode.Space)) gameState = GameStates.Awoken;
                    break;
                case GameStates.Baby:
                    text.text += "Press [B] to check on the Baby\n";
                    if (Input.GetKeyDown(KeyCode.B)) gameState = GameStates.Baby;
                    break;
                case GameStates.Glasses:
                    text.text += "Press [G] to look for your Glasses\n";
                    if (Input.GetKeyDown(KeyCode.G)) gameState = GameStates.Glasses;
                    break;
                case GameStates.PickUpBaby:
                    text.text += "Press [P] to Pick up the baby.\n";
                    if (Input.GetKeyDown(KeyCode.P)) gameState = GameStates.PickUpBaby;
                    break;
                case GameStates.Sleep:
                    text.text += "Press [S] to go to Sleep.\n";
                    if (Input.GetKeyDown(KeyCode.S)) gameState = GameStates.Sleep;
                    break;
                case GameStates.Time:
                    text.text += "Press [T] to look at the Time\n";
                    if (Input.GetKeyDown(KeyCode.T)) gameState = GameStates.Time;
                    break;                                                                               
                default:
                    throw new NotImplementedException(gameState.ToString());
            }
        }
    }
}
