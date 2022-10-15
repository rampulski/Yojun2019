using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InputManager : MonoBehaviour
{
    private static InputManager _instance;
    public static InputManager instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<InputManager>();
            }
            return _instance;
        }
    }

    public bool[] inputPlayersPressed;

    [SerializeField] private GameSettings gameSettings;

    private GabaritPlayerPos gabaritScript;
    public float timeToChangeScene;
    public float timePressed;

    void Start ()
    {
        gabaritScript = GameObject.FindObjectOfType<GabaritPlayerPos>();
    }

    void Update()
    {
        timeToChangeScene += Time.deltaTime;

        if (Input.GetKey(KeyCode.X) && timeToChangeScene >= 4f)
        {
            timePressed += Time.deltaTime;

            if (SceneManager.GetActiveScene().buildIndex == 0 && timePressed >= 2f)
            {
                timeToChangeScene = 0f;
                timePressed = 0f;
                SceneManager.LoadScene(1);

            }
            else if (SceneManager.GetActiveScene().buildIndex == 1 && timePressed >= 2f)
            {
                timeToChangeScene = 0f;
                timePressed = 0f;
                SceneManager.LoadScene(0);
            }
        }


        if (Input.GetKeyDown(KeyCode.B))
        {
            gabaritScript.SwitchColor();
        }

        if (Input.GetKey(KeyCode.N))
        {
            gabaritScript.scaleValue -= 0.01f;
            gabaritScript.ChangeSize();
        }
        if (Input.GetKey(KeyCode.Comma))
        {
            gabaritScript.scaleValue += 0.01f;
            gabaritScript.ChangeSize();
        }


        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(0);
        }


        if (Input.GetKeyDown(KeyCode.Z))
        {
            inputPlayersPressed[0] = true;

        }
        else if (Input.GetKeyUp(KeyCode.Z))
        {
            inputPlayersPressed[0] = false;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            inputPlayersPressed[1] = true;

        }
        else if (Input.GetKeyUp(KeyCode.R))
        {
            inputPlayersPressed[1] = false;
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            inputPlayersPressed[2] = true;

        }
        else if (Input.GetKeyUp(KeyCode.T))
        {
            inputPlayersPressed[2] = false;
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            inputPlayersPressed[3] = true;

        }
        else if (Input.GetKeyUp(KeyCode.P))
        {
            inputPlayersPressed[3] = false;
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            inputPlayersPressed[4] = true;

        }
        else if (Input.GetKeyUp(KeyCode.Q))
        {
            inputPlayersPressed[4] = false;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            inputPlayersPressed[5] = true;

        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            inputPlayersPressed[5] = false;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            inputPlayersPressed[6] = true;

        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            inputPlayersPressed[6] = false;
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            inputPlayersPressed[7] = true;

        }
        else if (Input.GetKeyUp(KeyCode.F))
        {
            inputPlayersPressed[7] = false;
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            inputPlayersPressed[8] = true;

        }
        else if (Input.GetKeyUp(KeyCode.G))
        {
            inputPlayersPressed[8] = false;
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            inputPlayersPressed[9] = true;

        }
        else if (Input.GetKeyUp(KeyCode.H))
        {
            inputPlayersPressed[9] = false;
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            inputPlayersPressed[10] = true;

        }
        else if (Input.GetKeyUp(KeyCode.J))
        {
            inputPlayersPressed[10] = false;
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            inputPlayersPressed[11] = true;

        }
        else if (Input.GetKeyUp(KeyCode.K))
        {
            inputPlayersPressed[11] = false;
        }
    }

    public Color GetPlayerColor(int index)
    {
        return gameSettings.GetPlayerColor(index);
    }
}
