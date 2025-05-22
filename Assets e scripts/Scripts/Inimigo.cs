using UnityEngine;

public class Inimigo : MonoBehaviour
{
    [SerializeField] private int vidas = 3;
    private Spawner spawner;

    private void Start()
    {
        spawner = FindFirstObjectByType<Spawner>(); // Atualizado conforme o aviso
    }

    public void ReceberDano()
    {
        vidas--;
        Debug.Log(name + " recebeu dano, vidas restantes: " + vidas);

        if (vidas <= 0)
        {
            if (spawner != null)
            {
                spawner.SpawnInimigo(); // Chama o método de spawn
            }
            else
            {
                Debug.LogWarning("Spawner não encontrado!");
            }

            Destroy(gameObject);
        }
    }
}
