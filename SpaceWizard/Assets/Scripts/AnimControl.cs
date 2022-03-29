using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimControl : MonoBehaviour
{
    public GameObject thePlayer;
    void Update()
    {
        if(Input.GetButtonDown("LeftClick"))
        {
            thePlayer.GetComponent<Animator>().Play("Attack02Maintain");
        }
        if (Input.GetButtonDown("wKey"))
        {
            thePlayer.GetComponent<Animator>().Play("BattleWalkForward");
        }
        if (Input.GetButtonDown("sKey"))
        {
            thePlayer.GetComponent<Animator>().Play("BattleWalkBack");
        }
    }
}
