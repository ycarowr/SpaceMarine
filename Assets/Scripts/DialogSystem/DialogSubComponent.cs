namespace Dialog
{
    public partial class DialogSystem
    {
        private abstract class DialogSubComponent
        {
            public IDialogSystem DialogSystem { get; }

            protected DialogSubComponent (IDialogSystem system)
            {
                DialogSystem = system;
            }
        }
    }
}