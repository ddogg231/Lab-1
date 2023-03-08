using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;


[DefaultExecutionOrder(-1)]
public class GameManager : MonoBehaviour
{
    public UnityEvent<int> onLifeValueChanged;
    private static GameManager _instance = null;
   
    public static GameManager Instance
    {
        get => _instance;
        
    }
    bool gameOverLoaded = false;
    public int maxLives = 5;
    private int _lives = 3;
    public int lives
    {
        get { return _lives; }
        set
        {
            if (_lives > value)
                Respawn();

            _lives = value;

            if (_lives > maxLives)
                _lives = maxLives;

            //if (_lives < 0)
            //gameover

            
            onLifeValueChanged?.Invoke(_lives);

            Debug.Log("Lives have been set to: " + _lives.ToString());
        }
    }

    public PlayerController playerPrefab;
    [HideInInspector] public PlayerController playerInstance = null;
    [HideInInspector] public Level currentLevel = null;
    [HideInInspector] public Transform currentSpawnPoint;



    private void Awake()
    {
        if (_instance)
        {
            Destroy(gameObject);
            return;
        }
        _instance = this;
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {

        lives = maxLives;
    }

    public void SpawnPlayer(Transform spawnPoint)
    {
        playerInstance = Instantiate(playerPrefab, spawnPoint.position, spawnPoint.rotation);
        currentSpawnPoint = spawnPoint;
    }

    void Respawn()
    {
        if (playerInstance)
            playerInstance.transform.position = currentSpawnPoint.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (SceneManager.GetActiveScene().buildIndex == 0)
                SceneManager.LoadScene(1);
            

            else
                SceneManager.LoadScene(0);
        }

        if (Input.GetKeyDown(KeyCode.K))
            lives--;


        if (lives <= 0 && !gameOverLoaded)
        {
            SceneManager.LoadScene(2);
            gameOverLoaded = true;
        }

    }

    public void UpdateCheckpoint(Transform spawnPoint)
    {
        currentSpawnPoint = spawnPoint;
    }

    
}
