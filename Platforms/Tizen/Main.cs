using Microsoft.Maui;
using Microsoft.Maui.Hosting;
using System;

namespace M_Hike_hk3971t_gre.ac.uk
{
    internal class Program : MauiApplication
    {
        protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();

        static void Main(string[] args)
        {
            var app = new Program();
            app.Run(args);
        }
    }
}