using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    int currentIndex ;
    
    // Start is called before the first frame update
    void Start()
    {
        currentIndex = SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void NextLevel()
    {
        SceneManager.LoadScene(currentIndex+1);
    }
    public void Reload()
    {
        SceneManager.LoadScene(currentIndex);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
