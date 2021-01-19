using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LossHandling : MonoBehaviour, HandlingStrategy
{
    public async void handle(GameObject gameObject, GameObject explosion, Slider healthbar)
    {
        SoundManager.PlaySound("boom2");
        Instantiate(explosion, gameObject.transform.position, Quaternion.identity);
        Destroy(healthbar.gameObject, 0.1f);
        Destroy(gameObject, 0.1f);

        await Task.Delay(2000);
        SceneManager.LoadScene("MainMenu");
    }
}
