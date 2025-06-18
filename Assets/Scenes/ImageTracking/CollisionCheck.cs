using UnityEngine;

public class CollisionCheck : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision detected with: " + other.gameObject.name);
        transform.localScale = new Vector3(10.0f, 10.0f, 10.0f);
    }
}
