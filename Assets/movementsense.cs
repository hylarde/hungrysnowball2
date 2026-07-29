using UnityEngine;

public class movementsense : MonoBehaviour
{
    public int speed;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0.1f, -1, 0) * speed * Time.deltaTime,Space.Self);
    }
}
