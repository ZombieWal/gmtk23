using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandMovement : MonoBehaviour
{
    public float startTime = 3f;
    public float movementTime;
    public string handType;
    public GameObject testCard;

    IEnumerator PlaceCard(GameObject card, Vector3 targetPosition)
    {
        float elapsedTime = 0.0f;
        Vector3 cardPos = card.transform.position - new Vector3(0.0f,2.0f,0.0f);
        Vector3 startPos = transform.position;

        Debug.Log("card position is"+cardPos);

        while (elapsedTime < startTime)
        {
            transform.position = Vector3.Lerp(startPos, cardPos, elapsedTime / startTime);
            elapsedTime += Time.deltaTime;
            Debug.Log("first move card position is" + cardPos);
            yield return new WaitForEndOfFrame();
        }
        transform.position = cardPos;

        elapsedTime = 0.0f;
        while (elapsedTime < movementTime)
        {
            transform.position = Vector3.Lerp(cardPos, targetPosition, elapsedTime / movementTime);
            elapsedTime += Time.deltaTime;
            Debug.Log("second move card position is" + cardPos);
            yield return new WaitForEndOfFrame();
        }
        transform.position = targetPosition;
    }

    //delete later
    private void Start()
    {
        StartCoroutine(PlaceCard(testCard, new Vector3(0.0f,-2.6f,0.0f)));
        StartCoroutine(RemoveCard(testCard, new Vector3(0.0f, -2.6f, 0.0f)));
    }

    IEnumerator RemoveCard(GameObject card, Vector3 targetPosition)
    {
        Destroy(card);
        float elapsedTime = 0.0f;
        Vector3 startPos = transform.position;

        while (elapsedTime < startTime)
        {
            transform.position = Vector3.Lerp(startPos, targetPosition, elapsedTime / startTime);
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        transform.position = targetPosition;
    }
}
