using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorNext : MonoBehaviour
{
    private bool playerDetected;
    [SerializeField]
    Transform doorPos;
    [SerializeField]
    float width;
    [SerializeField]
    float height;
    
    [SerializeField]
    LayerMask whatIsPlayer;

    Transitions temp;
    public counter collect;

    private void Start()
    {
        temp = GameObject.FindGameObjectWithTag("LevelLoader").GetComponent<Transitions>();
        collect = FindObjectOfType<counter>();
    }

    private void Update()
    {
        playerDetected = Physics2D.OverlapBox(doorPos.position, new Vector2(width, height), 0,whatIsPlayer);

        if(playerDetected == true)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                if (collect.collectibles == 0)
                {
                    temp.LoadNextLevel();
                }
            }
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(doorPos.position, new Vector3(width, height, 1));
    }
}
