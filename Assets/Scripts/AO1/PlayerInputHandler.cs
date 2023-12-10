using UnityEngine;
using UnityEngine.UI;

public class PlayerInputHandler : MonoBehaviour
{
    [SerializeField] private Launcher Launcher;
    [SerializeField] private InputField velocityInputField;
    [SerializeField] private InputField angleInputField;
    [SerializeField] private float maxAngle = 90f;
    [SerializeField] private float minAngle = 0f;
    [SerializeField] private float maxVelocity = 30f;
    [SerializeField] private float minVelocity = 1f;

    [SerializeField] private Text validationText;

    [SerializeField] private Button launchButton;


    private void Start()
    {

         velocityInputField.onValueChanged.AddListener(OnVelocityChanged);
         angleInputField.onValueChanged.AddListener(OnAngleChanged);

        launchButton.onClick.AddListener(Launcher.LaunchProjectile);

    }
     public float ValidateVelocity(float velocity)
     {
         // < this is less then
         // > this is greatter then
         if (velocity > maxVelocity)
         {
             velocity = maxVelocity;
             validationText.gameObject.SetActive(true);
             validationText.text = "Invalid velocity: velocity must be from 1 to 30.";
         }
         else if (velocity < minVelocity)
         {
             velocity = minVelocity;
             validationText.gameObject.SetActive(true);
             validationText.text = "Invalid velocity: velocity must be from 1 to 30.";
         }
         else
         {
             validationText.gameObject.SetActive(false);

         }

         return velocity;
     }

     private void OnVelocityChanged(string value)
     {
         if(!string.IsNullOrEmpty(value))
         {
             if (float.TryParse(value, out float velocity))
             {
                 float validateVelocity = ValidateVelocity(velocity);
                 Launcher.velocity = validateVelocity;
             }
             else
                 Debug.LogWarning("Invalid input for velocity");
         }
        else
             Debug.LogWarning("velocity input is empty");
     }

     public float ValidateAngle(float angle)
     {
         if (angle > maxAngle)
         {
             angle = maxAngle;
             validationText.gameObject.SetActive(true);
             validationText.text = "Invalid angle: Angle must be from 0 to 90 degrees.";
         }
         else if (angle < minAngle)
         {
             angle = minAngle;
             validationText.gameObject.SetActive(true);
             validationText.text = "Invalid angle: Angle must be from 0 to 90 degrees.";
         }
         else
         {
             validationText.gameObject.SetActive(false);

         }

         return angle;
     }

     public void OnAngleChanged(string value)
     {
         if (!string.IsNullOrEmpty(value))
         {
             if (float.TryParse(value, out float angle))
             {
                 float validateAngle = ValidateAngle(angle);
                 Launcher.angle = validateAngle;
             }
             else
                 Debug.LogWarning("Invalid input for angle");
         }
         else
             Debug.LogWarning("angle input is empty");
     }

    public void OnFire()
    {
        string velocityInput = velocityInputField.text;
        string angleInput = angleInputField.text;

        if (!string.IsNullOrEmpty(velocityInput) && !string.IsNullOrEmpty(angleInput))
        {
            if (float.TryParse(velocityInput, out float velocity) && float.TryParse(angleInput, out float angle))
            {    
                if (velocity >= minVelocity && velocity <= maxVelocity && angle >= minAngle && angle <= maxAngle)
                {
                    Launcher.velocity = velocity;
                    Launcher.angle = angle;
                    Launcher.LaunchProjectile();
                }
                else
                {
                    Debug.LogWarning("Velocity and/or angle is not within valid range.");
                }
            }
            else
            {
                Debug.LogWarning("Invalid input for velocity and/or angle.");
            }
        }
        else
        {
            Debug.LogWarning("Velocity and/or angle input is empty.");
        }
    }
}