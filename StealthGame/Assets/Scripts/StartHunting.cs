using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartHunting : MonoBehaviour
{
    public EnemyController enemy;

    void StartTheHunt()
    {
        Vector3 direction = enemy.GetPlayer().position - transform.position + Vector3.up;
        Ray ray = new Ray(transform.position, direction);
        RaycastHit raycastHit;

        if (Physics.Raycast(ray, out raycastHit))
        {
            if (raycastHit.collider.transform == enemy.GetPlayer())
            {
                enemy.StartHunting();
            }
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
