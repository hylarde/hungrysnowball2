using UnityEngine;

public class MoverECrescer : MonoBehaviour
{
    [Header("Movimento")]
    public float velocidade = 5f;

    [Header("Crescimento")]
    public Vector3 tamanhoFinal = new Vector3(2f, 2f, 1f);
    public float velocidadeCrescimento = 2f;

    void Update()
    {
        // Move o objeto para a esquerda
        transform.position += Vector3.left * velocidade * Time.deltaTime;

        // Faz o objeto crescer até o tamanho definido
        transform.localScale = Vector3.MoveTowards(
            transform.localScale,
            tamanhoFinal,
            velocidadeCrescimento * Time.deltaTime
        );
    }
}