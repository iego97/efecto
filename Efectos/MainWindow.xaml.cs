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

using Microsoft.Win32;

using NAudio.Wave;


namespace Efectos
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        WaveOutEvent waveOut;
        AudioFileReader reader;
        Efecto efectoProvider;



        public MainWindow()
        {
            InitializeComponent();
            waveOut = new WaveOutEvent();
        }

        private void btnExaminar_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            if((bool)fileDialog.ShowDialog())
            {
                txtRuta.Text = fileDialog.FileName;
                reader = new AudioFileReader(fileDialog.FileName);
            }
                

                    }

        private void btnPlay_Click(object sender, RoutedEventArgs e)
        {
            if(waveOut != null)
            {
                waveOut.Init(reader);
                waveOut.Play();
            }
                  
        }

        private void btnEfecto_Click(object sender, RoutedEventArgs e)
        {
            if (waveOut != null && reader != null)
            {

                if(waveOut.PlaybackState == PlaybackState.Playing)
                {
                    waveOut.Stop();
                }

                waveOut.Init(reader);

                efectoProvider = new Efecto(reader);
                waveOut.Init(efectoProvider);


                waveOut.Play();
            }
        }
    }
}
