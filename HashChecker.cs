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
using System.Threading.Tasks;

public class HashChecker
{
    private readonly HashGenerator GenerateHash = new HashGenerator();

    public bool CheckMD5Hash(string stringToCheck, string hashToCheck)
    {
        var hash = GenerateHash.HashMD5(stringToCheck);

        if (hash == hashToCheck)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool CheckSHA256Hash(string stringToCheck, string hashToCheck)
    {
        var hash = GenerateHash.HashSHA256(stringToCheck);

        if (hash == hashToCheck)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool CheckSHA512Hash(string stringToCheck, string hashToCheck)
    {
        var hash = GenerateHash.HashSHA512(stringToCheck);

        if (hash == hashToCheck)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public async Task<bool> CheckMD5HashFile(string fileToCheck, string hashToCheck)
    {
        var hash = await GenerateHash.HashMD5File(fileToCheck);

        if (hash == hashToCheck)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public async Task<bool> CheckSHA256HashFile(string fileToCheck, string hashToCheck)
    {
        var hash = await GenerateHash.HashSHA256File(fileToCheck);

        if (hash == hashToCheck)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public async Task<bool> CheckSHA512HashFile(string fileToCheck, string hashToCheck)
    {
        var hash = await GenerateHash.HashSHA512File(fileToCheck);

        if (hash == hashToCheck)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}