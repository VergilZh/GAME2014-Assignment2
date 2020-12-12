using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulsBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if(other.gameObject.GetComponent<PlayerBehaviour>().playerHealth < 4)
            {
                other.gameObject.GetComponent<PlayerBehaviour>().playerHealth += 1;
                Score.gameScore += 10;
                Destroy(gameObject);
            }
            
        }
    }
}
