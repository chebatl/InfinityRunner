using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager INSTANCE {get; private set;}
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private List<GameObject> buttonsList;

    private void Awake() {
        INSTANCE = this;
        Time.timeScale = 1;
    }

    public void ShowGameOver(){
        StartCoroutine("StopGame");
    }

    public void RestartGame(){
        SceneManager.LoadScene(1);
    }

    public void MainMenu(){
        SceneManager.LoadScene(0);
    }

    IEnumerator StopGame(){
        yield return new WaitForSeconds(0.5f);

        foreach(GameObject button in buttonsList){
            button.SetActive(false);
        }
        gameOverPanel.SetActive(true);
        Time.timeScale = 0;
    }
}
