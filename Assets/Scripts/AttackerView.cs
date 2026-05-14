using UnityEngine;

public class AttackerView : MonoBehaviour
{
    [SerializeField] private float distance = 10f;

    private RaycastHit2D hit;

    void FixedUpdate()
    {
        Vector2 direction = transform.right; // local 2D facing direction

        hit = Physics2D.Raycast(transform.position, direction, distance);

        if (hit.collider != null)
        {
            Debug.DrawRay(transform.position, direction * hit.distance, Color.white);
            Debug.Log("Hit it");
        }
        else
        {
            Debug.DrawRay(transform.position, direction * distance, Color.red);
            Debug.Log("Did not hit");
        }
    }
}
