﻿using System;
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

namespace ProyectoEstudiantes.Views.Dialogs
{
    /// <summary>
    /// Lógica de interacción para ImagenesDialog.xaml
    /// </summary>
    public partial class ImagenesDialog : UserControl
    {
        public ImagenesDialog()
        {
            InitializeComponent();
        }

        public void E00MostarImagenes()
        {
            stackImages.Visibility = Visibility.Visible;
            stackProcessImages.Visibility = Visibility.Collapsed;
        }

        public void E01ProcesandoImagenes(string mensaje)
        {
            stackImages.Visibility = Visibility.Collapsed;
            stackProcessImages.Visibility = Visibility.Visible;
            txtProcess.Text = mensaje;
        }

    }
}
