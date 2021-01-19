using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;

public class Ship : MonoBehaviour
{
    public float speed = 10.0f;
    public GameObject bullet;
    public Slider healthbar;
    public GameObject explosion;

    HandlingList handlingList = new HandlingList();

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
                SoundManager.PlaySound("shoot");

                obj.transform.position = this.transform.position;
                obj.SetActive(true);
            }
        }

        Vector3 screenPos = this.transform.position + new Vector3(0.09f, -0.4f, 0);
        healthbar.transform.position = screenPos;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "asteroid")
        {
            SoundManager.PlaySound("boom1");
            healthbar.value -= 0.34f;

            if (healthbar.value <= 0)
            {
                //SoundManager.PlaySound("boom2");
                //Instantiate(explosion, this.transform.position, Quaternion.identity);
                //Destroy(healthbar.gameObject, 0.1f);
                //Destroy(this.gameObject, 0.1f);

                //await Task.Delay(2000);
                //SceneManager.LoadScene("MainMenu");

                handlingList.setHandlingStrategy(new LossHandling());
                handlingList.handle(this.gameObject, explosion, healthbar);
            }
        }
    }
}
