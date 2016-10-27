﻿using System.Xml.Serialization;
using GhostLauncher.WPF.Core;

namespace GhostLauncher.Entities.Locations
{
    [XmlInclude(typeof(InstancesFolder))]
    [XmlInclude(typeof(InstancePath))]
    public class InstanceLocation: NotifyPropertyChanged
    {
        public string Path { get; set; }
    }
}
