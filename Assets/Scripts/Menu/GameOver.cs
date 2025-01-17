using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOver : MonoBehaviour
{

    public TextMeshProUGUI loadScoreText; //load score gameobject in gameover
    public TextMeshProUGUI highScoreText; // high score gameobject in gameover
    public TMP_Text Coin;
    public GameObject LoadingScreen;
    public Slider slider;

    private void Awake()
    {
        //AdmobSystem.instance.ShowInterstitialAd();
    }

    private void Start()
    {
        loadScoreText.text = " " + PlayerPrefs.GetInt("GotScore").ToString(); //announce value of score in Load score gameobject in gameover from last scene
        highScoreText.text = "HIGHSCORE: " + PlayerPrefs.GetInt("highScore").ToString(); //announce value of highscore in Highscore gameobject in gameover scene
        Coin.text = "Coin: " + PlayerPrefs.GetInt("Coins").ToString();
    }
    public void Restart(string GameScene)
    {
        StartCoroutine(LoadAsynchronously(GameScene)); //to load to GameScene

    }

    public void MainMenu()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene("StartMenu"); //to load to StartMenu


    }
    public void Skin()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene("Skin"); //to load to StartMenu


    }


    IEnumerator LoadAsynchronously(string GameScene)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(GameScene);

        LoadingScreen.SetActive(true);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 9f);
            slider.value = progress;
            yield return null;
        }
    }


}
