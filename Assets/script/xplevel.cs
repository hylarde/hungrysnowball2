using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Threading.Tasks;

public class xplevel : MonoBehaviour
{
    // XP
    public int currentXp = 6;
    public int xp;

    // Vidas
    public int vida = 3;

    // Corações
    public GameObject coracao1;
    public GameObject coracao2;
    public GameObject coracao3;

    public TMP_Text texto;

    public float tempo = 0f;

    // Sprite do jogador
    public SpriteRenderer spriteRenderer;

    // Configuração da invencibilidade
    public float tempoInvencivel = 2f;
    public float intervaloPisca = 0.15f;

    private bool invencivel = false;

    private bool cresceu = false;

    private int nivelCrescimento = 0;

    IEnumerator DesativarTexto()
    {
        yield return new WaitForSeconds(1f);
        texto.gameObject.SetActive(false);
    }

    private void Start()
    {
        texto.gameObject.SetActive(false);
    }



    async Task OnTriggerEnter2D(Collider2D other)
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
                VerificarCrescimento();

                Debug.Log("XP atual: " + currentXp);
                texto.text = "+ " + enemy.enemyXp + " xp";
                texto.gameObject.SetActive(true);
                StartCoroutine(DesativarTexto());


                Destroy(other.gameObject);
            }
            else
            {
                Destroy(other.gameObject);

                Debug.Log("A comida é grande demais para você!");

                vida -= 1;
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
        if (other.CompareTag("montanha"))
        {
            enemyxp montanha = other.GetComponent<enemyxp>();

            // Pega o XP da montanha (500)
            int xpMontanha = montanha != null ? montanha.enemyXp : 1100;

            if (currentXp > xpMontanha)
            {
                Debug.Log("Parabéns! Você ganhou!");
                texto.text = "Parabéns! Você ganhou!";
                texto.gameObject.SetActive(true);
                await System.Threading.Tasks.Task.Delay(2000); // Aguarda 2 segundos antes de carregar a próxima cena
                SceneManager.LoadScene(0); // Carrega a próxima cena (substitua "NomeDaProximaCena" pelo nome real da cena)
                return;
                // Opcional: Destrói a montanha para indicar que passou por ela
                Destroy(other.gameObject);
            }
            else
            {
                Debug.Log("Você perdeu!");
                texto.text = "Você perdeu!";
                texto.gameObject.SetActive(true);
                 // Zera as vidas e desativa os corações
                vida = 0;
                if (coracao1 != null) coracao1.SetActive(false);
                if (coracao2 != null) coracao2.SetActive(false);
                if (coracao3 != null) coracao3.SetActive(false);
                await System.Threading.Tasks.Task.Delay(2000); // Aguarda 2 segundos antes de carregar a próxima cena
                SceneManager.LoadScene(0); // Carrega a próxima cena (substitua "NomeDaProximaCena" pelo nome real da cena)
                return;
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
    void VerificarCrescimento()
    {
        switch (nivelCrescimento)
        {
            case 0:
                if (currentXp >= 10)
                {
                    transform.localScale = new Vector3(1.8f, 1.8f, 1f);
                    Camera.main.orthographicSize = 2f;
                    nivelCrescimento++;
                }
                break;

            case 1:
                if (currentXp >= 85)
                {
                    transform.localScale = new Vector3(2.2f, 2.2f, 1f);
                    nivelCrescimento++;
                }
                break;

            case 2:
                if (currentXp >= 150)
                {
                    transform.localScale = new Vector3(5f, 5f, 1f);
                    Camera.main.orthographicSize = 3f;
                    nivelCrescimento++;
                }
                break;

            case 3:
                if (currentXp >= 1000)
                {
                    transform.localScale = new Vector3(8f, 8f, 1f);
                    Camera.main.orthographicSize = 4f;
                    nivelCrescimento++;
                }
                break;
        }
    }
}     