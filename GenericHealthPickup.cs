using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericHealthPickup : MonoBehaviour, IMovePattern
{
    //public Texture pickupTexture;

    [Header("Bonus to health of reciever!")]
    public int healthBoost;

    public Vector3 Move(Vector3 position, float deltaTime)
    {
        throw new System.NotImplementedException();
    }

    private void OnEnable()
    {
        //if (pickupTexture == null)
        //{
        //    this.gameObject.GetComponent<Texture>();
        //}        
    }

    private void OnTriggerEnter(Collider other)
    {
        GrantBonus(other);
    }

    public void GrantBonus(Collider other)
    {
        Debug.Log("GrantBonus ran!");
        if (other.gameObject.GetComponent<HealthSystem>() != null)
        {
            HealthSystem healthToReplenish = other.GetComponent<HealthSystem>();

            healthToReplenish.TakeDamage(-healthBoost);
            Debug.Log("Player got a health relief size " + healthBoost);
            gameObject.SetActive(false);
        }
    }
}
