using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector3 velocity;

    // Update is called once per frame
    private void Update()
    {
        velocity = new Vector3(0, 0.1f);
        this.transform.Translate(velocity);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "asteroid")
        {
            SoundManager.PlaySound("boom1");
            Destroy(collision.gameObject);
            this.gameObject.SetActive(false);
        }
    }

    private void OnBecameInvisible()
    {
        this.gameObject.SetActive(false);
    }
}
