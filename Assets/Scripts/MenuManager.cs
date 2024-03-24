using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] GameObject endCredit;
    [SerializeField] GameObject closeMain;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Credit() 
    {
        endCredit.SetActive(true);
        closeMain.SetActive(false);
    }

    public void Back()
    {
        endCredit.SetActive(false);
        closeMain.SetActive(true);
    }



}
