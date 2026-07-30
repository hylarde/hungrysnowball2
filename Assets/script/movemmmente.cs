using UnityEngine;

public class movemmmente : MonoBehaviour
{
    public int speed;


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Input.GetAxis("Horizontal");
        
    }
}