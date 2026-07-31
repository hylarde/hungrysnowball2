using UnityEngine;

public class ExampleClass : MonoBehaviour
{
    public float speed = 5f;

    // Limites da movimentação
    public float limiteEsquerda = -5f;
    public float limiteDireita = 5f;

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");

        // Move o jogador
        transform.Translate(new Vector3(horizontal, 0f, 0f) * speed * Time.deltaTime);

        // Limita a posição no eixo X
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, limiteEsquerda, limiteDireita);
        transform.position = pos;
    }
}