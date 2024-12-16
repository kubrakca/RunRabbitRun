using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player1;
    public Transform player2;
    public float minZoom = 5f;
    public float maxZoom = 15f;
    public float zoomSpeed = 5f;

    private Camera cam;
    private Vector3 offset;
    private float targetZoom;

    void Start()
    {
        cam = GetComponent<Camera>();
        offset = transform.position - GetCenterPoint();
        targetZoom = cam.orthographicSize;
    }

    void Update()
    {
        Vector3 centerPoint = GetCenterPoint();
        transform.position = centerPoint + offset;

        float newZoom = Mathf.Lerp(minZoom, maxZoom, GetPlayersDistance() / 10f);
        targetZoom = Mathf.Lerp(targetZoom, newZoom, Time.deltaTime * zoomSpeed);
        cam.orthographicSize = targetZoom;
    }

    Vector3 GetCenterPoint()
    {
        if (player1 == null || player2 == null)
        {
            Debug.LogError("Player references missing!");
            return Vector3.zero;
        }

        Vector3 centerPoint = (player1.position + player2.position) / 2f;
        centerPoint.y = transform.position.y;
        return centerPoint;
    }

    float GetPlayersDistance()
    {
        if (player1 == null || player2 == null)
        {
            Debug.LogError("Player references missing!");
            return 0f;
        }

        return Vector3.Distance(player1.position, player2.position);
    }
}
