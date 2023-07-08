using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boom : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        float c = Random.Range(0.1f, 0.15f);
        Invoke("Color_white", c);
        float r = Random.Range(0.15f,0.3f);
        Invoke("BoomRip", r);
        FindObjectOfType<AudioManager>().Play("boom");
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(transform.localScale.x + 0.1f, transform.localScale.y + 0.1f, transform.localScale.z), 0.1f);
    }

    public void Color_white()
    {
        GetComponent<SpriteRenderer>().color = Color.white;
    }

    public void BoomRip()
    {
        Destroy(gameObject);
    }
}
