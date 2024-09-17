using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectScript : MonoBehaviour
{
    private bool playerDetected;
    [SerializeField]
    Transform collectPos;
    [SerializeField]
    float width;
    [SerializeField]
    float height;

    [SerializeField]
    LayerMask whatIsPlayer;

    [SerializeField]
    AudioClip collectSound;

    counter temp;
    private Object thisObject;

    private void Start()
    {
        thisObject = GetComponent<Object>();
        temp = FindObjectOfType<counter>();
    }

    private void Update()
    {
        playerDetected = Physics2D.OverlapBox(collectPos.position, new Vector2(width, height), 5, whatIsPlayer);

        if (playerDetected == true)
        {
            AudioSource.PlayClipAtPoint(collectSound, transform.position);
            Destroy(gameObject);
            temp.collectibles--;
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(collectPos.position, new Vector3(width, height, 1));
    }
}
