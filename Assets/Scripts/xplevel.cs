using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class xplevel : MonoBehaviour
{
    // Atributo de xp
    public int currentXp = 6;
    public int xp;
    public int vida = 3;

    public GameObject coracao1;
    public GameObject coracao2;
    public GameObject coracao3;

    void OnTriggerEnter2D(Collider2D other)
    {
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
                Debug.Log("A comida é garande de mais para você");
                vida -= 1;
                Debug.Log(vida);
                if (vida == 2) {
                    coracao1.SetActive(false);
                
                }
                
                if (vida == 1)
                {
                    coracao2.SetActive(false);
                }
                
            }
        }

        if (vida <= 0) {
            coracao3.SetActive(false);
            SceneManager.LoadScene(0);

        }
    }
}



