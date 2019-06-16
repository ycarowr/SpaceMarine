using Patterns;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Tools.UI.Fade
{
    public class Fade : SingletonMB<Fade>
    {
        [Range(1, 100f)] public float Speed;
        public SpriteRenderer Renderer;

        private const float maxDelta = 0.01f;
        private bool IsFading { get; set; }

        private Color Current => Renderer.color;
        private Color Target;

        //------------------------------------------------------------------------------------------------------------------------------

        protected override void OnAwake()
        {
            Disable();
        }

        private void Update()
        {
            if (!IsFading)
                return;

            var delta = Mathf.Abs(Current.a - Target.a);

            if (delta < maxDelta)
            {
                IsFading = false;
                Renderer.color = Target;
                if (Current.a <= 0)
                    Disable();
            } else
                Renderer.color = Color.Lerp(Current, Target, Speed * Time.deltaTime);
        }

        //------------------------------------------------------------------------------------------------------------------------------

        public void SetAlphaImmediatly(float a)
        {
            Enable();
            var color = Current;
            color.a = a;
            Renderer.color = color;
            if (Current.a <= 0)
                Disable();
        }

        public void SetAlpha(float a, float speed)
        {
            Enable();
            Speed = speed;
            Target.a = a;
            IsFading = true;
        }


        public void Disable()
        {
            Renderer.enabled = false;
        }

        public void Enable()
        {
            Target = Current;
            Renderer.enabled = true;
        }

        //------------------------------------------------------------------------------------------------------------------------------

        [Button]
        public void FadeTo1()
        {
            SetAlpha(0.8f, Speed);
        }

        [Button]
        public void FadeTo0()
        {
            SetAlpha(0, Speed);
        }
    }
}