using UnityEngine;

public class TriggerDamage : MonoBehaviour
{
    public HeartSystem heart;
    public PlayerLogic player;

  private void Start()
{
    if (player == null)
        player = FindFirstObjectByType<PlayerLogic>();
    if (heart == null)
        heart = FindFirstObjectByType<HeartSystem>();
}

  private void OnCollisionEnter2D(Collision2D collision)
  {
    if (collision.gameObject.CompareTag("Player"))
    {
      if (player != null && heart != null)
      {
        // Knockback
        player.KBCount = player.KBTime;
        player.isKnockRight = collision.transform.position.x <= player.transform.position.x;

        // Dano
        heart.vida -= 1;
        player.anim.SetTrigger("TakeDamage");
      }
      else
      {
        Debug.LogWarning("Player ou Heart não estão atribuídos no TriggerDamage!");
      }
    }
  }
}
