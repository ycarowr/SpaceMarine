using Patterns;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Dialog
{
    public partial class DialogSystem : SingletonMB<DialogSystem>, IDialogSystem
    {
        [Header("Set by Editor")]
        [SerializeField] GameObject content;
        [SerializeField] Parameters parameters;
        [SerializeField] TextMeshProUGUI sentenceText;
        [SerializeField] TextMeshProUGUI authorText;
        [SerializeField] Button NextButton;

        public int Speed => parameters.Speed;
        public bool IsOpened { get; private set; }
        public Action OnShow { get; set; } = () => { };
        public Action OnHide { get; set; } = () => { };
        public MonoBehaviour Monobehavior => this;

        Camera MainCamera => Camera.main;

        DialogAnimation Animation { get; set; }
        DialogWriting Writing { get; set; }
        DialogSequence Sequence { get; set; }

        protected override void OnAwake()
        {
            Animation = new DialogAnimation(this);
            Writing = new DialogWriting(this, sentenceText, authorText);
            Sequence = new DialogSequence(this);
            Clear();
            Hide();

            NextButton.onClick.AddListener(PressNext);
        }

        //-----------------------------------------------------------------------------------------

        #region Write and Clear

        [Header("Test")][SerializeField] TextSequence testSequence;

        [Button]
        public void Write()
        {
            Write(testSequence);
        }


        public void Write(TextSequence textSequence)
        {
            Sequence.SetSequence(textSequence);
            var current = Sequence.GetCurrent();
            if (current == null)
                return;

            var author = current.Author;
            var text = current.Text;
            Write(text, author);
        }

        public void Write(string text, string author)
        {
            Writing.Write(text, author);
        }

        [Button]
        public void WriteNext()
        {
            var next = Sequence.GetNext();
            if (next == null)
                return;

            var author = next.Author;
            var text = next.Text;
            Write(text, author);
        }

        [Button]
        public void Clear()
        {
            OnHide += Clear;
            OnShow += Writing.StartWriting;
            Writing.Clear();
        }

        #endregion

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
            Sequence.Hide();
            IsOpened = false;
        }

        #endregion

        //-----------------------------------------------------------------------------------------

        #region Activate and Deactivate

        [Button]
        public void Activate()
        {
            content.SetActive(true);
        }

        [Button]
        public void Deactivate()
        {
            content.SetActive(false);
            Hide();
        }

        #endregion


        //-----------------------------------------------------------------------------------------

        public void SetPosition(Vector3 worldPosition)
        {

        }

        void PressNext()
        {
            var current = Sequence.GetCurrent();
            if (current == null)
                return;

            current.OnNext?.Invoke();
            var action = current.OnPressNext;
            switch (action)
            {
                case DialogAutoAction.Hide:
                    Hide();
                    break;
                case DialogAutoAction.Show:
                    Show();
                    break;
                case DialogAutoAction.Clear:
                    Clear();
                    break;
                case DialogAutoAction.Next:
                    WriteNext();
                    break;
            }
        }


        //-----------------------------------------------------------------------------------------
    }
}