﻿using GhostLauncher.Client.ResourceDictionaries;
using GhostLauncher.Client.ViewModels;

namespace GhostLauncher.Client.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            Resources.MergedDictionaries.Add(SharedDictionaryManager.SharedDictionary);
            InitializeComponent();
            var viewmodel = new MainViewModel(this);
            Closed += (sender, e) => MainViewModel.Close();
            DataContext = viewmodel;
        }
    }
}
