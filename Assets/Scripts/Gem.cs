using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour
{
    public void gemDeath()
    {
        FindObjectOfType<PlayerController>().GemCount();
        Destroy(gameObject);

    }
}
