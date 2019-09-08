using CatswordsTab.App.Winform;

namespace CatswordsTab.App
{
    class WinformService
    {
        private static Main MainWindow;
        private static Expert ExpertWindow;
        private static Writer WriterWindow;
        private static Solver SolverWindow;
        private static Appliance ApplianceWindow;
        private static Association AssociationWindow;

        public static void SetMainWindow(Main window)
        {
            MainWindow = window;
        }

        public static Main GetMainWindow()
        {
            return MainWindow;
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

        public static Solver GetSolverWindow()
        {
            SolverWindow = new Solver();
            return SolverWindow;
        }

        public static Appliance GetApplianceWindow()
        {
            ApplianceWindow = new Appliance();
            return ApplianceWindow;
        }

        public static Association GetAssociationWindow()
        {
            AssociationWindow = new Association();
            return AssociationWindow;
        }
    }
}
