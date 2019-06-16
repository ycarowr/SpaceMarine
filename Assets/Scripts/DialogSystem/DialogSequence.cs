namespace Dialog
{
    public partial class DialogSystem
    {
        private class DialogSequence : DialogSubComponent
        {
            public TextSequence Sequence { get; private set; }
            public int IndexPieces { get; private set; }

            public DialogSequence(IDialogSystem system): base(system)
            {

            }

            public void SetSequence(TextSequence sequence)
            {
                Sequence = sequence;
            }

            public void Hide()
            {
                IndexPieces = 0;
                Sequence = null;
            }

            public TextPiece Get(int index)
            {
                if (Sequence == null)
                    return null;

                return index < Sequence.Sequence.Length
                   ? Sequence.Sequence[index] : null;
            }

            public TextPiece GetCurrent()
            {
                return Get(IndexPieces);
            }

            public TextPiece GetNext()
            {
                if (Sequence == null)
                    return null;

                ++IndexPieces;
                return GetCurrent();
            }
        }


        //-----------------------------------------------------------------------------------------
    }
}