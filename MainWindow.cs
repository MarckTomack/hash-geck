/*
Copyright (C) MarckTomack <marcktomack@tutanota.com>

This program is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with this program. If not, see <https://www.gnu.org/licenses/>.
*/

using System;
using Gtk;
using UI = Gtk.Builder.ObjectAttribute;
using System.IO;
using System.Text;

class MainWindow : Window
{
    [UI] private readonly RadioButton MD5Radio;
    [UI] private readonly RadioButton SHA256Radio;
    [UI] private readonly RadioButton SHA512Radio;
    [UI] private readonly Button HashItTextButton;
    [UI] private readonly Entry TextToHash;
    [UI] private readonly Entry ResultText;
    [UI] private readonly Entry TextToCheck;
    [UI] private readonly Entry HashToCheck;
    [UI] private readonly Button CheckHashTextButton;
    [UI] private readonly Image ResultImageFromText;
    [UI] private readonly ImageMenuItem AboutImage;
    [UI] private readonly Button ChooseFileButton;
    [UI] private readonly Entry FileEntry;
    [UI] private readonly Entry ResultFile;
    [UI] private readonly Button HashFileButton;
    [UI] private readonly Entry FileToCheck;
    [UI] private readonly Button ChooseFileToCheckButton;
    [UI] private readonly Entry HashToCheckFile;
    [UI] private readonly Button CheckHashButtonFile;
    [UI] private readonly Image ResultImageFromFile;

    private readonly AboutDialog HelpAbout = new AboutWindow(HashGeckUI.ui.GetGladeFile());
    private readonly HashGenerator GenerateHash = new HashGenerator();
    private readonly HashChecker HashCheck = new HashChecker();
    private readonly FileChooserDialog FileChooser = new FileChooserDialog(HashGeckUI.ui.GetGladeFile());
    private readonly ErrorDialog ShowErrorMsg = new ErrorDialog();

    public MainWindow() : this(HashGeckUI.ui.GetGladeFile()) { }

    private MainWindow(Builder builder) : base(builder.GetObject("MainWindow").Handle)
    {
        using (builder)
        {
            builder.Autoconnect(this);
            Resizable = false;
            Icon = HashGeckUI.ui.GetIcon();
            DeleteEvent += WindowClosed;
            HashItTextButton.Clicked += HashString;
            CheckHashTextButton.Clicked += CheckHashString;
            AboutImage.Activated += ShowAboutDialog;
            ChooseFileButton.Clicked += ShowFileChooserDialog;
            FileChooser.Hidden += AddFilePath;
            HashFileButton.Clicked += HashFile;
            ChooseFileToCheckButton.Clicked += ShowFileChooserDialog;
            CheckHashButtonFile.Clicked += CheckHashFile;
        }
    }
    private void AddFilePath(object sender, EventArgs e)
    {
        if (FileEntry.Text != null) FileEntry.Text = FileChooser.FileChoosen;
        if (FileToCheck.Text != null) FileToCheck.Text = FileChooser.FileChoosen;
    }
    private void ShowFileChooserDialog(object sender, EventArgs e)
    {
        FileChooser.Run();
        FileChooser.Hide();
    }
    private void WindowClosed(object sender, DeleteEventArgs a)
    {
        Application.Quit();
    }

    private void HashFile(object sender, EventArgs e)
    {
        if (File.Exists(FileEntry.Text))
        {
            byte[] fileToHash = File.ReadAllBytes(FileEntry.Text);
            if (MD5Radio.Active)
            {
                ResultFile.Text = GenerateHash.HashMD5(fileToHash);
            }
            if (SHA256Radio.Active)
            {
                ResultFile.Text = GenerateHash.HashSHA256(fileToHash);
            }
            if (SHA512Radio.Active)
            {
                ResultFile.Text = GenerateHash.HashSHA512(fileToHash);
            }
        }
        else if (string.IsNullOrEmpty(FileEntry.Text))
        {
            ShowErrorMsg.ShowMessageDialog(ErrorDialog.ErrorType.NoFileToHash);
        }
        else
        {
            ShowErrorMsg.ShowMessageDialog(ErrorDialog.ErrorType.IsNotAFile, FileEntry.Text);
        }
    }

