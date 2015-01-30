﻿using System.Collections.ObjectModel;
using System.Windows;
using GhostLauncher.Client.BL;
using GhostLauncher.Client.ViewModels.Commands;
using GhostLauncher.Core;
using GhostLauncher.Entities;

namespace GhostLauncher.Client.ViewModels
{
    public class VersionSelectorViewModel : NotifyPropertyChanged
    {
        private ObservableCollection<MinecraftVersion> _instanceCollection = new ObservableCollection<MinecraftVersion>();
        private MinecraftVersion _selectedInstance;
        private readonly Window _window;
        private RelayCommand _command;

        public VersionSelectorViewModel(Window window)
        {
            _window = window;
            ParseVersions();
        }

        private void ParseVersions()
        {
            _instanceCollection.Clear();
            _selectedInstance = null;

            MasterManager.GetSingleton.VersionManager.Init();

            foreach (var result in MasterManager.GetSingleton.VersionManager.MinecraftVersions)
            {
                _instanceCollection.Add(result);
            }
        }

        #region Setters / Getters

        public ObservableCollection<MinecraftVersion> InstanceCollection
        {
            set { _instanceCollection = value; }
            get { return _instanceCollection; }
        }

        public MinecraftVersion SelectedInstance
        {
            get
            {
                return _selectedInstance;
            }
            set
            {
                _selectedInstance = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Commands

        public RelayCommand SelectCommand
        {
            get
            {
                _command = new RelayCommand(Select);
                return _command;
            }
        }

        public RelayCommand CloseCommand
        {
            get
            {
                _command = new RelayCommand(Close);
                return _command;
            }
        }

        #endregion

        #region CommandHandlers

        private void Select()
        {
            _window.DialogResult = true;
            _window.Close();
        }

        private void Close()
        {
            _window.DialogResult = false;
            _window.Close();
        }

        #endregion
    }
}
