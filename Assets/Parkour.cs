using UnityEngine;
using System.Collections;

public class Parkour : MonoBehaviour
{
    public Transform ledgeCheck;
    public LayerMask climbableLayer;
    public float climbHeight = 2f;
    public float climbSpeed = 3f;

    void Update()
    {
        if (Physics.Raycast(ledgeCheck.position, transform.forward, 1f, climbableLayer))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                StartCoroutine(ClimbLedge());
            }
        }
    }

    IEnumerator ClimbLedge()
    {
        float elapsedTime = 0f;
        Vector3 start = transform.position;
        Vector3 end = transform.position + Vector3.up * climbHeight;

        while (elapsedTime < 1f)
        {
            transform.position = Vector3.Lerp(start, end, elapsedTime);
            elapsedTime += Time.deltaTime * climbSpeed;
            yield return null;
        }
    }
}
