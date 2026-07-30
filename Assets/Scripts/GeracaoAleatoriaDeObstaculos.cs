using UnityEngine;

public class GeracaoAleatoriaDeObstaculos2 : MonoBehaviour
{
    public GameObject prefabObstaculos;
    public float intervaloTempo = 1.5f;
    private float cronometro = 0;

    public float posicaoDireita = 3f;
    public float posicaoEsquerda = -3f;

    // Update is called once per frame
    void Update()
    {
        cronometro += Time.deltaTime;
        if (cronometro >= intervaloTempo)
        {
            cronometro = 0;
            GerarObstaculo();
        }
    }
    void GerarObstaculo()
    {
        float posicaoX = Random.Range(posicaoEsquerda, posicaoDireita);
        Vector3 posicaoGeracao = new Vector3(posicaoX, transform.position.y, transform.position.z);
        Instantiate(prefabObstaculos, posicaoGeracao, Quaternion.identity);
    }

}
