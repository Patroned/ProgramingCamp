using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cherry : MonoBehaviour
{
    public void cherryDeath()
    {
        FindObjectOfType<PlayerController>().CherryCount();
        Destroy(gameObject);

    }
}
