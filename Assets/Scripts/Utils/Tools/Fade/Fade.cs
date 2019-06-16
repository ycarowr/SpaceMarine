using Patterns;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Tools.UI.Fade
{
    public interface IFade
    {
        Action OnFinishFade { get; set; }
        bool IsFading { get; }
        float Alpha { get; }
        void SetAlphaImmediatly(float alpha);
        void SetAlpha(float alpha, float speed);
    }

    public class Fade : SingletonMB<Fade>, IFade
    {
        [Range(1, 100f)] public float Speed;
        public SpriteRenderer Renderer;

        private const float Threshold = 0.01f;
        public bool IsFading { get; set; }

        public Action OnFinishFade { get; set; } = () => { };
        public float Alpha => Renderer.color.a;
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

            if (delta < Threshold)
            {
                IsFading = false;
                Renderer.color = Target;
                OnFinishFade?.Invoke();
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