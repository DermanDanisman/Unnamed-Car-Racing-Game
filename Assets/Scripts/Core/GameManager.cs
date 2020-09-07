using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//herseyi bulusturan script
public class GameManager : MonoBehaviour
{
    //singleton pattern
    public static GameManager Instance { get; private set; }
    //Input need to reach from the InputController to the cars wheels so this is what we are gonna do here
    public InputController InputController { get; private set; }

    private void Awake()
    {
        Instance = this;
        //InputController is the children of GameManager. 
        //So this will get InputController(script) component and store it in InputController so that other scripts can use
        InputController = GetComponentInChildren<InputController>();

    }
    void Update()
    {

    }

}