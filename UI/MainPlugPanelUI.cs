using Rhino;
using Rhino.Display;
using Rhino.DocObjects;
using System;


namespace PanelMaker.UI
{
    /// <summary>
    /// Allows visibility manipulations with Godzilla UI (panels, toolbars)
    /// </summary>
    public static class MainPlugPanelUI
    {
        #region Properties
        //get or set visibility
        public static bool IsMainPanelVisible
        {
            get { return Rhino.UI.Panels.IsPanelVisible(Views.MainView.PanelId); }
            set
            {
                if (value == true)
                {
                    Rhino.UI.Panels.OpenPanel(Views.MainView.PanelId);
                }
                else if (value == false)
                {
                    Rhino.UI.Panels.ClosePanel(Views.MainView.PanelId);
                    ViewModels.MainViewModel.Instance.DisableEvents();
                }
            }
        }

        
        ////DisplayMode 
        //DisplayModeDescription displayMode = GetDisplayModeDescription(new Guid("{31d31965-ca58-46ec-95fe-75dfa9c9175c}"));

        public static Guid MainPanelId = Views.MainView.PanelId;



        #endregion

        #region Methods
        public static void ShowAllPanels()
        {

            MainPlugPanelUI.IsMainPanelVisible = true;
        }
        public static void HideAllPanels()
        {
            MainPlugPanelUI.IsMainPanelVisible = false;

        }



        public static DisplayModeDescription GetDisplayModeDescription(Guid id)
        {
            //Get all display modes
            DisplayModeDescription[] display_modes = DisplayModeDescription.GetDisplayModes();
            if (display_modes == null || display_modes.Length < 1)
                return null;
            foreach (DisplayModeDescription displayMode in display_modes)
            {
                if (displayMode.Id == id) return displayMode;
            }
            return null;
        }


        #endregion
    }

    }
