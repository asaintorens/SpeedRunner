using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using UnityEngine.SceneManagement;
using Assets.MyAssets.Resources.Script.database;
using Assets.MyAssets.Resources.Script;

public class Game : MonoBehaviour {
    [Header("DEBUGGER OPTIONS")]
    public bool debugNoGameOver;
    public bool debugNoUpTime;
    public bool debugNoJump;
    public bool debugNoSlide;
    public bool debugNoEnforce;
    public bool debugNoSpear;

    public UIControl ui;
    public GameObject Player;
    public static  bool GameOver;
    public int ObjectToLoadAfter;
    public int lenghtObstacle;
    public List<GameObject> Obstacles;
    private int indexToDestroy = 0;
    private GameObject currentObstacle;
    public int objectBeforePlayer;
     private float initialTargetY;
    public float timeScale;
    public int currentGameObjectIndex;
    public int previousGameObjectIndex;

    public float timeScaleUp;
    public int score;
    public float timeScaleOnGameOver;
    
    public RagdollHelper ragdoll;
    public Moving movePlayer;
    public Animator animatorController;
    public LogicAnimationController logicAnimator; // auto added
    public int distanceToAction;
    private int countObstacleForTime;

    public AudioSource audio;

    // Use this for initialization
    void Start () {
        this.Obstacles = new List<GameObject>();
        this.ragdoll = this.Player.GetComponent<RagdollHelper>();
        this.logicAnimator = this.GetComponent<LogicAnimationController>();
        this.movePlayer = this.Player.GetComponent<Moving>();
        this.animatorController = this.Player.GetComponent<Animator>();
        this.InitiateMap();
        this.InitiatePlayer();
        Time.timeScale=0;
        this.InitiatePlayerPref();

        string player = PlayerPrefs.GetString(PlayerPrefsString.NAME);


        if(PlayerPrefs.GetString(PlayerPrefsString.NAME) !="")
        {
            this.StartGame();
        }
        else
            ui.EnablePlayerWriteName();     

        
      
	}

    private void InitiatePlayerPref()
    {
        if(PlayerPrefs.GetInt(PlayerPrefsString.MUSIC) != null)
        {
            if(PlayerPrefs.GetInt(PlayerPrefsString.MUSIC)== 0)
            {
                this.audio.mute = true;
                this.ui.SetAudioButton();
            }
        }
    }

    public void RestartGame()
    {
        GameOver = false;
        Application.LoadLevel("game");

    }

    public void StartGame()
    {
        Time.timeScale = this.timeScale;
        this.audio.Play();
        this.ui.HideStartButton();
    }

    private void InitiatePlayer()
    {
        Player.transform.position = new Vector3(lenghtObstacle / 2, 0.5f, 0);
    }

    private void InitiateMap()
    {
        this.AddObstacle(EnumerationInput.Run);
        this.AddObstacle(EnumerationInput.Run);
        this.AddObstacle(EnumerationInput.Run);
        for (int i = 0; i < ObjectToLoadAfter; i++)
        {
            this.AddObstacle();
        }
    }

    // Update is called once per frame
    void Update () {

        if (!GameOver)

        {
            this.GenerateMap();
            this.ControlLogic();
         
        }

	}

    private void ControlLogic()
    {
        this.currentGameObjectIndex = (int)(((this.Player.transform.position.x+this.distanceToAction) / 10)) ;
        if (this.currentGameObjectIndex != this.previousGameObjectIndex)
        {
            this.countObstacleForTime++;
            if (this.countObstacleForTime == 5)
            {
                this.UpdateTime();
                this.countObstacleForTime = 0;
            }
            this.currentObstacle = Obstacles.ElementAt(this.currentGameObjectIndex);
            Obstacle currentOb = currentObstacle.GetComponent<Obstacle>();
            if(currentOb.inputWaited == EnumerationInput.Enforce)
            {
                currentOb.BreakObject();
            }
            if(currentOb.inputWaited != EnumerationInput.Run)
            {
                if(this.logicAnimator.GetAnimationRunning() == currentOb.inputWaited)
                {
                   // this.animatorController.SetBool("Slide", true);
                  
                    this.score++;
                    
                }else
                {
                    if(!debugNoGameOver)
                    this.StopGame();
                }
            }
             //   EnumerationObstacle getInput = null;

            this.previousGameObjectIndex = this.currentGameObjectIndex;
        }


    }

