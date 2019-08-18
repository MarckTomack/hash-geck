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

class Program
{
    [STAThread]
    public static void Main()
    {
        Application.Init();

        using (var app = new Application("org.MarckTomack.HashGeck", GLib.ApplicationFlags.None))
        {
            app.Register(GLib.Cancellable.Current);
            var win = new MainWindow();
            app.AddWindow(win);
            win.Show();
            Application.Run();
        }

    }
}