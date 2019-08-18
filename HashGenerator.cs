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

using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

public class HashGenerator
{
    private string GenerateMD5Hash(MD5 md5Hash, string inputString)
    {
        var data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(inputString));
        var hash = new StringBuilder();
        for (int i = 0; i < data.Length; i++)
        {
            hash.Append(data[i].ToString("x2"));
        }
        return hash.ToString();
    }

    private Task<string> GenerateMD5HashFile(MD5 md5Hash, string file)
    {
        using(var stream = File.OpenRead(file))
        {
            var data = md5Hash.ComputeHash(stream);
            var hash = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                hash.Append(data[i].ToString("x2"));
            }
            return Task.FromResult(hash.ToString());
        }
    }

    private string GenerateSHA256Hash(SHA256 sha256Hash, string inputString)
    {
        var data = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(inputString));
        var hash = new StringBuilder();
        for (int i = 0; i < data.Length; i++)
        {
            hash.Append(data[i].ToString("x2"));
        }
        return hash.ToString();
    }

    private Task<string> GenerateSHA256HashFile(SHA256 sha256Hash, string file)
    {
        using(var stream = File.OpenRead(file))
        {
            var data = sha256Hash.ComputeHash(stream);
            var hash = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                hash.Append(data[i].ToString("x2"));
            }
            return Task.FromResult(hash.ToString());
        }
    }

    private string GenerateSHA512Hash(SHA512 sha512Hash, string inputString)
    {
        var data = sha512Hash.ComputeHash(Encoding.UTF8.GetBytes(inputString));
        var hash = new StringBuilder();
        for (int i = 0; i < data.Length; i++)
        {
            hash.Append(data[i].ToString("x2"));
        }
        return hash.ToString();
    }

    private Task<string> GenerateSHA512HashFile(SHA512 sha512Hash, string file)
    {
        using(var stream = File.OpenRead(file))
        {
            var data = sha512Hash.ComputeHash(stream);
            var hash = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                hash.Append(data[i].ToString("x2"));
            }
            return Task.FromResult(hash.ToString());
        }
    }

    public string HashMD5(string inputString)
    {
        using(MD5 md5Hash = MD5.Create())
        {
            return GenerateMD5Hash(md5Hash, inputString);
        }
    }

    public async Task<string> HashMD5File(string file)
    {
        using(MD5 md5Hash = MD5.Create())
        {
            return await GenerateMD5HashFile(md5Hash, file);
        }
    }

    public async Task<string> HashSHA256File(string file)
    {
        using(SHA256 sha256Hash = SHA256.Create())
        {
            return await GenerateSHA256HashFile(sha256Hash, file);
        }
    }

    public async Task<string> HashSHA512File(string file)
    {
        using(SHA512 sha512Hash = SHA512.Create())
        {
            return await GenerateSHA512HashFile(sha512Hash, file);
        }
    }

    public string HashSHA256(string inputString)
    {
        using(SHA256 sha256Hash = SHA256.Create())
        {
            return GenerateSHA256Hash(sha256Hash, inputString);
        }
    }

    public string HashSHA512(string inputString)
    {
        using(SHA512 sha512Hash = SHA512.Create())
        {
            return GenerateSHA512Hash(sha512Hash, inputString);
        }
    }
}