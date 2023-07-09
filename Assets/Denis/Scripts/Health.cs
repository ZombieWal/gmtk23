using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public bool player = false;
    public Image ringHealthBar;
    public GameObject deadBody;
    public float health;
    public float maxHealth = 100;

    private float lerpSpeed;

    private void Start()
    {
        health = maxHealth;
    }

    private void Update()
    {
        if (health > maxHealth) health = maxHealth;

        lerpSpeed = 3f * Time.deltaTime;

        HealthBarFiller();
        ColorChanger();

    }

    void HealthBarFiller()
    {
        ringHealthBar.fillAmount = Mathf.Lerp(ringHealthBar.fillAmount, (health / maxHealth), lerpSpeed);
    }

    void ColorChanger()
    {
        Color healthColor = Color.Lerp(Color.red, Color.green, (health / maxHealth));
        ringHealthBar.color = healthColor;
    }

    public void Damage(float damagePoints)
    {

        if (health > 0)
            health -= damagePoints;
        if (health <= 0)
        {
            Destroy(gameObject);
            Instantiate(deadBody, transform.position, transform.rotation);
            if (!player)
            {
                FindObjectOfType<FightController>().curremtPointIndex--;
            }
        }
    }

    public void Heal(float healingPoints)
    {
        if (health < maxHealth)
            health += healingPoints;
        
    }

}
