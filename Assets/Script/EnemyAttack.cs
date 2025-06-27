using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    protected GameObject player;

    public virtual void Start()
    {
        if (player == null)
        {
            player = FindObjectOfType<PlayerMovement>()?.gameObject;
        }
    }
}
