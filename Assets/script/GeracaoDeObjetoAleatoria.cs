using UnityEngine;

public class GeracaoDeObjetoAleatoria : MonoBehaviour
{
   public GameObject[] listaDeObstaculos;
    public float intervaloTempo = 1f;
    private float cronometro = 0;

    public float posicaoDireita = 3f;
    public float posicaoEsquerda = -3f;

    public int ContadorSpraw = 0;

    // Update is called once per frame
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
    { ContadorSpraw++;
        int limiteSorteio = 0;

        if (ContadorSpraw <= 20)
        {
            limiteSorteio = 2;
          Debug.Log("ContadorSpraw <= 20: " + ContadorSpraw);
        }

        else if (ContadorSpraw > 20 && ContadorSpraw <= 40)
        {
            limiteSorteio = 4;
            Debug.Log("ContadorSpraw > 20 && ContadorSpraw <= 40: " + ContadorSpraw);
        }
        else
        {
            limiteSorteio = listaDeObstaculos.Length;
            Debug.Log("ContadorSpraw > 40: " + ContadorSpraw);
        }
        int indiceAleatorio = Random.Range(0, limiteSorteio);
        GameObject obstaculoSorteado = listaDeObstaculos[indiceAleatorio];

        float posicaoX = Random.Range(posicaoEsquerda, posicaoDireita);
        Vector3 posicaoGeracao = new Vector3(posicaoX, transform.position.y, transform.position.z);

        GameObject novoObjeto = Instantiate(obstaculoSorteado, posicaoGeracao, Quaternion.identity);

        Destroy(novoObjeto, 5f); // Destroi o objeto após 5 segundos

    }

}
