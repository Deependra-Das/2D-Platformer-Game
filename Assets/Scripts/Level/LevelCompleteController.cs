using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCompleteController : MonoBehaviour
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
       // Debug.Log("Collision Detected");

        if (other.gameObject.GetComponent<PlayerController>() != null)
        {
            //Debug.Log("Level Completed");
            SceneManager.LoadScene("Level2");
        }
    }
  
}
