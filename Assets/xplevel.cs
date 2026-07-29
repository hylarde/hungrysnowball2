using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class xplevel : MonoBehaviour
{
    // Atributo de xp
    public int currentXp = 6;
    public int xp;
    public int vida = 3;

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

                
            }
        }

        if (vida <= 0) {

            SceneManager.LoadScene(0);

        }
    }
}



