using MaterialSkin.Controls;

namespace OpenpilotToolkit
{
    public static class Extensions
    {
        public static void SetEnabled(this MaterialButton button, bool enabled)
        {
            button.Enabled = enabled;
            button.Icon = button.Icon;
        }
    }
}
