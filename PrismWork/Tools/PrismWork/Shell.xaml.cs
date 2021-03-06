﻿using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WorkCommon.Manager.LayoutMgr;

namespace PrismWork
{
    /// <summary>
    /// Shell.xaml 的交互逻辑
    /// </summary>
    [Export(typeof(IShell))]
    public partial class Shell : Window, IShell
    {
        public Shell()
        {
            InitializeComponent();

            this.Loaded += Shell_Loaded;
        }

        void Shell_Loaded(object sender, RoutedEventArgs e)
        {
            var at = this.contentcontrol;
            var d = at.Tag;
        }
    }
}
