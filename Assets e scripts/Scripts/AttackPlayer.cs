using UnityEngine;

public class AttackPlayer : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [SerializeField] private Transform pontoAtaque;
    [SerializeField] private float raioAtaque;
    [SerializeField] private LayerMask layersAtaque;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            Atacar();
        }
    }

    private void OnDrawGizmos()
    {
        if (pontoAtaque != null)
        {
            Gizmos.DrawWireSphere(pontoAtaque.position, raioAtaque);
        }
    }

    private void Atacar()
    {
        Collider2D colliderInimigo = Physics2D.OverlapCircle(pontoAtaque.position, raioAtaque, layersAtaque);
        if (colliderInimigo != null)
        {
            Debug.Log("Inimigo atingido" + colliderInimigo.name);
            //causar um dano no inimigo
            Inimigo inimigo = colliderInimigo.GetComponent<Inimigo>();
            if (inimigo != null)
            {
                inimigo.ReceberDano();
                Debug.Log("Inimigo atingido");
            }
            
        }
        else
        {
            Debug.Log("Nada atingido");
        }
    }
}
