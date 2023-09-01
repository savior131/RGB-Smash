
using UnityEngine;

public class CameraCollision : MonoBehaviour
{
    public Camera mainCamera;
    public BoxCollider2D topCollider;
    public BoxCollider2D bottomCollider;
    public BoxCollider2D leftCollider;
    public BoxCollider2D rightCollider;

    public float heightOffset = 0.01f;
    public float widthOffset = 0.01f;
    private void Start()
    {
        AdjustColliders();
    }

    private void AdjustColliders()
    {
        float cameraHeight = mainCamera.orthographicSize * 2f;
        float cameraWidth = cameraHeight * mainCamera.aspect;
        Vector2 cameraPosition = mainCamera.transform.position;

        float halfHeight = (cameraHeight / 2f) - heightOffset;
        float halfWidth = (cameraWidth / 2f) - widthOffset;

        topCollider.offset = new Vector2(cameraPosition.x, cameraPosition.y + halfHeight);
        topCollider.size = new Vector2(cameraWidth, 1f);

        bottomCollider.offset = new Vector2(cameraPosition.x, cameraPosition.y - halfHeight);
        bottomCollider.size = new Vector2(cameraWidth, 1f);

        leftCollider.offset = new Vector2(cameraPosition.x - halfWidth, cameraPosition.y);
        leftCollider.size = new Vector2(1f, cameraHeight);

        rightCollider.offset = new Vector2(cameraPosition.x + halfWidth, cameraPosition.y);
        rightCollider.size = new Vector2(1f, cameraHeight);
    }
}

