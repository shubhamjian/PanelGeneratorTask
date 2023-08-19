using Rhino.Geometry;
using Rhino.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace PanelMaker.UI.ViewModels
{
    /// <summary>
    /// Surves as a mediator for all view models
    /// </summary>
    public class MainViewModel
    {
        #region Fields
        private static MainViewModel instance = new MainViewModel();
        #endregion

        #region Constructor
        public MainViewModel()
        {
            CurrentVM = null;

            //EVENTS
            if (MainPlugPanelUI.IsMainPanelVisible)
            {
            EnableEvents();
            }
            else
            {
                Rhino.UI.Panels.Show += Panel_Opened;
            }
        }
        #endregion

        #region Properties

        private double length;

        public double Length
        {
            get { return length; }
            set { length = value; }
        }

        private double width;

        public double Width
        {
            get { return width; }
            set { width = value; }
        }

        private double x;

        public double X
        {
            get { return x; }
            set { x = value; }
        }
        private double y;

        public double Y
        {
            get { return y; }
            set { y = value; }
        }

        private double z;

        public double Z
        {
            get { return z; }
            set { z = value; }
        }

        private ICommand createRectangleSurface;

        public ICommand CreateRectangleSurface
        {
            get
            {
                if (createRectangleSurface == null)
                {
                    createRectangleSurface = new RelayCommand(CreateSurface, CanCreateSurface);
                    return createRectangleSurface;
                }
                else
                {
                    return createRectangleSurface;
                }
            }
            set { 
                    createRectangleSurface = value; }
        }

        private void CreateSurface(object parameter)
        {
            MainViewModel mvm = (MainViewModel)parameter;
            Plane pln = new Plane(new Point3d(mvm.X, mvm.Y, mvm.Z), Vector3d.ZAxis);
            Rectangle3d rect = new Rectangle3d(pln, mvm.Length, mvm.Width);
            var plane_surface = new PlaneSurface(pln,
              new Interval(0, rect.Corner(0).DistanceTo(rect.Corner(1))),
              new Interval(0, rect.Corner(1).DistanceTo(rect.Corner(2))));

                    Rhino.RhinoDoc.ActiveDoc.Objects.Add(plane_surface);
                    Rhino.RhinoDoc.ActiveDoc.Views.Redraw();
        }

        private bool CanCreateSurface(object parameter)
        {
            return true;
        }


        #region Properties: ViewModels
        public static MainViewModel Instance
        {
            get
            {
                if (instance == null)
                {
                    
                    if (instance == null)
                    {
                        instance = new MainViewModel();
                    }
                }
                return instance;
            }
        }
        //Screens

       
        //Current screen
        public ViewModelBase CurrentVM { get; set; }
       // public PropertiesEditorViewModel PropertiesEditorVM =>PropertiesEditorViewModel.Instance;

        // Last selections,...
        
        #endregion


        #endregion

        

        #region Methods
        
        public void EnableEvents()
        {
            //Rhino.RhinoDoc.EndOpenDocument += MainViewModel.OnEndOpenDocument;
            
            
            Rhino.UI.Panels.Closed += Panel_Closed;
            Rhino.UI.Panels.Show -= Panel_Opened;
        }

        private void Panel_Closed(object sender, Rhino.UI.PanelEventArgs e)
        {
            if(e.PanelId == MainPlugPanelUI.MainPanelId)
            {
                this.DisableEvents();
            }
        }

        public void DisableEvents()
        {
            //Rhino.RhinoDoc.EndOpenDocument -= MainViewModel.OnEndOpenDocument;
           
            
            Rhino.UI.Panels.Show += Panel_Opened;
            Rhino.UI.Panels.Closed -= Panel_Closed;
        }

        private void Panel_Opened(object sender, ShowPanelEventArgs e)
        {
            if (e.PanelId == MainPlugPanelUI.MainPanelId)
            {
                this.EnableEvents();
                

            }
        }
        #endregion

        #region EventHandlers

        
        
        #endregion

        
        
    }
}