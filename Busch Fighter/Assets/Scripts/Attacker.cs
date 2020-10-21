using UnityEngine;

public class Attacker : MonoBehaviour
{
    [Range(0f, 5f)]
    [SerializeField] float currentSpeed;
    GameObject currentTarget;

    private void Awake()
    {
        FindObjectOfType<LevelController>().AttackerSpawned();
    }

    public void OnDestroy()
    {
        LevelController levelController = FindObjectOfType<LevelController>();
        if(levelController != null)
        {
            levelController.AttackerKilled();
        }
    }

    void Update()
    {
        transform.Translate(Vector2.left * currentSpeed * Time.deltaTime);
        UpdateAnimationState();
    }

    public void SetMovementSpeed(float speed)
    {
        currentSpeed = speed;
    }

    private void UpdateAnimationState()
    {
        if (!currentTarget)
        {
            GetComponent<Animator>().SetBool("IsAttacker", false);
        }
    }

    public void Attack(GameObject target)
    {
        GetComponent<Animator>().SetBool("IsAttacker", true);
        currentTarget = target;
    }

   
    public void StrikeCurrentTarget(float damage)
    {
        if(!currentTarget) { return; }
        Health health = currentTarget.GetComponent<Health>();
        Defender defender = currentTarget.GetComponent<Defender>();
        if (health && defender)
        {
            health.DamageDeal(damage);
        }
    }
}
