using UnityEngine;

public class Axe : MonoBehaviour
{
    float rotationSpeed = 360f;
    float translationSpeed = 5f;
    [SerializeField] float damage = 50;



    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right *translationSpeed *Time.deltaTime,Space.World);
        transform.Rotate(Vector3.back*rotationSpeed *Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        var health = otherCollider.GetComponent<Health>();
        var attacker = otherCollider.GetComponent<Attacker>();

        if (attacker && health)
        {
            health.DamageDeal(damage);
            Destroy(gameObject);
        }
    }


}
