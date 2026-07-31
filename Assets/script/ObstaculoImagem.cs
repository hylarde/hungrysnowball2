using UnityEditor.Connect;
using UnityEngine;

public class ObstaculoImagem : MonoBehaviour
{
    public GameObject[] listaDeObstaculos;
    public int ContadorSpraw;
    public int indiceAleatorio;

   public void EscolherObstaculoAleatorio()
    {
        if (ContadorSpraw < 20)
        {
            indiceAleatorio = Random.Range(0, 1);
            Instantiate(listaDeObstaculos[indiceAleatorio], transform.position, Quaternion.identity);
        }

        else if (ContadorSpraw > 20 && ContadorSpraw < 40) 
            {
                indiceAleatorio = Random.Range(0, 3);
                Instantiate(listaDeObstaculos[indiceAleatorio], transform.position, Quaternion.identity);
            }
        else
            {
                indiceAleatorio = Random.Range(0, 5);
                Instantiate(listaDeObstaculos[indiceAleatorio], transform.position, Quaternion.identity);
            }
        ContadorSpraw++;
        }



}
