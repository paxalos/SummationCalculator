namespace Savers
{
    public abstract class InputSaver
    {
        public abstract void SaveInput(string input);
        public abstract bool HasRestoreInput(out string input);
    }
}