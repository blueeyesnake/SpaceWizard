using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimControl : MonoBehaviour
{
    public GameObject thePlayer;
    void Update()
    {
        if (Input.GetButtonDown("LeftClick"))
        {
            thePlayer.GetComponent<Animator>().Play("Attack02Maintain");
        }
        if (Input.GetButtonUp("LeftClick"))
        {
            thePlayer.GetComponent<Animator>().Play("BattleWalkForward");
        }
        if (Input.GetButtonDown("wKey") && !Input.GetButton("LeftClick"))
        {
            thePlayer.GetComponent<Animator>().Play("BattleWalkForward");
        }
        if (Input.GetButtonDown("sKey") && !Input.GetButton("LeftClick"))
        {
            thePlayer.GetComponent<Animator>().Play("BattleWalkBack");
        }
        if (!Input.anyKey)
        {
            thePlayer.GetComponent<Animator>().Play("Idle01");
        }
    }
}
