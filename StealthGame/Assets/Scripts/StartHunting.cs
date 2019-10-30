using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartHunting : MonoBehaviour
{
    public EnemyController enemy;

    void StartTheHunt()
    {
        Vector2 direction = enemy.GetPlayer().position - transform.position;
        RaycastHit2D raycastHit = Physics2D.Raycast(
            transform.position,
            direction,
            float.PositiveInfinity,
            LayerMask.GetMask("Player", "Obstacles")
        );

        if (raycastHit && raycastHit.collider.gameObject.CompareTag("Player"))
        {
            enemy.StartHunting();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == enemy.GetPlayer().gameObject)
        {
            StartTheHunt();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject == enemy.GetPlayer().gameObject)
        {
            StartTheHunt();
        }
    }

    private void Update()
    {
        Vector3 desiredVelocity = enemy.GetDesiredVelocity();
        if (desiredVelocity != null)
        {
            transform.rotation = Quaternion.FromToRotation(Vector3.up, enemy.GetDesiredVelocity());
        }
    }
}
