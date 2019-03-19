using CatswordsTab.Server.Winform;

namespace CatswordsTab.Server
{
    class FormService
    {
        private static Auth AuthWindow;
        private static Expert ExpertWindow;
        private static Writer WriterWindow;

        public static Auth GetAuthWindow()
        {
            if(AuthWindow == null)
            {
                AuthWindow = new Auth();
            }

            return AuthWindow;
        }

        public static Expert GetExpertWindow()
        {
            if (ExpertWindow == null)
            {
                ExpertWindow = new Expert();
            }

            return ExpertWindow;
        }

        public static Writer GetWriterWindow()
        {
            if (WriterWindow == null)
            {
                WriterWindow = new Writer();
            }

            return WriterWindow;
        }
    }
}
