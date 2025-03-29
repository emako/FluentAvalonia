using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using FluentAvalonia.UI.Controls;
using FluentAvalonia.UI.Media.Animation;
using FAControlsGallery.Pages.NVSamplePages;
using Avalonia.Interactivity;
using System.Collections.ObjectModel;

namespace FAControlsGallery.Pages;

public partial class BreadcrumbBarPage : ControlsPageBase
{
    public BreadcrumbBarPage()
    {
        InitializeComponent();

        BreadcrumbBar1.ItemsSource = new string[] { "Home", "Documents", "Design", "Northwind", "Images", "Folder1", "Folder2", "Folder3" };

        _folderList = new ObservableCollection<BreadcrumbFolder>
        {
            new BreadcrumbFolder("Home"),
            new BreadcrumbFolder("Folder1"),
            new BreadcrumbFolder("Folder2"),
            new BreadcrumbFolder("Folder3"),
        };
        // Make a copy of the folders for the ItemsSource so we preserve the original
        BreadcrumbBar2.ItemsSource = new ObservableCollection<BreadcrumbFolder>(_folderList);
        BreadcrumbBar2.ItemClicked += BreadcrumbBar2ItemClicked;

        ResetSampleButton.Click += ResetSampleButtonClick;
    }

    private void BreadcrumbBar2ItemClicked(BreadcrumbBar sender, BreadcrumbBarItemClickedEventArgs args)
    {
        var items = BreadcrumbBar2.ItemsSource as ObservableCollection<BreadcrumbFolder>;
        for (int i = items.Count - 1; i >= args.Index + 1; i--)
        {
            items.RemoveAt(i);
        }
    }

    private void ResetSampleButtonClick(object sender, RoutedEventArgs e)
    {
        var items = BreadcrumbBar2.ItemsSource as ObservableCollection<BreadcrumbFolder>;
        for (int i = items.Count; i < _folderList.Count; i++)
        {
            items.Add(_folderList[i]);
        }
    }

    private readonly ObservableCollection<BreadcrumbFolder> _folderList;
}

public class BreadcrumbFolder
{
    public BreadcrumbFolder(string name)
    {
        Name = name;
    }

    public string Name { get; set; }
}
