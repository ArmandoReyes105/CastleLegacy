using System.Windows;
using System.Windows.Controls;

namespace CastleLegacy.Helpers
{
    public class NavigationManager
    {

        private static NavigationManager _instance;
        private Frame _mainFrame;
        private Window _currentWindow;

        private NavigationManager() { }

        public static NavigationManager Instance 
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new NavigationManager(); 
                }
                return _instance;
            }
        }

        public void Initialize(Frame mainFrame)
        {
            _mainFrame = mainFrame;
        }

        public void NavigateTo(Page page)
        {
            if(_mainFrame != null)
            {
                _mainFrame.Navigate(page);
            }
        }

        public void ShowWindow(Window window)
        {
            _currentWindow = window;
            _currentWindow.Show();
        }

        public void ShowModalWindow(Window window)
        {
            if (_currentWindow != null)
            {
                _currentWindow.IsEnabled = false; 
                window.Owner = _currentWindow; 
                window.ShowDialog(); 
                _currentWindow.IsEnabled = true; 
            }
            else
            {
                window.ShowDialog(); 
            }
        }


        public void GoBack()
        {
            if(_mainFrame != null)
            {
                _mainFrame.GoBack();
            }
        }

        
    }
}
