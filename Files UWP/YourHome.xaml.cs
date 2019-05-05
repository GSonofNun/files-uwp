﻿using Microsoft.Toolkit.Uwp.UI.Controls;
using System;
using System.Diagnostics;
using System.Drawing;
using Windows.Graphics.Display;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Files.Filesystem;
using Windows.Storage;
using Windows.UI.Xaml.Media.Imaging;
using System.Collections.ObjectModel;
using Files.Interacts;
using Windows.System;
using Windows.UI.Xaml.Navigation;
using System.ComponentModel;
using System.Collections.Generic;

namespace Files
{


    public sealed partial class YourHome : Page
    {
        public static string DesktopPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
        public static string DocumentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        public static string DownloadsPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\Downloads";
        public static string OneDrivePath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\OneDrive";
        public static string PicturesPath = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
        public static string MusicPath = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);
        public static string VideosPath = Environment.GetFolderPath(Environment.SpecialFolder.MyVideos);
        public YourHome()
        {
            InitializeComponent();
            Locations.ItemLoader.itemsAdded.Clear();
            Locations.ItemLoader.DisplayItems();
            recentItemsCollection.Clear();
            PopulateRecentsList();
            App.PathText.Text = "Favorites";

        }

        protected override void OnNavigatedTo(NavigationEventArgs eventArgs)
        {
            base.OnNavigatedTo(eventArgs);
            if(ItemViewModel.GetCurrentSelectedTabInstance<ProHome>() == null)
            {

            }
            ItemViewModel.GetCurrentSelectedTabInstance<ProHome>().BackButton.IsEnabled = ItemViewModel.GetCurrentSelectedTabInstance<ProHome>().accessibleContentFrame.CanGoBack;
            ItemViewModel.GetCurrentSelectedTabInstance<ProHome>().ForwardButton.IsEnabled = ItemViewModel.GetCurrentSelectedTabInstance<ProHome>().accessibleContentFrame.CanGoForward;
            ItemViewModel.GetCurrentSelectedTabInstance<ProHome>().RefreshButton.IsEnabled = false;
            ItemViewModel.GetCurrentSelectedTabInstance<ProHome>().accessiblePasteButton.IsEnabled = false;
            App.AlwaysPresentCommands.isEnabled = false;
            App.LayoutItems.isEnabled = false;
        }

        private void CardPressed(object sender, ItemClickEventArgs e)
        {
            string BelowCardText = ((Locations.LocationItem)e.ClickedItem).Text;
            if (BelowCardText == "Downloads")
            {
                
                ItemViewModel.GetCurrentSelectedTabInstance<ProHome>().locationsList.SelectedIndex = 2;
                App.ViewModel.TextState.isVisible = Visibility.Collapsed;
                ItemViewModel.GetCurrentSelectedTabInstance<ProHome>().accessibleContentFrame.Navigate(typeof(GenericFileBrowser), DownloadsPath);
                App.LayoutItems.isEnabled = true;
            }
            else if (BelowCardText == "Documents")
            {
                
                ItemViewModel.GetCurrentSelectedTabInstance<ProHome>().locationsList.SelectedIndex = 3;
                App.ViewModel.TextState.isVisible = Visibility.Collapsed;
                ItemViewModel.GetCurrentSelectedTabInstance<ProHome>().accessibleContentFrame.Navigate(typeof(GenericFileBrowser), DocumentsPath);
                App.LayoutItems.isEnabled = true;
            }
            else if (BelowCardText == "Pictures")
            {
                
                ItemViewModel.GetCurrentSelectedTabInstance<ProHome>().locationsList.SelectedIndex = 4;
                App.ViewModel.TextState.isVisible = Visibility.Collapsed;
                ItemViewModel.GetCurrentSelectedTabInstance<ProHome>().accessibleContentFrame.Navigate(typeof(PhotoAlbum), PicturesPath);
                App.LayoutItems.isEnabled = true;

            }
            else if (BelowCardText == "Music")
            {
                
                ItemViewModel.GetCurrentSelectedTabInstance<ProHome>().locationsList.SelectedIndex = 5;
                App.ViewModel.TextState.isVisible = Visibility.Collapsed;
                ItemViewModel.GetCurrentSelectedTabInstance<ProHome>().accessibleContentFrame.Navigate(typeof(GenericFileBrowser), MusicPath);
                App.LayoutItems.isEnabled = true;
            }
            else if (BelowCardText == "Videos")
            {
                
                ItemViewModel.GetCurrentSelectedTabInstance<ProHome>().locationsList.SelectedIndex = 6;
                App.ViewModel.TextState.isVisible = Visibility.Collapsed;
                ItemViewModel.GetCurrentSelectedTabInstance<ProHome>().accessibleContentFrame.Navigate(typeof(GenericFileBrowser), VideosPath);
                App.LayoutItems.isEnabled = true;
            }
        }

