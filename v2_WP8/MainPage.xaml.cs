﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

using Xunit.Runner.Wp8;

namespace v2_WP8
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();


            var mainPage = new MainPageControl();

            // tests can be inside the main assembly
            mainPage.AddTestAssembly(Assembly.GetExecutingAssembly());

            // otherwise you need to ensure that the test assemblies will 
            // become part of the app xap
            //  mainPage.AddTestAssembly(typeof(PortableTests).Assembly);


            mainPage.FinishInit(this);
            Content = mainPage;
        }
    }
}

