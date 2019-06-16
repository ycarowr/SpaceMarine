using System.Collections;
using System.Text;
using TMPro;
using UnityEngine;


namespace Dialog
{ 
    public partial class DialogSystem
    {
        private class DialogWriting : DialogSubComponent
        {
            StringBuilder Builder { get; }
            const char space = ' ';
            int CharLength { get; set; }
            Coroutine WriteRoutine { get; set; }
            TextMeshProUGUI SentenceText { get; }
            TextMeshProUGUI AuthorText { get; }

            public DialogWriting(IDialogSystem system, 
                TextMeshProUGUI sentence, 
                TextMeshProUGUI author) : base(system)
            {
                Builder = new StringBuilder();
                AuthorText = author;
                SentenceText = sentence;
            }


            public void Write(string text, string author)
            {
                CharLength = 0;
                Builder.Length = 0;
                Builder.Append(text);
                AuthorText.text = author;

                if (!DialogSystem.IsOpened)
                    DialogSystem.Show();
                else
                    StartWriting();
            }

            public void Clear()
            {
                Builder.Length = 0;
                SentenceText.text = string.Empty;
                AuthorText.text = string.Empty;
            }

            public void StartWriting()
            {
                if (WriteRoutine != null)
                {
                    DialogSystem.Monobehavior.StopCoroutine(WriteRoutine);
                    WriteRoutine = null;
                }

                if (Builder.Length <= 0)
                    return;

                StartCoroutine();
            }

            //-----------------------------------------------------------------------------------------

            IEnumerator KeepWriting(float delay)
            {
                yield return new WaitForSeconds(delay);

                var aSetence = Builder.ToString();
                var subSentence = CharLength <= aSetence.Length
                    ? aSetence.Substring(0, CharLength) : string.Empty;
                SentenceText.text = subSentence;

                ++CharLength;

                var hasRechedEnd = CharLength > Builder.Length;
                if (!hasRechedEnd)
                    StartCoroutine();
            }

            void StartCoroutine()
            {
                var delay = CalculateTime();
                WriteRoutine = DialogSystem.Monobehavior.StartCoroutine(KeepWriting(delay));
            }

            /// <summary>
            ///     Return the time necessary to wait according to the sentence length. 
            /// </summary>
            /// <returns></returns>
            float CalculateTime()
            {
                // v = d / t
                // wordsPerSecond = totalWords/totalSeconds
                return Builder.Length / DialogSystem.Speed;
            }
        }
    }
}