        private void DropShadowPanel_PointerEntered(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            (sender as DropShadowPanel).ShadowOpacity = 0.25;
        }

        private void DropShadowPanel_PointerExited(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            (sender as DropShadowPanel).ShadowOpacity = 0.05;
        }

        private void Button_Tapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            var clickedButton = sender as Button;
            if (clickedButton.Tag.ToString() == "\xE896") // Downloads
            {
                
                ItemViewModel.GetCurrentSelectedTabInstance<ProHome>().locationsList.SelectedIndex = 2;
                App.ViewModel.TextState.isVisible = Visibility.Collapsed;
                ItemViewModel.GetCurrentSelectedTabInstance<ProHome>().accessibleContentFrame.Navigate(typeof(GenericFileBrowser), DownloadsPath);
                App.LayoutItems.isEnabled = true;
            }
            else if (clickedButton.Tag.ToString() == "\xE8A5") // Documents
            {
                
                ItemViewModel.GetCurrentSelectedTabInstance<ProHome>().locationsList.SelectedIndex = 3;
                App.ViewModel.TextState.isVisible = Visibility.Collapsed;
                ItemViewModel.GetCurrentSelectedTabInstance<ProHome>().accessibleContentFrame.Navigate(typeof(GenericFileBrowser), DocumentsPath);
                App.LayoutItems.isEnabled = true;
            }
            else if (clickedButton.Tag.ToString() == "\xEB9F") // Pictures
            {
                
                ItemViewModel.GetCurrentSelectedTabInstance<ProHome>().locationsList.SelectedIndex = 4;
                App.ViewModel.TextState.isVisible = Visibility.Collapsed;
                ItemViewModel.GetCurrentSelectedTabInstance<ProHome>().accessibleContentFrame.Navigate(typeof(PhotoAlbum), PicturesPath);
                App.LayoutItems.isEnabled = true;
            }
            else if (clickedButton.Tag.ToString() == "\xEC4F") // Music
            {
                
                ItemViewModel.GetCurrentSelectedTabInstance<ProHome>().locationsList.SelectedIndex = 5;
                App.ViewModel.TextState.isVisible = Visibility.Collapsed;
                ItemViewModel.GetCurrentSelectedTabInstance<ProHome>().accessibleContentFrame.Navigate(typeof(GenericFileBrowser), MusicPath);
                App.LayoutItems.isEnabled = true;
            }
            else if (clickedButton.Tag.ToString() == "\xE8B2") // Videos
            {
                
                ItemViewModel.GetCurrentSelectedTabInstance<ProHome>().locationsList.SelectedIndex = 6;
                App.ViewModel.TextState.isVisible = Visibility.Collapsed;
                ItemViewModel.GetCurrentSelectedTabInstance<ProHome>().accessibleContentFrame.Navigate(typeof(GenericFileBrowser), VideosPath);
                App.LayoutItems.isEnabled = true;
            }
        }
        public static StorageFile RecentsFile;
        public static StorageFolder dataFolder;
        public static ObservableCollection<RecentItem> recentItemsCollection = new ObservableCollection<RecentItem>();
        public static EmptyRecentsText Empty { get; set; } = new EmptyRecentsText();

        public async void PopulateRecentsList()
        {
            recentItemsCollection.Clear();
            dataFolder = Windows.Storage.ApplicationData.Current.LocalCacheFolder;
            RecentsFile = await dataFolder.CreateFileAsync("recents.txt", CreationCollisionOption.OpenIfExists);
            BitmapImage ItemImage = new BitmapImage();
            string ItemPath = null;
            string ItemName;
            Visibility ItemFolderImgVis;
            Visibility ItemEmptyImgVis;
            Visibility ItemFileIconVis;
            IList<string> lines = new List<string>();
            lines = await FileIO.ReadLinesAsync(RecentsFile);
            if (lines.Count == 0)
            {
                Empty.Visibility = Visibility.Visible;
            }
            else if (lines.Count > 10)
            {
                try
                {
                    for (int LineNum = 0; LineNum < 10; LineNum++)
                    {
                        lines.RemoveAt(0);
                    }

                    await FileIO.WriteLinesAsync(RecentsFile, lines);
                    Empty.Visibility = Visibility.Collapsed;
                    lines = await FileIO.ReadLinesAsync(RecentsFile);
                    foreach (string s in lines)
                    {
                        try
                        {
                            var item = await StorageFolder.GetFolderFromPathAsync(s);
                            ItemName = item.DisplayName;
                            ItemPath = item.Path;
                            ItemFolderImgVis = Visibility.Visible;
                            ItemEmptyImgVis = Visibility.Collapsed;
                            ItemFileIconVis = Visibility.Collapsed;
                            if (!recentItemsCollection.Contains(new RecentItem() { path = ItemPath, name = ItemName, FolderImg = ItemFolderImgVis, EmptyImgVis = ItemEmptyImgVis, FileImg = ItemImage, FileIconVis = ItemFileIconVis }))
                            {
                                recentItemsCollection.Add(new RecentItem() { path = ItemPath, name = ItemName, FolderImg = ItemFolderImgVis, EmptyImgVis = ItemEmptyImgVis, FileImg = ItemImage, FileIconVis = ItemFileIconVis });
                            }

                        }
                        catch (System.IO.FileNotFoundException)
                        {
                            IList<string> modifyLines = new List<string>();
                            modifyLines = lines;
                            modifyLines.Remove(s);
                            await FileIO.WriteLinesAsync(RecentsFile, modifyLines);
                            PopulateRecentsList();
                        }
                        catch (UnauthorizedAccessException)
                        {
                            Empty.Visibility = Visibility.Visible;
                        }
                        catch (System.ArgumentException)
                        {
                            var item = await StorageFile.GetFileFromPathAsync(s);
                            ItemName = item.DisplayName;
                            ItemPath = item.Path;
                            ItemImage = new BitmapImage();
                            var thumbnail = await item.GetThumbnailAsync(Windows.Storage.FileProperties.ThumbnailMode.ListView, 30, Windows.Storage.FileProperties.ThumbnailOptions.ResizeThumbnail);
                            if (thumbnail == null)
                            {
                                ItemEmptyImgVis = Visibility.Visible;
                            }
                            else
                            {
                                await ItemImage.SetSourceAsync(thumbnail.CloneStream());
                                ItemEmptyImgVis = Visibility.Collapsed;
                            }
                            ItemFolderImgVis = Visibility.Collapsed;
                            ItemFileIconVis = Visibility.Visible;
                            if (!recentItemsCollection.Contains(new RecentItem() { path = ItemPath, name = ItemName, FolderImg = ItemFolderImgVis, EmptyImgVis = ItemEmptyImgVis, FileImg = ItemImage, FileIconVis = ItemFileIconVis }))
                            {
                                recentItemsCollection.Add(new RecentItem() { path = ItemPath, name = ItemName, FolderImg = ItemFolderImgVis, EmptyImgVis = ItemEmptyImgVis, FileImg = ItemImage, FileIconVis = ItemFileIconVis });
                            }
                        }
                    }
                }
                catch (System.IO.FileNotFoundException)
                {
                    if (ItemPath != null)
                    {
                        RemoveDeletedItemFromList(ItemPath, lines);
                    }
                    else
                    {
                        Debug.WriteLine("Attempted to delete redundant RecentItem from file when ItemPath was never set.");
                    }
                }
            }
            else
            {
                try
                {
                    Empty.Visibility = Visibility.Collapsed;

                    foreach (string s in lines)
                    {
                        try
                        {
                            ItemPath = s;
                            var item = await StorageFolder.GetFolderFromPathAsync(s);
                            ItemName = item.DisplayName;
                            ItemPath = item.Path;
                            ItemFolderImgVis = Visibility.Visible;
                            ItemEmptyImgVis = Visibility.Collapsed;
                            ItemFileIconVis = Visibility.Collapsed;
                            if (!recentItemsCollection.Contains(new RecentItem() { path = ItemPath, name = ItemName, FolderImg = ItemFolderImgVis, EmptyImgVis = ItemEmptyImgVis, FileImg = ItemImage, FileIconVis = ItemFileIconVis }))
                            {
                                recentItemsCollection.Add(new RecentItem() { path = ItemPath, name = ItemName, FolderImg = ItemFolderImgVis, EmptyImgVis = ItemEmptyImgVis, FileImg = ItemImage, FileIconVis = ItemFileIconVis });
                            }

                        }
                        catch (UnauthorizedAccessException)
                        {
                            Empty.Visibility = Visibility.Visible;
                        }
                        catch (System.ArgumentException)
                        {
                            var item = await StorageFile.GetFileFromPathAsync(s);
                            ItemName = item.DisplayName;
                            ItemPath = item.Path;
                            ItemImage = new BitmapImage();
                            var thumbnail = await item.GetThumbnailAsync(Windows.Storage.FileProperties.ThumbnailMode.ListView, 30, Windows.Storage.FileProperties.ThumbnailOptions.ResizeThumbnail);
                            if (thumbnail == null)
                            {
                                ItemEmptyImgVis = Visibility.Visible;
                            }
                            else
                            {
                                await ItemImage.SetSourceAsync(thumbnail.CloneStream());
                                ItemEmptyImgVis = Visibility.Collapsed;
                            }
                            ItemFolderImgVis = Visibility.Collapsed;
                            ItemFileIconVis = Visibility.Visible;
                            if (!recentItemsCollection.Contains(new RecentItem() { path = ItemPath, name = ItemName, FolderImg = ItemFolderImgVis, EmptyImgVis = ItemEmptyImgVis, FileImg = ItemImage, FileIconVis = ItemFileIconVis }))
                            {
                                recentItemsCollection.Add(new RecentItem() { path = ItemPath, name = ItemName, FolderImg = ItemFolderImgVis, EmptyImgVis = ItemEmptyImgVis, FileImg = ItemImage, FileIconVis = ItemFileIconVis });
                            }
                        }
                    }
                }
                catch (System.IO.FileNotFoundException)
                {
                    if(ItemPath != null)
                    {
                        RemoveDeletedItemFromList(ItemPath, lines);
                    }
                    else
                    {
                        Debug.WriteLine("Attempted to delete redundant RecentItem from file when ItemPath was never set.");
                    }
                }
                
            }
        }

        private async void RemoveDeletedItemFromList(string s, IList<string> lines)
        {
            IList<string> modifyLines = new List<string>();
            modifyLines = lines;
            modifyLines.Remove(s);
            await FileIO.WriteLinesAsync(RecentsFile, modifyLines);
            PopulateRecentsList();
        }

        private async void RecentsView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var path = (e.ClickedItem as RecentItem).path;
            try
            {
                var file = (await StorageFile.GetFileFromPathAsync(path));
                if (file.FileType == "Application")
                {
                    await Interaction.LaunchExe(path);

                }
                else
                {
                    var options = new LauncherOptions
                    {
                        DisplayApplicationPicker = false
                    };
                    await Launcher.LaunchFileAsync(file, options);
                }
            }
            catch (System.ArgumentException)
            {
                ItemViewModel.GetCurrentSelectedTabInstance<ProHome>().accessibleContentFrame.Navigate(typeof(GenericFileBrowser), path);
            }
        }

        private void RecentsView_RightTapped(object sender, Windows.UI.Xaml.Input.RightTappedRoutedEventArgs e)
        {

        }

        private async void MenuFlyoutItem_Click(object sender, RoutedEventArgs e)
        {
            recentItemsCollection.Clear();
            RecentsView.ItemsSource = null;
            await RecentsFile.DeleteAsync();
            ItemViewModel.GetCurrentSelectedTabInstance<ProHome>().accessibleContentFrame.Navigate(typeof(YourHome), null, new Windows.UI.Xaml.Media.Animation.SuppressNavigationTransitionInfo());

        }

        private void DropShadowPanel_PointerPressed(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            (sender as DropShadowPanel).ShadowOpacity = 0.025;
        }

        private void DropShadowPanel_PointerReleased(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            (sender as DropShadowPanel).ShadowOpacity = 0.25;
        }
    }

    public class RecentItem
    {
        public BitmapImage FileImg { get; set; }
        public string path { get; set; }
        public string name { get; set; }
        public Visibility FolderImg { get; set; }
        public Visibility EmptyImgVis { get; set; }
        public Visibility FileIconVis { get; set; }
    }

    public class EmptyRecentsText : INotifyPropertyChanged
    {
        private Visibility visibility;
        public Visibility Visibility
        {
            get
            {
                return visibility;
            }
            set
            {
                if (value != visibility)
                {
                    visibility = value;
                    NotifyPropertyChanged("Visibility");
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string info)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));
        }


    }
}
