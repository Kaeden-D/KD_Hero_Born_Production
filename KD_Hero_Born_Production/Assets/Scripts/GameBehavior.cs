using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameBehavior : MonoBehaviour
{

    public string labelText = "Collect all 4 items and win your freedom!";
    public int maxItems = 4;
    public bool showWinScreen = false;
    public bool showLossScreen = false;

    private int ItemsCollected = 0;

    public int Items
    {

        get { return ItemsCollected; }

        set
        {

            ItemsCollected = value;
            Debug.LogFormat("Items: {0}", ItemsCollected);

            if (ItemsCollected >= maxItems)
            {

                labelText = "You've found all the items!";
                showWinScreen = true;
                Time.timeScale = 0f;

            }
            else
            {

                labelText = "Item found, only " + (maxItems - ItemsCollected) + " more to go!";

            }

        }

    }

    private float PlayerSize = 1f;

    public float Size
    {

        get { return PlayerSize; }

        set
        {

            PlayerSize = value;
            Debug.LogFormat("Size: {0}", PlayerSize);

        }

    }

    private int BulletDamage = 1;

    public int Damage
    {

        get { return BulletDamage; }

        set
        {

            BulletDamage = value;
            Debug.LogFormat("Damage: {0}", BulletDamage);

        }

    }

    private int PlayerHP = 10;

    public int HP
    {

        get { return PlayerHP; }

        set
        {

            PlayerHP = value;
            Debug.LogFormat("Lives: {0}", PlayerHP);

            if (PlayerHP <= 0)
            {

                labelText = "You want another life with that?";
                showLossScreen = true;
                Time.timeScale = 0;

            }
            else
            {

                labelText = "Ouch... that's got hurt.";

            }

        }

    }

    void RestartLevel()
    {

        SceneManager.LoadScene(0);
        Time.timeScale = 1.0f;

    }

    void OnGUI()
    {

        GUI.Box(new Rect(20, 20, 150, 25), "Player Health:" + PlayerHP);
        GUI.Box(new Rect(20, 50, 150, 25), "Player Size: " + PlayerSize);
        GUI.Box(new Rect(20, 80, 150, 25), "Items Collected: " + ItemsCollected);
        GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height - 50, 300, 50), labelText);

        if (showWinScreen)
        {

            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 50, 200, 100), "YOU WON!"))
            {

                RestartLevel();

            }

        }

        if (showLossScreen)
        {

            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 50, 200, 100), "You lose..."))
            {

                RestartLevel();

            }

        }

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
