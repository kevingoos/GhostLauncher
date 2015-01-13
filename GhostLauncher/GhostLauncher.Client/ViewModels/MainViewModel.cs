﻿using System;
using System.Collections.ObjectModel;
using System.Windows;
using GhostLauncher.Client.Models;
using GhostLauncher.Client.ViewModels.Commands;
using GhostLauncher.Client.Views;

namespace GhostLauncher.Client.ViewModels
{
    public class MainViewModel
    {
        private ObservableCollection<MinecraftInstanceModel> _instanceCollection = new ObservableCollection<MinecraftInstanceModel>();
        private RelayCommand _command;
        private readonly Window _window;

        public MainViewModel(Window window)
        {
            _window = window;

            var resourceDictionary = new ResourceDictionary
            {
                Source = new Uri("pack://application:,,,/ResourceDictionaries/ResourceDictionary.xaml")
            };

            _instanceCollection.Add(new MinecraftInstanceModel("Instance 1", (Style)resourceDictionary["InstanceLogo"], ""));
            _instanceCollection.Add(new MinecraftInstanceModel("Instance 2", (Style)resourceDictionary["InstanceLogo"], ""));
            _instanceCollection.Add(new MinecraftInstanceModel("Instance 3", (Style)resourceDictionary["InstanceLogo"], "qsdf"));
            _instanceCollection.Add(new MinecraftInstanceModel("Instance 4", (Style)resourceDictionary["InstanceLogo"], "qsdfqsdf"));
            _instanceCollection.Add(new MinecraftInstanceModel("Instance 5", (Style)resourceDictionary["InstanceLogo"], "qsdf"));
        }

        #region Setters / Getters

        public ObservableCollection<MinecraftInstanceModel> InstanceCollection
        {
            get
            {
                return _instanceCollection;
            }
            set
            {
                _instanceCollection = value;
            }
        }

        #endregion

        #region Commands

        public RelayCommand AddInstanceCommand
        {
            get
            {
                _command = new RelayCommand(NewInstance);
                return _command;
            }
            set
            {
                _command = value;
            }
        }

        #endregion

        #region CommandHandlers

        private void NewInstance()
        {
            var addInstanceWindow = new AddInstanceWindow {Owner = _window};
            addInstanceWindow.Show();
        }

        #endregion
    }
}