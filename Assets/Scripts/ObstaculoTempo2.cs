using UnityEngine;
public class ObstaculoTempo2 : MonoBehaviour
{
    public GameObject prefabObstaculos;
    public float intervaloTempo = 1.5f;
    private float cronometro = 0;

    public float posicaoDireita = 3f;
    public float posicaoEsquerda = -3f;

    // Update is called once per frames
    void Update()
    {
        cronometro += Time.deltaTime;
        if (cronometro >= intervaloTempo)
        {
            cronometro = 0f;
            GerarObstaculo();
        }
    }
    void GerarObstaculo()
    {
        float posicaoX = Random.Range(posicaoEsquerda, posicaoDireita);
        Vector3 posicaoGeracao = new Vector3(posicaoX, transform.position.y, transform.position.z);
        GameObject novoObjeto = Instantiate(prefabObstaculos, posicaoGeracao, Quaternion.identity);

    }

}
