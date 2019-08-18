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


using Gtk;
using UI = Gtk.Builder.ObjectAttribute;
using System;

public class FileChooserDialog : Dialog
{
    public string FileChoosen { get; private set; }

    [UI] private readonly Button AddFileButton;
    [UI] private readonly FileChooserWidget FileChooser;

    public FileChooserDialog(Builder builder) : base(builder.GetObject("FileChooserDialog").Handle)
    {
        builder.Autoconnect(this);
        AddFileButton.Clicked += AddFile;
    }

    private void AddFile(object sender, EventArgs e)
    {
        FileChoosen = FileChooser.Filename;
        Hide();
    }
}