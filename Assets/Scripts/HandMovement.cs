using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandMovement : MonoBehaviour
{
    public float startTime = 3f;
    public float movementTime;
    public string handType;
    public GameObject testCard;
    private Vector3 initialPosition;

    public IEnumerator PlaceCard(GameObject card, Vector3 targetPosition)
    {
        float elapsedTime = 0.0f;
        Vector3 cardPos = card.transform.position - new Vector3(0.0f, 2.0f, 0.0f);
        Vector3 startPos = transform.position;
        initialPosition = startPos;

        //Debug.Log("card position is"+cardPos);

        while (elapsedTime < startTime)
        {
            transform.position = Vector3.Lerp(startPos, cardPos, elapsedTime / startTime);
            elapsedTime += Time.deltaTime;
            //Debug.Log("first move card position is" + cardPos);
            yield return new WaitForEndOfFrame();
        }
        transform.position = cardPos;

        Vector3 cardTargetPosition = new Vector3(targetPosition.x, targetPosition.y+2.0f, card.transform.position.z );
        Vector3 cardInitialPosition = card.transform.position;

        elapsedTime = 0.0f;

        while (elapsedTime < movementTime)
        {
            transform.position = Vector3.Lerp(cardPos, targetPosition, elapsedTime / movementTime);
            card.transform.position = Vector3.Lerp(cardInitialPosition, cardTargetPosition, elapsedTime / movementTime);
            elapsedTime += Time.deltaTime;
            //Debug.Log("second move card position is" + cardPos);
            yield return new WaitForEndOfFrame();
        }

        transform.position = targetPosition;
        card.transform.position = cardTargetPosition;
        //StartCoroutine(RemoveCard(testCard, initialPosition));

        elapsedTime = 0.0f;

        while (elapsedTime < startTime)
        {
            transform.position = Vector3.Lerp(targetPosition, initialPosition, elapsedTime / startTime);
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        transform.position = initialPosition;
    }

    //delete later
    private void Start()
    {
        //StartCoroutine(PlaceCard(testCard, new Vector3(0.0f,-2.6f,0.0f)));
    }

    public IEnumerator RemoveCard(GameObject card)
    {
        Debug.Log("initial position"+initialPosition);

        float elapsedTime = 0.0f;
        Vector3 startPos = transform.position;
        Vector3 cardStartPos = card.transform.position;

        Vector3 cardTargetPosition = new Vector3(startPos.x, startPos.y+2.0f, card.transform.position.z);

        while (elapsedTime < startTime)
        {
            transform.position = Vector3.Lerp(startPos,cardStartPos - new Vector3(0.0f, 2.0f, 0.0f), elapsedTime / startTime);
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        transform.position = cardStartPos - new Vector3(0.0f, 2.0f, 0.0f);

        while (elapsedTime < startTime)
        {
            transform.position = Vector3.Lerp(cardStartPos - new Vector3(0.0f, 2.0f, 0.0f), startPos, elapsedTime / startTime);
            card.transform.position = Vector3.Lerp(cardStartPos, cardTargetPosition, elapsedTime / startTime);
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        transform.position = startPos;
        card.transform.position = cardTargetPosition;
    }
}
