using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class GameManager : MonoBehaviour
{
    public GameObject stick;

    //0 : 대기, 1 : 진행, 2 : 종료
    public String[] moveStatus = new String[] {"Wait", "Move", "End"};

    String rightMove;
    String upMove;
    String space;

    // Start is called before the first frame update
    void Start()
    {
        rightMove = moveStatus[0];
        upMove = moveStatus[0];
        space = moveStatus[0];
    }

    // Update is called once per frame
    void Update()
    {
        //x, z, y 
        Vector3 stickPos = stick.transform.position; 

        // 대기 -> 진행 상태로 변경
        if (Input.GetKey(KeyCode.RightArrow) && rightMove.Equals(moveStatus[0])) 
        {
            rightMove = moveStatus[1];
        } 
        if (Input.GetKey(KeyCode.UpArrow) && upMove.Equals(moveStatus[0]) && rightMove.Equals(moveStatus[1])) 
        {
            rightMove = moveStatus[2];
            upMove = moveStatus[1];
        }
        if (Input.GetKey(KeyCode.Space) && space.Equals(moveStatus[0]) && upMove.Equals(moveStatus[1])) 
        {
            upMove = moveStatus[2];
            space = moveStatus[1];
        }
        
        if (rightMove.Equals(moveStatus[1])) {
            stick.transform.Translate(0.007f, 0, 0);
        }
        if (upMove.Equals(moveStatus[1])) {
            stick.transform.Translate(0, 0, -0.007f);
        }
        if (space.Equals(moveStatus[1]) && stickPos.z < 5) {
            stick.transform.Translate(0, 0.007f, 0);
        }
    }
}
