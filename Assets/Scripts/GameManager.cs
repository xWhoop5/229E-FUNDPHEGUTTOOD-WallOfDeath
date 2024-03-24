using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private List <GameObject> failedScene;
    [SerializeField] private List<GameObject> winScene;
    [SerializeField] GameObject hideTutorial;
    [SerializeField] private GameObject Player;
    public PlayerMovement playerMovement;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerMovement.failedCon && Player == null)
        {
            Ondeath();
        }

        else if (playerMovement.winCon && Player == null)
        {
            OnWin();
        }
    }


    void OnWin()
    {
        HideTu();
        foreach (GameObject gameObject in winScene)
        {
            gameObject.SetActive(true);
        }
    }

    void Ondeath()
    {
        HideTu();
        foreach (GameObject gameObject in failedScene)
        {
            gameObject.SetActive(true);
        }
    }
    
    void HideTu()
    {
        hideTutorial.SetActive(false);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -1);
    }
}
