using UnityEngine;

public class shooter : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    [SerializeField] GameObject gun;
     AttackerSpawner myLaneSpawner;
    Animator animator;
    GameObject projectileParent;
    const string PROJECTILE_PARENT_NAME = "Projectiles";

    // Start is called before the first frame update

    private void Start()
    {
        SetLaneSpawner();
        animator = GetComponent<Animator>();
        CreateProjectileParent();
    }

    private void CreateProjectileParent()
    {
        projectileParent = GameObject.Find(PROJECTILE_PARENT_NAME);
        if (!projectileParent)
        {
            projectileParent = new GameObject(PROJECTILE_PARENT_NAME);
        }
    }

    private void Update()
    {
        if (IsAttackerInLane())
        {
            animator.SetBool("IsAttacker", true);
        }

        else
        {
            animator.SetBool("IsAttacker", false);
        }
    }

    private void SetLaneSpawner()
    {
        AttackerSpawner [] spawners = FindObjectsOfType<AttackerSpawner>();
        foreach (AttackerSpawner spawner in spawners)
        {
            bool isCloseEnough = (Mathf.Abs(spawner.transform.position.y - transform.position.y) <= Mathf.Epsilon);
            if (isCloseEnough)
            {
                myLaneSpawner = spawner;
            }

          
        }
    }

    private bool IsAttackerInLane()
    {
        if(myLaneSpawner.transform.childCount <= 0)
        {
            return false;
        }

        else

        {
            return true;
        }
    }

    public void Fire()
    {
        GameObject newProjectile =
        Instantiate(projectile, gun.transform.position, transform.rotation);
        newProjectile.transform.parent = projectileParent.transform;
    }
}
