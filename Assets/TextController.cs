using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour {

    public Text body;
    private enum GameStates { Awoken, Baby, Glasses, Sleep, Start, Time, PickUpBaby, LeaveNursery, Wait };
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
                body.text = "You awaken to a loud shriek. You know not what time it is - it's still pitch black " +
                    "outside - but you have a pretty good idea where the sound is coming from.\n\n";
                displayOptions(new []{GameStates.Time, GameStates.Baby, GameStates.Sleep});
                break;
            case GameStates.Glasses:
                body.text = "You scrabble around on the night stand, but your glasses do not appear\n\n";
                displayOptions(new []{GameStates.Sleep});
                break;
            case GameStates.Sleep: 
                body.text = "Who are you kidding?!?\n\n";
				displayOptions(new []{GameStates.Time, GameStates.Baby});
                break;
            case GameStates.Start:
                body.text = "Welcome to The Long Night!\n\n";
                displayOptions(new []{GameStates.Awoken});
                break;        
            case GameStates.Time:
                if (hasGlasses)
                {
                    body.text = "You look over at the clock and see that it is really late. It's so late, it's " +
                        "actually rather early.\n\n";
                    displayOptions(new []{GameStates.Sleep});
                }
                else
                {
                    body.text = "You don't have your glasses so you can't see the clock across " +
                        "the room. Why you keep the clock on the other side of the room is a " +
                        "question for another sleepless night.\n\n";
                    displayOptions(new []{GameStates.Sleep});
                }
                break;
            case GameStates.Baby:
                body.text = "You enter your infant daughter's nursery room and she's suddenly quiet and still. " +
                    "Her eyes are fixed on you and she no longer seems to be perturbed.\n\n";
                displayOptions(new []{GameStates.PickUpBaby, GameStates.LeaveNursery, GameStates.Wait});
                break;
            default:
                body.text = "DEAD END!\n";
                displayOptions(new []{GameStates.Awoken});
                break;
        }
	}
    
    void displayOptions(GameStates[] options)
    {
        foreach (var option in options)
        {
            switch(option)
            {
                case GameStates.Awoken:
                    body.text += "Press the Space key to Start a New Game\n";
                    if (Input.GetKeyDown(KeyCode.Space)) gameState = GameStates.Awoken;
                    break;
                case GameStates.Baby:
                    body.text += "Press [B] to check on the Baby\n";
                    if (Input.GetKeyDown(KeyCode.B)) gameState = GameStates.Baby;
                    break;                
                case GameStates.Glasses:
                    body.text += "Press [G] to look for your Glasses\n";
                    if (Input.GetKeyDown(KeyCode.G)) gameState = GameStates.Glasses;
                    break;
                case GameStates.LeaveNursery:
                    body.text += "Press [L] to Leave the nursery.\n";
                    if (Input.GetKeyDown(KeyCode.L)) gameState = GameStates.LeaveNursery;
                    break;
                case GameStates.PickUpBaby:
                    body.text += "Press [P] to Pick up the baby.\n";
                    if (Input.GetKeyDown(KeyCode.P)) gameState = GameStates.PickUpBaby;
                    break;
                case GameStates.Sleep:
                    body.text += "Press [S] to go to Sleep.\n";
                    if (Input.GetKeyDown(KeyCode.S)) gameState = GameStates.Sleep;
                    break;
                case GameStates.Time:
                    body.text += "Press [T] to look at the Time\n";
                    if (Input.GetKeyDown(KeyCode.T)) gameState = GameStates.Time;
                    break;
                case GameStates.Wait:
                    body.text += "Press [W] to Wait there.\n";
                    if (Input.GetKeyDown(KeyCode.W)) gameState = GameStates.Wait;
                    break;                                                                               
                default:
                    body.text += "NO OPTION SET UP FOR " + gameState.ToString();
                    break;
            }
        }
    }
}
