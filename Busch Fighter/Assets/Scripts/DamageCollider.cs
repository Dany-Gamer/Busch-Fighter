using UnityEngine;

public class DamageCollider : MonoBehaviour
{
      private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        FindObjectOfType<LivesDisplay>().TakeLife();
        Destroy(otherCollider.gameObject);
    }
}