    private void HashString(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(TextToHash.Text))
        {
            byte[] textToHash = Encoding.ASCII.GetBytes(TextToHash.Text);
            if (MD5Radio.Active)
            {
                ResultText.Text = GenerateHash.HashMD5(textToHash);
            }
            if (SHA256Radio.Active)
            {
                ResultText.Text = GenerateHash.HashSHA256(textToHash);
            }

            if (SHA512Radio.Active)
            {
                ResultText.Text = GenerateHash.HashSHA512(textToHash);
            }
        }
        else
        {
            ShowErrorMsg.ShowMessageDialog(ErrorDialog.ErrorType.NoTextToHash);
        }
    }

    private void CheckHashString(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(TextToCheck.Text) || !string.IsNullOrEmpty(HashToCheck.Text))
        {

            byte[] textToCheck = Encoding.ASCII.GetBytes(TextToCheck.Text);
            if (MD5Radio.Active)
            {
                if (HashCheck.CheckMD5Hash(textToCheck, HashToCheck.Text))
                {
                    ResultImageFromText.SetFromStock(Stock.Ok, IconSize.LargeToolbar);
                }
                else
                {
                    ResultImageFromText.SetFromStock(Stock.Close, IconSize.LargeToolbar);
                }
            }
            if (SHA256Radio.Active)
            {
                if (HashCheck.CheckSHA256Hash(textToCheck, HashToCheck.Text))
                {
                    ResultImageFromText.SetFromStock(Stock.Ok, IconSize.LargeToolbar);
                }
                else
                {
                    ResultImageFromText.SetFromStock(Stock.Close, IconSize.LargeToolbar);
                }
            }
            if (SHA512Radio.Active)
            {
                if (HashCheck.CheckSHA512Hash(textToCheck, HashToCheck.Text))
                {
                    ResultImageFromText.SetFromStock(Stock.Ok, IconSize.LargeToolbar);
                }
                else
                {
                    ResultImageFromText.SetFromStock(Stock.Close, IconSize.LargeToolbar);
                }
            }
        }
        else
        {
            ShowErrorMsg.ShowMessageDialog(ErrorDialog.ErrorType.NoTextOrHashToCheck);
        }
    }

    private void CheckHashFile(object sender, EventArgs e)
    {
        if (File.Exists(FileToCheck.Text))
        {
            byte[] fileToCheck = File.ReadAllBytes(FileEntry.Text);
            if (MD5Radio.Active)
            {
                if (HashCheck.CheckMD5Hash(fileToCheck, HashToCheckFile.Text))
                {
                    ResultImageFromFile.SetFromStock(Stock.Ok, IconSize.LargeToolbar);
                }
                else
                {
                    ResultImageFromFile.SetFromStock(Stock.Close, IconSize.LargeToolbar);
                }
            }
            if (SHA256Radio.Active)
            {
                if (HashCheck.CheckSHA256Hash(fileToCheck, HashToCheckFile.Text))
                {
                    ResultImageFromFile.SetFromStock(Stock.Ok, IconSize.LargeToolbar);
                }
                else
                {
                    ResultImageFromFile.SetFromStock(Stock.Close, IconSize.LargeToolbar);
                }
            }
            if (SHA512Radio.Active)
            {
                if (HashCheck.CheckSHA512Hash(fileToCheck, HashToCheckFile.Text))
                {
                    ResultImageFromFile.SetFromStock(Stock.Ok, IconSize.LargeToolbar);
                }
                else
                {
                    ResultImageFromFile.SetFromStock(Stock.Close, IconSize.LargeToolbar);
                }
            }
        }
        else if (string.IsNullOrEmpty(FileToCheck.Text) || string.IsNullOrEmpty(HashToCheckFile.Text))
        {
            ShowErrorMsg.ShowMessageDialog(ErrorDialog.ErrorType.NoFileOrHashToCheck);
        }
        else
        {

            ShowErrorMsg.ShowMessageDialog(ErrorDialog.ErrorType.IsNotAFile, FileToCheck.Text);
        }
    }

    private void ShowAboutDialog(object sender, EventArgs e)
    {
        HelpAbout.Run();
        HelpAbout.Hide();
    }

}