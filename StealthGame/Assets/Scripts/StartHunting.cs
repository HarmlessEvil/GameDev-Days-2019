using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class StartHunting : MonoBehaviour
{
    public EnemyController enemy;

    void StartTheHunt()
    {
        enemy.StartHunting();
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
