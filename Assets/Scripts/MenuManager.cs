using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    //public static MenuManager instance;
    public static bool startState;
    public  bool gameOverState;
    [SerializeField] public GameObject menuCV;
    [SerializeField] public GameObject goCV;
    [SerializeField] public TextMeshProUGUI _score;
    [SerializeField] public TextMeshProUGUI goScore;


    private void Awake()
    {
        startState = false;
        gameOverState = false;
        Time.timeScale = 0;
        goCV.SetActive(false);
    }

    private void Update()
    {
        GameObject.FindWithTag("Particle").GetComponent<ParticleSystem>().Play();


        if (!startState)
        {
            
            if (Input.GetMouseButtonDown(0))
            {
                startState = true;
                menuCV.SetActive(false);
                Time.timeScale = 1;
            }
        }

        if (gameOverState)
        {
            goCV.SetActive(true);
            goScore.text = PlayerPrefs.GetInt("Score").ToString();          
           
           
            if (Input.GetMouseButtonDown(0))
            {
                PlayerPrefs.SetInt("Score", 0);
                SceneManager.LoadScene(0);
            }


        }


    }




}
