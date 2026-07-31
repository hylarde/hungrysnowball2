using UnityEngine;
// Inimigo que se move em um ângulo de 25 graus e cresce até um tamanho definido
public class MoverECrescer : MonoBehaviour
{
    [Header("Movimento")]
    public float velocidade = 5f;
    public float angulo = 25f;

    [Header("Crescimento")]
    public Vector3 tamanhoFinal = new Vector3(2f, 2f, 1f);
    public float velocidadeCrescimento = 0.3f;

    private Vector3 direcao;

    void Start()
    {
        // Cria a direção inclinada
        direcao = Quaternion.Euler(0, 0, angulo) * Vector3.down;
    }

    void Update()
    {
        // Move o objeto em um ângulo de 25 graus
        transform.position += direcao * velocidade * Time.deltaTime;

        // Faz o objeto crescer até o tamanho definido
        transform.localScale = Vector3.MoveTowards(
            transform.localScale,
            tamanhoFinal,
            velocidadeCrescimento * Time.deltaTime
        );

        // Destrói quando sair da tela
        if (transform.position.y < -6f)
        {
            Destroy(gameObject);
        }
    }
}