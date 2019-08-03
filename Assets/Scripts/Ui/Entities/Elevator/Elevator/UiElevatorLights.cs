using Tools.UI.Fade;

namespace SpaceMarine
{
    public class UiElevatorLights : UiBaseEntity
    {
        const float LightsOn = 0;
        const float LightsOff = 0.7f;

        FadeComponent Lights { get; set; }

        protected override void Awake()
        {
            base.Awake();
            Lights = transform.parent.GetComponentInChildren<FadeComponent>();
        }

        protected override void OnTriggerEnterPlayer()
        {
            Lights.SetAlpha(LightsOn);
        }

        protected override void OnTriggerExitPlayer()
        {
            Lights.SetAlpha(LightsOff);
        }
    }
}