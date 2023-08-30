using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    private Vector3 originalPosition;
    private Coroutine shakeCoroutine;

    private void Awake()
    {
        originalPosition = transform.localPosition;
    }

    public void Shake(float duration, float magnitude, float speed)
    {
        if (shakeCoroutine != null)
        {
            StopCoroutine(shakeCoroutine);
        }

        shakeCoroutine = StartCoroutine(ShakeCamera(duration, magnitude, speed));
    }

    private IEnumerator ShakeCamera(float duration, float magnitude, float speed)
    {
        float elapsed = 0f;

        while (elapsed < duration)
        {
            // Generate random values for x and y axis offsets
            float offsetX = Random.Range(-1f, 1f) * magnitude;
            float offsetY = Random.Range(-1f, 1f) * magnitude;

            // Create a new shake position based on the original position and offsets
            Vector3 shakePosition = originalPosition + new Vector3(offsetX, offsetY, 0f);

            // Apply the shake position to the camera
            transform.localPosition = Vector3.Lerp(transform.localPosition, shakePosition, speed * Time.deltaTime);

            elapsed += Time.deltaTime;

            yield return null;
        }

        // Reset the camera position to the original position
        transform.localPosition = originalPosition;
    }
}
