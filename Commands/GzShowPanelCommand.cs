using Rhino;
using Rhino.Commands;


namespace PanelMaker.UI
{
    /// <summary>
    /// Rhino command that shows Godzilla Panel that is a DockBar (not a typical Rhino panel that could be grouped)
    /// </summary>
    public class SurfaceGeneratorPanelLoadCommand : Command
    {
        public override string EnglishName => "ShowSurfaceGenerator";

        protected override Result RunCommand(RhinoDoc doc, RunMode mode)
        {
            // TO DO options: which panel to show
            var Panelid = Views.MainView.PanelId;
            Rhino.UI.Panels.OpenPanel(Panelid);
            return Result.Success;
        }
    }
}
