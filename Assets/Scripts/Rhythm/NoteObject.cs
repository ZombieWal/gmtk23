using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteObject : MonoBehaviour
{
    public bool canBePressed;
    public KeyCode keyToPress;
    private bool isDestroyed = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keyToPress))
        {
            if (canBePressed)
            {
                Debug.Log("It's a hit");
                //gameObject.SetActive(false);
                isDestroyed = true;
                Destroy(gameObject);
                RhythmGameManager.instance.NoteHit();
            }
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Arrow enters the square");

        if (other.tag == "Activator")
        {
            Debug.Log("In hit zone");
            canBePressed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Activator" && !isDestroyed)
        {
            Debug.Log("Out of hit zone, destoyed: " + isDestroyed);
            canBePressed = false;
            RhythmGameManager.instance.NoteMissed();
        }
    }
}
