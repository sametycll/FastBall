using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    //public static MenuManager instance;
    public static bool startState;
    [SerializeField] public GameObject menuCV;


    private void Awake()
    {
        startState = false;
        Time.timeScale = 0;
    }

    private void Update()
    {
        if (!startState)
        {
            
            if (Input.GetMouseButtonDown(0))
            {
                startState = true;
                menuCV.SetActive(false);
                Time.timeScale = 1;
            }
        }
    }



    //public void Awake()
    //{
    //    if (instance != null)
    //    {
    //        Debug.LogWarning("More than one Instance of Inventory found");
    //        Destroy(gameObject); 
    //        return;
    //    }
    //    else
    //        instance = this;

    //    startState = false;
    //    Time.timeScale = 0;
    //}


    //public void StartTheGame()
    //{
    //    gameState = true;   
    //    menuCV.SetActive(false);
    //}

}
