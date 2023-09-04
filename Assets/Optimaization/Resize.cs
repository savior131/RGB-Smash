using UnityEngine;

public class SpriteScaler : MonoBehaviour
{
    Vector3 initialScale;
    SpriteRenderer spriteRenderer;
    [SerializeField] float offset;
    [SerializeField] bool sliced;
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        initialScale = transform.localScale;
    }

    private void Update()
    {
        float cameraWidth = Camera.main.orthographicSize * 2f * Camera.main.aspect;
        if (sliced)
        {
            spriteRenderer.size = new(cameraWidth + offset, spriteRenderer.size.y);
        }
        else
        {
            float scaleX = cameraWidth + offset;
            transform.localScale = new Vector3(scaleX, transform.localScale.y, transform.localScale.z);
        }
    }
}
