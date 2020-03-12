using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundScroll : MonoBehaviour
{
    
    private MeshRenderer ms;
    private float scroll_speed = 0.2f;
    public void Awake()
    {
        
        
        ms = GetComponent<MeshRenderer>();
    }

    public void Scroll()
    {
        Vector2 offset = ms.sharedMaterial.GetTextureOffset("_MainTex");
        offset.y -= Time.deltaTime * scroll_speed;
        ms.sharedMaterial.SetTextureOffset("_MainTex", offset);
    }
    void Update()
    {
        Scroll();
    }
}
