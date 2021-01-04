using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ship : MonoBehaviour
{
    public float speed = 10.0f;
    public GameObject bullet;
    public Slider healthbar;
    public GameObject explosion;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "asteroid")
        {
            healthbar.value -= 0.34f;
            if (healthbar.value <= 0)
            {
                Instantiate(explosion, this.transform.position, Quaternion.identity);
                Destroy(healthbar.gameObject, 0.1f);
                Destroy(this.gameObject, 0.1f);
            }
        }
    }

    // Update is called once per frame
    private void Update()
    {
        float translation = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        transform.Translate(new Vector3(translation, 0, 0));

        if (Input.GetKeyDown("space"))
        {
            //Instantiate(bullet, this.transform.position, Quaternion.identity);
            GameObject obj = Pool.sigleton.Get("bullet");
            if (obj)
            {
                obj.transform.position = this.transform.position;
                obj.SetActive(true);
            }
        }

        Vector3 screenPos = Camera.main.WorldToScreenPoint(this.transform.position) + new Vector3(0, -100, 0);
        healthbar.transform.position = screenPos;
    }
}
