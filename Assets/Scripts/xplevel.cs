using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class xplevel : MonoBehaviour
{
    // XP
    public int currentXp = 6;

    // Vidas
    public int vida = 3;

    // Corações
    public GameObject coracao1;
    public GameObject coracao2;
    public GameObject coracao3;

    // Sprite do jogador
    public SpriteRenderer spriteRenderer;

    // Configuração da invencibilidade
    public float tempoInvencivel = 2f;
    public float intervaloPisca = 0.15f;

    private bool invencivel = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        // Ignora dano enquanto estiver invencível
        if (invencivel)
            return;

        if (other.CompareTag("enemy"))
        {
            enemyxp enemy = other.GetComponent<enemyxp>();

            if (currentXp > enemy.enemyXp)
            {
                currentXp += enemy.enemyXp;
                Debug.Log("XP atual: " + currentXp);

                Destroy(other.gameObject);
            }
            else
            {
                Destroy(other.gameObject);

                Debug.Log("A comida é grande demais para você!");

                vida--;
                Debug.Log("Vida: " + vida);

                // Atualiza os corações
                if (vida == 2)
                {
                    coracao1.SetActive(false);
                    StartCoroutine(PiscarInvencivel());
                }
                else if (vida == 1)
                {
                    coracao2.SetActive(false);
                    StartCoroutine(PiscarInvencivel());
                }
                else if (vida <= 0)
                {
                    coracao3.SetActive(false);
                    StartCoroutine(PiscarInvencivel());
                    SceneManager.LoadScene(0);
                    return;
                } 
            }
        }
    }

    IEnumerator PiscarInvencivel()
    {
        invencivel = true;

        Color cor = spriteRenderer.color;

        float tempo = 0f;

        while (tempo < tempoInvencivel)
        {
            // Transparente
            cor.a = 0f;
            spriteRenderer.color = cor;
            yield return new WaitForSeconds(intervaloPisca);

            // Visível
            cor.a = 1f;
            spriteRenderer.color = cor;
            yield return new WaitForSeconds(intervaloPisca);

            tempo += intervaloPisca * 2;
        }

        // Garante que termina visível
        cor.a = 1f;
        spriteRenderer.color = cor;

        invencivel = false;
    }
}