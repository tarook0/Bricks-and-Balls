using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
public class GameManger : MonoBehaviour
{

    public GameObject ballPerfab;
    public GameObject PlayerPerfab;
    public Text scoreText;
    public Text ballsText;
    public Text lvelsText;
    public GameObject panalMenu;
    public GameObject panalPlay;
    public GameObject panalLevelCompleted;
    public GameObject panalGameOver;
    public GameObject[] Levels;
    public static GameManger Instance { get; private set; }
    public enum State { MENU, INIT, PLAY, LEVELCOMPLETED, LOADLEVEL, GAMEOVER }
    State _state;
    GameObject _currentBall;
    GameObject _currentLevel;
    bool _isSwitchingState;
    private int _score;
    public int Score
    {
        get { return _score; }
        set
        {
            _score = value;
            scoreText.text = "Score" + _score;
        }

    }
    private int _level;
    public int Level
    {
        get { return _level; }
        set
        {
            _level = value;
            lvelsText.text = "Level: " + _level;
        }
    }
    private int _Balls;
    public int Balls
    {
        get { return _Balls; }
        set
        {
            _Balls = value;
            ballsText.text = "Balls: " + _Balls;
        }
    }



    //     private int _score;
    // public   int score
    // {
    //     get{return score}
    //     set{return score}


    // }
    public void PlayClicked()
    {
        switchState(State.INIT);
    }

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        switchState(State.MENU);

    }

    // Update is called once per frame
    public void switchState(State newState, float delay = 0)
    {
        StartCoroutine(SwitchDelay(newState, delay));

    }
    IEnumerator SwitchDelay(State newState, float delay)
    {
        _isSwitchingState = true;
        yield return new WaitForSeconds(delay);
        EndState();
        _state = newState;
        BegineState(newState);
        _isSwitchingState = false;
    }
    void BegineState(State newState)
    {
        switch (newState)
        {
            case State.MENU:
                panalMenu.SetActive(true);
                break;

            case State.INIT:
                panalPlay.SetActive(true);
                Score = 0;
                Level = 0;
                Balls = 3;
                Instantiate(PlayerPerfab);
                switchState(State.LOADLEVEL);
                break;

            case State.PLAY:
                break;

            case State.LEVELCOMPLETED:
                panalLevelCompleted.SetActive(true);
                break;

            case State.LOADLEVEL:
                if (Level > Levels.Length)
                {
                    switchState(State.GAMEOVER);

                }
                else
                {
                    _currentLevel = Instantiate(Levels[Level]);
                    switchState(State.PLAY);
                }
                break;

            case State.GAMEOVER:
                panalGameOver.SetActive(true);
                break;

        }

    }
    void Update()
    {
        switch (_state)
        {
            case State.MENU:
                break;

            case State.INIT:
                break;

            case State.PLAY:
                if (_currentBall == null)
                {

                    if (Balls > 0)
                    {
                        _currentBall = Instantiate(ballPerfab);
                    }
                    else
                    {
                        switchState(State.GAMEOVER);
                    }
                }
                break;

            case State.LEVELCOMPLETED:
                break;

            case State.LOADLEVEL:
                break;

            case State.GAMEOVER:
                break;

        }

    }

    void EndState()
    {
        switch (_state)
        {
            case State.MENU:
                panalMenu.SetActive(false);
                break;

            case State.INIT:
                panalPlay.SetActive(false);
                break;

            case State.PLAY:
                break;

            case State.LEVELCOMPLETED:
                panalLevelCompleted.SetActive(false);
                break;

            case State.LOADLEVEL:
                break;

            case State.GAMEOVER:
                panalGameOver.SetActive(false);
                break;

        }



    }
}
