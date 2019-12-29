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

using System.Security.Cryptography;
using System.Text;

public class HashGenerator
{

    public string HashMD5(byte[] content)
    {
        using (MD5 md5Hash = MD5.Create())
        {
            return GenerateMD5Hash(md5Hash, content);
        }
    }


    public string HashSHA256(byte[] content)
    {
        using (SHA256 sha256Hash = SHA256.Create())
        {
            return GenerateSHA256Hash(sha256Hash, content);
        }
    }

    public string HashSHA512(byte[] content)
    {
        using (SHA512 sha512Hash = SHA512.Create())
        {
            return GenerateSHA512Hash(sha512Hash, content);
        }
    }


    private string GenerateMD5Hash(MD5 md5Hash, byte[] content)
    {
        byte[] data = md5Hash.ComputeHash(content);
        var hash = new StringBuilder();
        for (int i = 0; i < data.Length; i++)
        {
            hash.Append(data[i].ToString("x2"));
        }
        return hash.ToString();
    }

    private string GenerateSHA256Hash(SHA256 sha256Hash, byte[] content)
    {
        byte[] data = sha256Hash.ComputeHash(content);
        var hash = new StringBuilder();
        for (int i = 0; i < data.Length; i++)
        {
            hash.Append(data[i].ToString("x2"));
        }
        return hash.ToString();
    }

    private string GenerateSHA512Hash(SHA512 sha512Hash, byte[] content)
    {
        byte[] data = sha512Hash.ComputeHash(content);
        var hash = new StringBuilder();
        for (int i = 0; i < data.Length; i++)
        {
            hash.Append(data[i].ToString("x2"));
        }
        return hash.ToString();
    }


}