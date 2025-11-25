using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{
    public float walkSpeed = 3.5f;
    public float runSpeed = 9f;
    public float maxStamina = 100f;
    public float drainPerSecond = 20f;
    public float regenPerSecond = 10f;
    public Slider staminaBar;

    float currentStamina;


    void Start()
    {
        currentStamina = maxStamina;
        staminaBar.maxValue = maxStamina;
    }

    void Update()
    {
        bool isSprinting = Input.GetKey(KeyCode.LeftShift) && currentStamina > 0;
        float speed = isSprinting ? runSpeed : walkSpeed;

        
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        
        if (isSprinting)
        {
            currentStamina -= drainPerSecond * Time.deltaTime;
        }
        else
        {
            currentStamina += regenPerSecond * Time.deltaTime;
        }

        currentStamina = Mathf.Clamp(currentStamina, 0, maxStamina);
        staminaBar.value = currentStamina;
    }
}
