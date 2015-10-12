using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {
	public int maxHealth;
    Animator anim;
    public int MaxHealth {
				get { return currentHealth; }
		}
    
  

    bool fourhealth;
    bool threehealth;
    bool twohealth;
    bool onehealth;

    void awake()
    {
        
    }
    public void SetMaxHealth(int setAmount)
	{
			maxHealth = setAmount;
	}
	public int currentHealth;
    
	public void ModifyHealth(int modifyAmount)
	{
				currentHealth += modifyAmount;
				if (currentHealth < 1) {
						currentHealth = 0;
					
						//player dies code
				} else if (currentHealth > maxHealth) {
						currentHealth = maxHealth;
				}
		}
   
	void Start()
	{
		SetMaxHealth (5);
		ModifyHealth (5);
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        if(currentHealth == 4)
        {
            anim.SetBool("fourhealth", true);
        }
        if (currentHealth == 3)
        {
            anim.SetBool("threehealth", true);
        }
        if (currentHealth == 2)
        {
            anim.SetBool("twohealth", true);
        }
        if (currentHealth == 1)
        {
            anim.SetBool("onehealth", true);
        }
    }
}
