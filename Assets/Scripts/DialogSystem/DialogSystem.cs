using Patterns;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


namespace Dialog
{
    public partial class DialogSystem : SingletonMB<DialogSystem>, IDialogSystem
    {

        [Header("Set by Editor")]
        [SerializeField] GameObject content;
        [SerializeField] Parameters parameters;
        [SerializeField] TextMeshProUGUI sentenceText;
        [SerializeField] TextMeshProUGUI authorText;

        public int Speed => parameters.Speed;
        public bool IsOpened { get; set; }
        public Action OnShow { get; set; } = () => { };
        public Action OnHide { get; set; } = () => { };
        public MonoBehaviour Monobehavior => this;

        Camera MainCamera => Camera.main;
     
        DialogAnimation Animation { get; set; }
        DialogWriting Writing { get; set; }

        protected override void OnAwake()
        {
            Animation = new DialogAnimation(this);
            Writing = new DialogWriting(this, sentenceText, authorText);
            Clear();
            Hide();
        }

        //-----------------------------------------------------------------------------------------

        #region Show and Hide

        [Button]
        public void Show()
        {
            Animation.Show();
            IsOpened = true;
        }

        [Button]
        public void Hide()
        {
            Animation.Hide();
            IsOpened = false;
        }

        #endregion

        //-----------------------------------------------------------------------------------------

        #region Activate and Deactivate

        [Button]
        public void Activate()
        {
            gameObject.SetActive(true);
        }

        [Button]
        public void Deactivate()
        {
            gameObject.SetActive(false);
            Hide();
        }

        #endregion

        //-----------------------------------------------------------------------------------------

        #region Write and Clear

        [Button]
        public void Clear()
        {
            OnHide += Clear;
            OnShow += Writing.StartWriting;
            Writing.Clear();
        }

        public void Write(TextSequence textSequence)
        {
            
        }

        [Button]
        public void Write()
        {
            Write("auehaueh auehahe ahuah a a uahuhauha ahuha", "Marine05");
        }

        public void Write(string text, string author)
        {
            Writing.Write(text, author);
        }

        #endregion

        //-----------------------------------------------------------------------------------------

        [Button]
        public void Next()
        {

        }

        public void SetPosition(Vector3 worldPosition)
        {

        }


        //-----------------------------------------------------------------------------------------
    }
}