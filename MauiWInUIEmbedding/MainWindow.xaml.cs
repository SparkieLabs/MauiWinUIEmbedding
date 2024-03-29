﻿using System;
using Microsoft.Maui;
using Microsoft.Maui.Hosting;
using Microsoft.Maui.Platform;
using Microsoft.UI.Xaml;
using AppHostBuilderExtensions = Microsoft.Maui.Embedding.AppHostBuilderExtensions;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace MauiWInUIEmbedding;

/// <summary>
/// An empty window that can be used on its own or navigated to within a Frame.
/// </summary>
public sealed partial class MainWindow : Window
{
    Microsoft.Maui.Controls.Button _mauiButton;

    public MainWindow()
    {
        this.InitializeComponent();

        //Setup MauiBits
        var builder = MauiApp.CreateBuilder();

        //Add Maui Controls
        AppHostBuilderExtensions.UseMauiEmbedding<Microsoft.Maui.Controls.Application>(builder);

        var mauiApp = builder.Build();

        //Create and save a Maui Context. This is needed for creating Platform UI
        var mauiContext = new MauiContext(mauiApp.Services);

        // Create a Maui button
        _mauiButton = new Microsoft.Maui.Controls.Button { Text = "Click Maui!" };
        _mauiButton.Clicked += MauiButton_Clicked;

        //Turn the Maui button into an WinUI FrameworkElement
        var frameworkElement = _mauiButton.ToPlatform(mauiContext);

        this.myStackPanel.Children.Add(frameworkElement);
    }

    void MauiButton_Clicked(object sender, EventArgs e)
    {
        _mauiButton.Text = "Aloha!";
    }

    void myButton_Click(object sender, RoutedEventArgs e)
    {
        myButton.Content = "Clicked";
    }
}
