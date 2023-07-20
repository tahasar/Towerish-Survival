using UnityEngine;

public class AttackCaster : MonoBehaviour
{
    public AttackManager attackManager;
    public GameObject purpleBaseAttack;
    public GameObject attackPosition;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) Attack();
    }

    public void Attack()
    {
        Instantiate(purpleBaseAttack, attackPosition.transform.position, Quaternion.identity);
    }
}