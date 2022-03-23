using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tetrot : MonoBehaviour
{
    public float temps;
    public float tempsdechute = 0.5f;
    public static int largeur = 10;
    public static int longeur = 20;
    // Start is called before the first frame update
    void Start()
    {

    

}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.position += new Vector3(-1,0,0);
        }else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.position += new Vector3(1, 0, 0);

        }

        if (Time.time - temps > tempsdechute)
        {
            transform.position += new Vector3(0,-1,0);
            temps=Time.time;
        }
    }
}
    



