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

public class HashChecker
{
    private readonly HashGenerator GenerateHash = new HashGenerator();

    public bool CheckMD5Hash(byte[] contentToCheck, string hashToCheck)
    {
        string hash = GenerateHash.HashMD5(contentToCheck);

        if (hash == hashToCheck) return true;
        return false;
    }

    public bool CheckSHA256Hash(byte[] contentToCheck, string hashToCheck)
    {
        var hash = GenerateHash.HashSHA256(contentToCheck);

        if (hash == hashToCheck) return true;
        return false;
    }

    public bool CheckSHA512Hash(byte[] contentToCheck, string hashToCheck)
    {
        var hash = GenerateHash.HashSHA512(contentToCheck);

        if (hash == hashToCheck) return true;
        return false;
    }
}