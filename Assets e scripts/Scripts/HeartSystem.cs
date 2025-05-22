using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HeartSystem : MonoBehaviour
{

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    PlayerLogic player;
    public bool isDead;
    public int vida;
    public int vidaMaxima;

    public Image[] coracao;
    public Sprite coracaoCheio;
    public Sprite coracaoVazio;

    void Start()
    {
        player = GetComponent<PlayerLogic>();
    }

    // Update is called once per frame
    void Update()
    {
        HealthLogic();
        DeadState();
    }

    void HealthLogic()
    {
        for (int i = 0; i < coracao.Length; i++)
        {
            if (vida > vidaMaxima)
            {
                vida = vidaMaxima;
            }

            if (i < vida)
            {
                coracao[i].sprite = coracaoCheio;
            }
            else
            {
                coracao[i].sprite = coracaoVazio;
            }

            if (i < vidaMaxima)
            {
                coracao[i].enabled = true;
            }
            else
            {
                coracao[i].enabled = false;
            }
        }
    }

    void DeadState()
    {
        if (isDead) return; // Se já morreu, não executa novamente

        if (vida <= 0)
        {
            isDead = true;
            player.anim.SetTrigger("Die"); // Dispara animação de morte uma única vez

            GetComponent<PlayerLogic>().enabled = false;
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
            GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
            GetComponent<BoxCollider2D>().enabled = false;
            Invoke("LoadScene", 2f); // Chama o método LoadScene após 2 segundos
        }
    }

    void LoadScene()
    {
        SceneManager.LoadScene("GameOver");
    }


}
