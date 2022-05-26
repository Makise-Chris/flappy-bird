using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScaler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        Vector3 tempscale = transform.localScale;

        float height=sr.bounds.size.y;
        float width=sr.bounds.size.x;

        float bgHeight = Camera.main.orthographicSize * 2f;
        float bgWidth = bgHeight * Screen.width/Screen.height;

        tempscale.y = bgHeight / height;
        tempscale.x = bgWidth / width;

        transform.localScale = tempscale;
    }
}
