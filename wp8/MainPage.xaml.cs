using System;
using System.Linq;
using System.Windows;
using FictionBookUniversal;

namespace wp8
{
    public partial class MainPage
    {
        private const string BookPath = "BooksForTest/book.fb2";

        // Constructor
        public MainPage()
        {
            InitializeComponent();

            var streamResourceInfo = Application.GetResourceStream(new Uri(BookPath, UriKind.Relative));
            using (var stream = streamResourceInfo.Stream)
            {
                var book = FictionBookParser.Parse(stream);
                var s = book.Body.Sections.FirstOrDefault();
            }
        }

        // Sample code for building a localized ApplicationBar
        //private void BuildLocalizedApplicationBar()
        //{
        //    // Set the page's ApplicationBar to a new instance of ApplicationBar.
        //    ApplicationBar = new ApplicationBar();

        //    // Create a new button and set the text value to the localized string from AppResources.
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // Create a new menu item with the localized string from AppResources.
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}
    }
}