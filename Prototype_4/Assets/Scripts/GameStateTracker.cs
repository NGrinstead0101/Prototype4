using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameStateTracker : MonoBehaviour
{
    public Queue<Robot> robotQueue = new Queue<Robot>();
    public RobotGenerator robotGenerator;

    public Image corpLogoImage;
    public List<Sprite> corpLogoSprites = new List<Sprite>(4);

    public GameObject confirmButton;
    public TextMeshProUGUI dialogueBox;
    public GameObject storeInterface;
    public Image robotSprite;
    public GameObject currentPart;
    public MoneyTracker mt;
    public MoneyFeedback moneyFeedback;
    public GameObject speechBubble;
    public HandTracker handTracker;

    public static State revealingRobots;
    public static State repairingRobot;
    public static State buyingCards;

    public State currentState;

    private void Awake()
    {
        revealingRobots = new RevealingRobots(this);
        repairingRobot = new RepairingRobot(this);
        buyingCards = new BuyingCards(this);

        BuyingCards.dayCount = 0;

        robotGenerator.GenerateRobots();

        currentState = revealingRobots;

        ShowInfo();
    }

    public void ShowInfo()
    {
        currentState.ShowInfo();
    }

    public void GetContinueInput()
    {
        ChangeState();
        //return currentState.CheckForContinueInput();
    }
    
    private void ChangeState()
    {
        currentState.ChangeState();
    }

    /// <summary>
    /// Called by RobotGenerator to add new robots to queue
    /// </summary>
    /// <param name="robotList"></param>
    public void AddRobots(List<Robot> robotList)
    {
        robotQueue.Clear();

        foreach (Robot robot in robotList)
        {
            Debug.Log("Corp: " + robot.Corp + "  Has Security: " + robot.HasSecurity + "  Dialogue: " + robot.Dialogue);
            robotQueue.Enqueue(robot);
        }
    }
}
