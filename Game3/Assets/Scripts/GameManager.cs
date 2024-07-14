using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int score = 0;
    public GameObject healthBar;
    public GameObject scoreImage;
    public GameObject gameOverMenu;

    public Player _player;
    public Text scoreText;
    public Text scoreInMenu;


    public void Awake()
    {
        Play();
        FindObjectOfType<SetCharacter>();
    }
    // Start is called before the first frame update

    public void GameOver()
    {
        gameOverMenu.SetActive(true);
        scoreImage.SetActive(false);
        healthBar.SetActive(false);
        _player.enabled = false;

        scoreInMenu.text = score.ToString();
        Enemy[] enemy = FindObjectsOfType<Enemy>();
        for (int i = 0; i < enemy.Length; i++)
        {
            Destroy(enemy[i].gameObject);
        }
        StartCoroutine(Pause());
    }
    public void Play()
    {
        
        FindObjectOfType<Player>().CallBackPlayer();

        score = 0;
        scoreText.text = score.ToString();
        _player.enabled = true;
        Time.timeScale = 1f;

        healthBar.SetActive(true);
        scoreImage.SetActive(true);
        gameOverMenu.SetActive(false);

    }
    public IEnumerator Pause()
    {
        yield return new WaitForSeconds(1f);
        Time.timeScale = 0f;
    }
    
    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();
    }
    public void Back()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    
}
