using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private CreateBlock createBlock;
    public int PlayerLife = 3;

    private int stage = 1;
    public int Stage
    {
        get
        {
            return stage;
        }
        set
        {
            stage = value;
        }
    }

    private bool isUpdateBlock = false;

    [SerializeField]
    private float ballSpeed;
    [SerializeField]
    private ScoreDisplay scoreDisplay;

    [SerializeField]
    private Transform tCamera;
    private Vector3 tCamInitialPos;
    private bool isShakeCamera = false;
    private float randomNumX;
    private float randomNumY;
    private float moveTime = 0;

    public bool IsGameOver = false;

    private bool readyGenerateBall = false;
    private bool ballIsDetected = false;

    private float timer = 0;
    //初始化
    private void Awake()
    {
        Time.timeScale = 1;
        instance = this;
    }

    public Ball ball;
    [SerializeField]
    private List<Block> blocks;
   
    void Start()
    {
        tCamInitialPos = tCamera.position;
        createBlock = GetComponent<CreateBlock>();
        Block[] bks = FindObjectsOfType<Block>();//疆場景景的Block元素加入於bks陣列
        foreach(Block b in bks)
        {
            blocks.Add(b);
        }
    }

   
    void Update()
    {
        LogBallSpeed();
        DetectIsBallDestroy();

        if (readyGenerateBall)
            StartGenerateBall();

        DetectBlockCount();
        if (isUpdateBlock)
            UpdateBlockCount();

        if (isShakeCamera)
            CameraShaking();

        DetectPlayerLife();
    }

    void LogBallSpeed()
    {
        ballSpeed = ball.speed;
    }

    void DetectIsBallDestroy()
    {
        if (ball == null && !ballIsDetected)
        {
            readyGenerateBall = true;
            ballIsDetected = true;
            isShakeCamera = true;
            PlayerLife--;
        }
    }
    #region 重生一個球
    private void StartGenerateBall()
    {
        StartCoroutine(GenerateBall());
    }

    private IEnumerator GenerateBall()
    {
        readyGenerateBall = false;
        yield return new WaitForSeconds(3.0f);
        Ball tBall = Resources.Load<Ball>("Prefabs/Ball");
        ball = Instantiate<Ball>(tBall, Vector2.zero, tBall.transform.rotation);
        ballIsDetected = false;

    }
    #endregion

    void DetectBlockCount()
    {
        foreach(Block b in blocks)//檢查有無block被Destroy
        {
            if(b == null)
            {
                isUpdateBlock = true;
                break;
            }
        }
    }

    void DetectPlayerLife()
    {
        if(PlayerLife <= 0)
        {
            PlayerLife = 0;
            IsGameOver = true;
            Time.timeScale = 0;

        }
    }


    private void UpdateBlockCount()//更新List<Block>中的數量
    {
        blocks.Clear();
        Block[] bks = FindObjectsOfType<Block>();
        foreach (Block b in bks)
        {
            blocks.Add(b);
        }
        isUpdateBlock = false;
    }

    void CameraShaking()//讓攝影機震動
    {
        timer += Time.deltaTime;
       

        if(timer >= 1.0f)
        {
            timer = 0;
            isShakeCamera = false;
            tCamera.position = tCamInitialPos;
        }

        if(moveTime <=0.05f)
        {
            moveTime += Time.deltaTime;          
        }
        else
        {
            randomNumX = Random.Range(-1.5f, 1.5f);
            randomNumY = Random.Range(-1.5f, 1.5f);
            moveTime = 0;
            if (timer < 1.0f)
                tCamera.position = new Vector3(randomNumX, randomNumY, -10);
        }  
    }
}
