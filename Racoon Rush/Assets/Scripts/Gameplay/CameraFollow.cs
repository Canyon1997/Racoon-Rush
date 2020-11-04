using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	public float followSpeed = 2f;
	public Transform followTarget;
	public Camera cam;
	public float defaultSize;
	public float zoomedSize;
	public float extraZoomedSize;

	void FixedUpdate()
    {
		Vector3 newPosition = followTarget.position;
		newPosition.z = -10f;

		if (followTarget.position.y > 6)
		{
			cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, extraZoomedSize, Time.deltaTime);
		}
		else if (followTarget.position.y > 2)
		{
			cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, zoomedSize, Time.deltaTime);
		}
		else if (cam.orthographicSize != defaultSize)
		{
			cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, defaultSize, Time.deltaTime);
		}

		transform.position = Vector3.Slerp(transform.position, newPosition, followSpeed * Time.deltaTime);
	}
}