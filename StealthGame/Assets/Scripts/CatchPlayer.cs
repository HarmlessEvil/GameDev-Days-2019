using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchPlayer : MonoBehaviour
{
    public EnemyController enemy;

    void Update()
    {
        Vector3 desiredVelocity = enemy.GetDesiredVelocity();
        if (desiredVelocity != null)
        {
            transform.rotation = Quaternion.FromToRotation(Vector3.up, enemy.GetDesiredVelocity());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == enemy.GetPlayer().gameObject)
        {
            enemy.CatchPlayer();
        }
    }
}
