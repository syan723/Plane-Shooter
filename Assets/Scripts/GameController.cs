using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject pauseButton;
    public GameObject gameoverMenu;
    public GameObject levelcompleteMenu;
    public TMP_Text endText;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        pauseButton.SetActive(true);
        gameoverMenu.SetActive(false);
        levelcompleteMenu.SetActive(false);
        endText.gameObject.SetActive(false);
        //endText.enable = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        pauseButton.SetActive(false);
        Time.timeScale = 0f;

    }
    public void ResumeGame()
    {
        pauseMenu.SetActive(false );
        pauseButton.SetActive(true);
        Time.timeScale = 1f;
    }
    public void GameOver()
    {
        gameoverMenu.SetActive(true );
        pauseButton.SetActive(false);
    }
    public IEnumerator LevelComplete()
    {
        yield return new WaitForSeconds(2f);
        endText.gameObject.SetActive(true);

        yield return new WaitForSeconds(3f);
        Time.timeScale = 0f;
        levelcompleteMenu.SetActive(true );

    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
