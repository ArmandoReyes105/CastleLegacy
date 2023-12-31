﻿using CastleLegacy.Helpers;
using CastleLegacy.View;
using log4net.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CastleLegacy
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            XmlConfigurator.Configure();

            NavigationManager.Instance.Initialize(MainFrame);
            //NavigationManager.Instance.NavigateTo(new ConfigurationView());
            NavigationManager.Instance.NavigateTo(new LoginView()); 

        }
    }
}
