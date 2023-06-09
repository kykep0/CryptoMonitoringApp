﻿using CryptoApp.Models;
using CryptoApp.ViewModels;
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

namespace CryptoApp.Pages
{
    public partial class Main : Page
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Coin_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (sender is ListViewItem item && item.DataContext is CoinModel selectedItem)
            {
                Frame frame = (Frame)Window.GetWindow(this).FindName("MainFrame");
                DetailedViewModel detailedViewModel = new DetailedViewModel(selectedItem.Id);
                DetailedInfo detailPage = new DetailedInfo();
                detailPage.DataContext = detailedViewModel;

                frame.Content = detailPage;
            }
        }
    }
}
