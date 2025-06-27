using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//FloatToPlayer
public class FloatToPlayer : MonoBehaviour
{
    private GameObject player;
    public float speed;

    void Start()
    {
        player = GameObject.Find("Player");
    }

    void Update()
    {
        if (player != null)
        {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position,  speed * Time.deltaTime);
        }
    }
}