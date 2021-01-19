using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandlingList
{
    private HandlingStrategy strategy;

    public void setHandlingStrategy(HandlingStrategy strategy)
    {
        this.strategy = strategy;
    }

    public void handle(GameObject gameObject, GameObject explosion, Slider healthbar)
    {
        strategy.handle(gameObject, explosion, healthbar);
    }
}
