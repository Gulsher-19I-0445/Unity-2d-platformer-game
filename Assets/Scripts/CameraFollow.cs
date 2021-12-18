using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform Player;
    private Vector3 tempPos;
    private string Player_Tag = "Player";
    [SerializeField]
    private float minX, maxX;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag(Player_Tag).transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (!Player)
        {
            return;
        }
        tempPos = transform.position;
        tempPos.x = Player.position.x;

        if (tempPos.x < minX)
        {
            tempPos.x = minX;
        }

        if (tempPos.x > maxX)
        {
            tempPos.x = maxX;
        }



        transform.position = tempPos;
    }
}
