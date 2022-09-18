using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
   public IEnumerator Shake(float duration, float magnitude)
    {
        Vector3 originalPos = transform.position;

        float elapsed = 0.0f;

        while (elapsed <duration)
        {
            float z = Random.Range(transform.position.z - 2f, transform.position.z + 2);
            float y = Random.Range(transform.position.y-2, transform.position.y+2);

            transform.position = new Vector3(originalPos.x, y, z);

            elapsed += Time.deltaTime;

            yield return null;
        }
        Debug.Log(originalPos);
        transform.position = originalPos;
    }

 
}
