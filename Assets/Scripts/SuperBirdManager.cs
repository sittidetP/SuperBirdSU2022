using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
public class SuperBirdManager : MonoBehaviour
{
    public BirdController bird;
    public GameObject pipePrefab;
    public GameObject panelMenu;
    public bool preBridDead = false;
    public float space;
    public UnityEvent onGameStart;
    public UnityEvent onBirdDead;
    public UnityEvent<string> onScoreChange;
    public UnityEvent<string> onHighScore;
    public UnityEvent onHighScoreAlert;
    int preScore;
    public float spawnTime = 1.5f;
    private int pipeXPos = 0;
    private float startSpawnTime;

    private void Awake()
    {
        bird = FindObjectOfType<BirdController>();
        //textScore = GameObject.Find("Text Score").GetComponent<TMP_Text>();
        //panelMenu = GameObject.Find("PanelMenu");
    }

    private void Start()
    {
        //panelMenu.SetActive(false);
        onGameStart?.Invoke();
        /*
        for (int i = 0; i < 20; ++i)
        {
            var pipe = Instantiate(pipePrefab);
            pipe.transform.position = new Vector3(i * space, Random.Range(-1f, 1), 0);
        }
        */
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > startSpawnTime + spawnTime && !bird.dead){
            var pipe = Instantiate(pipePrefab);
            pipe.transform.position = new Vector3(pipeXPos * space, Random.Range(-1f, 1), 0);
            pipeXPos++;
            startSpawnTime = Time.time;
        }
        //textScore.text = bird.score.ToString();
        if (preScore != bird.score)
        {
            if (onScoreChange != null)
            {
                onScoreChange.Invoke(bird.score.ToString());
            }
            preScore = bird.score;
        }
        if (preBridDead != bird.dead)
        {
            if (onBirdDead != null)
            {
                onBirdDead.Invoke();
            }
            preBridDead = bird.dead;

            int prevHighScore = GetHightScore();
            if(bird.score > prevHighScore){
                SaveHighScore(bird.score); 
                onHighScoreAlert?.Invoke();  
            }

            onHighScore?.Invoke(GetHightScore().ToString());
        }
    }

    public void GoHome()
    {
        SceneManager.LoadScene("Home");
    }

    public void TryAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    int GetHightScore(){
        if(PlayerPrefs.HasKey("HIGHSCORE")){
            return PlayerPrefs.GetInt("HIGHSCORE");
        }
        return 0;
    }

    void SaveHighScore(int score){
        PlayerPrefs.SetInt("HIGHSCORE", score);
    }

    public void ResetHightScore(){
        PlayerPrefs.SetInt("HIGHSCORE", 0);
        onHighScore.Invoke("0");
    }
}
