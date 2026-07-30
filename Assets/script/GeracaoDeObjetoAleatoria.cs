using UnityEngine;

public class GeracaoDeObjetoAleatoria : MonoBehaviour
{
    public GameObject[] listaDeObstaculos;
    public GameObject linhadearvores;
    public Vector3 posicaoarvore;
    public Vector3 posicaoarvore2;
    public float cronometroarvore = 0;
    public float intervaloarvore = 3;
    public float intervaloTempo = 1f;
    private float cronometro = 0;

    public float posicaoDireita = 3f;
    public float posicaoEsquerda = -3f;

    public int ContadorSpraw = 0;
    private int ordemAtual;

    // Update is called once per frame
    void Update()
    {
        cronometro += Time.deltaTime;
        if (cronometro >= intervaloTempo)
        {
            cronometro = 0f;
            GerarObstaculo();
        }
        cronometroarvore += Time.deltaTime;
        if (cronometroarvore >= intervaloarvore)
        {
            cronometroarvore = 0f;
            GerarArvore();
        }
    }
    void GerarObstaculo()
    {
        ContadorSpraw++;
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

    void GerarArvore()
    {
        GameObject novoObjeto = Instantiate(linhadearvores, posicaoarvore, Quaternion.identity);
        GameObject novoObjeto2 = Instantiate(linhadearvores, posicaoarvore2, Quaternion.identity);

        // Altera todos os SpriteRenderers da primeira árvore
        SpriteRenderer[] sprites1 = novoObjeto.GetComponentsInChildren<SpriteRenderer>();
        foreach (SpriteRenderer sr in sprites1)
        {
            sr.sortingOrder = ordemAtual;
        }

        // Altera todos os SpriteRenderers da segunda árvore
        SpriteRenderer[] sprites2 = novoObjeto2.GetComponentsInChildren<SpriteRenderer>();
        foreach (SpriteRenderer sr in sprites2)
        {
            sr.sortingOrder = ordemAtual - 1;
        }

        ordemAtual -= 2;
    }
}
