using UnityEngine;
public class ExampleClass : MonoBehaviour
{
    public float speed = 5f;

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");

        transform.Translate(new Vector3(horizontal, 0f, 0f) * speed * Time.deltaTime);
    }
}