    private void UpdateTime()
    {
        Time.timeScale = this.timeScale;
        if (!this.debugNoUpTime)
        {
            this.timeScale += this.timeScaleUp;
          
        }
    }

    private void GenerateMap()
    {
        GameObject lastObstacle = (from x in Obstacles select x).Last();
        if(this.Player.transform.position.x + this.ObjectToLoadAfter*lenghtObstacle > lastObstacle.transform.position.x)
        {
            this.AddObstacle();
            this.RemoveFirstObstacle();

        }
    }

    public void GoMenu()
    {
        SceneManager.LoadScene(0);
    }

    private void RemoveFirstObstacle()
    {
        GameObject firstObstacles = Obstacles[this.indexToDestroy];
       
        Destroy(firstObstacles);
        this.indexToDestroy++;
        
    }

    public void StopGame()
    {

        GameOver = true;

        this.currentObstacle.GetComponent<Obstacle>().enableCollider = true;
         Obstacles.ElementAt(this.currentGameObjectIndex+1).GetComponent<Obstacle>().enableCollider = true;
        this.Player.GetComponent<RagdollHelper>().ragdollMode = true;
        Time.timeScale = this.timeScaleOnGameOver;
        this.StartCoroutine("coroutineScore");
        if (!Application.isEditor)
        {
            
        }
  

        
        
    }

    public IEnumerator coroutineScore()
    {
        try
        {
            PlayerPrefsManager.AddScore(this.score.ToString());
       

        ManagerDB.AddScoreToApi(PlayerPrefs.GetString(PlayerPrefsString.NAME), this.score);
        }
        catch (Exception)
        {

        }
        yield return null;
    }

    public void PlayerToRagdoll()
    {
        this.ragdoll.ragdollMode = true;
    }

    public void AddObstacle()
    {
        EnumerationInput myRandomObstacle = (EnumerationInput)UnityEngine.Random.Range(0, 4);
        this.AddObstacle(myRandomObstacle);
    }
    public void AddObstacle(EnumerationInput obstacle)
    {
        GameObject obstacleAdded = null;

        string RunFolder = "Obstacles/ObstacleRun";

        switch (obstacle)
        {
            case EnumerationInput.Run:
                obstacleAdded = Instantiate(Resources.Load(RunFolder)) as GameObject;          
                break;
            case EnumerationInput.Jump:
                if(debugNoJump)
                    obstacleAdded = Instantiate(Resources.Load(RunFolder)) as GameObject;
                else
                    obstacleAdded = Instantiate(Resources.Load("Obstacles/ObstacleJump")) as GameObject;
                break;
            case EnumerationInput.Slide:
                if (debugNoSlide)
                    obstacleAdded = Instantiate(Resources.Load(RunFolder)) as GameObject;
                else
                    obstacleAdded = Instantiate(Resources.Load("Obstacles/ObstacleSlide")) as GameObject;
                break;
            case EnumerationInput.Enforce:
                if(debugNoEnforce)
                    obstacleAdded = Instantiate(Resources.Load(RunFolder)) as GameObject;
                else
                    obstacleAdded = Instantiate(Resources.Load("Obstacles/ObstacleEnforce")) as GameObject;
                break;
            case EnumerationInput.Spear:
                if(debugNoSpear)
                    obstacleAdded = Instantiate(Resources.Load(RunFolder)) as GameObject;
                else
                    obstacleAdded = Instantiate(Resources.Load("Obstacles/ObstacleSpear")) as GameObject;
                break;       
        }


        if(this.Obstacles.Count ==0)
        {
            obstacleAdded.transform.position = Vector3.zero;
        }else
        {
            obstacleAdded.transform.position = new Vector3(this.lenghtObstacle * this.Obstacles.Count, 0);
        }
        this.Obstacles.Add(obstacleAdded);
    }
}
