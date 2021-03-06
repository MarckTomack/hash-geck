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


using System.Reflection;
using Gdk;
using Gtk;

public class HashGeckUI
{
    public static readonly HashGeckUI ui = new HashGeckUI();

    public Pixbuf GetIcon()
    {
        var iconStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("HashGeck.icon.icon.png");
        using (var image = new Image(iconStream))
        {
            return image.Pixbuf;
        }
    }

    public Builder GetGladeFile() => new Builder("ui.glade");

}