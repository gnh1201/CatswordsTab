using CatswordsTab.Shell.Winform;

namespace CatswordsTab.Shell
{
    class WinformService
    {
        private static SheetExtensionPage SheetPage;
        private static Auth AuthWindow;
        private static Expert ExpertWindow;
        private static Writer WriterWindow;

        public static void SetSheetPage(SheetExtensionPage page)
        {
            SheetPage = page;
        }

        public static SheetExtensionPage GetSheetPage()
        {
            return SheetPage;
        }

        public static Auth GetAuthWindow()
        {
            AuthWindow = new Auth();
            return AuthWindow;
        }

        public static Expert GetExpertWindow()
        {
            ExpertWindow = new Expert();
            return ExpertWindow;
        }

        public static Writer GetWriterWindow()
        {
            WriterWindow = new Writer();
            return WriterWindow;
        }
    }
}
