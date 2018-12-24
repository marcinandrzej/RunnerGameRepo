using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public void ChangeColor(LayerMask mask,Color32 color)
    {
        transform.GetComponent<SpriteRenderer>().color = color;
        gameObject.layer = (int)Mathf.Log(mask.value, 2);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        transform.GetComponentInParent<GameManagerRG>().End();
    }
}
