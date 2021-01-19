using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public interface HandlingStrategy
{
    public void handle(GameObject gameObject, GameObject explosion, Slider healthbar);
}
