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
using System.IO;


public class ErrorDialog
{
    public enum ErrorType
    {
        IsNotAFile,
        NoFileToHash,
        NoTextToHash,
        NoTextOrHashToCheck,
        NoFileOrHashToCheck
    }

    public void ShowMessageDialog(ErrorType error, string path = null)
    {
        string msg;

        switch (error)
        {
            case ErrorType.IsNotAFile:
                msg = $"{Path.GetFileName(path)} is not a file";
                break;
            case ErrorType.NoFileToHash:
                msg = "No file to hash";
                break;
            case ErrorType.NoTextToHash:
                msg = "No text to hash";
                break;
            case ErrorType.NoTextOrHashToCheck:
                msg = "No text or hash to check";
                break;
            case ErrorType.NoFileOrHashToCheck:
                msg = "No file or hash to check";
                break;
            default:
                msg = "ERROR";
                break;
        }
        using (var errorMsg = new MessageDialog(null, DialogFlags.DestroyWithParent, MessageType.Error, ButtonsType.Ok, msg))
        {
            errorMsg.Run();
            errorMsg.Destroy();
        }

    }


}