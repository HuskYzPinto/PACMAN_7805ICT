using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddDot : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform prefab;
    public Transform parent;
    public Vector2 point;
    public LayerMask map;
    public LayerMask map2;
    void Start(){
        
        Transform dot;
        LayerMask layers;
        layers = map.value | map2.value;
        for (int x = 0; x <27; x++){
            for (int y = 0; y < 30; y++){
                point = new Vector2(1+x,1+y);
                if (!Physics2D.OverlapBox(point, new Vector2(1,1), 0f, layers)){
                    dot = Instantiate(prefab, new Vector2(1+x*1.0F, 1+y*1.0F), Quaternion.identity);
                    dot.SetParent(parent);
                }
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
