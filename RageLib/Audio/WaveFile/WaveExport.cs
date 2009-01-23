﻿/**********************************************************************\

 RageLib - Audio
 Copyright (C) 2009  Arushan/Aru <oneforaru at gmail.com>

 This program is free software: you can redistribute it and/or modify
 it under the terms of the GNU General Public License as published by
 the Free Software Foundation, either version 3 of the License, or
 (at your option) any later version.

 This program is distributed in the hope that it will be useful,
 but WITHOUT ANY WARRANTY; without even the implied warranty of
 MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 GNU General Public License for more details.

 You should have received a copy of the GNU General Public License
 along with this program.  If not, see <http://www.gnu.org/licenses/>.

\**********************************************************************/

using System.IO;

namespace RageLib.Audio.WaveFile
{
    static class WaveExport
    {
        public static void Export(AudioFile file, AudioWave wave, Stream outStream)
        {
            // Skip the header
            outStream.Seek(44, SeekOrigin.Begin);

            // Write the data
            file.SoundBank.ExportAsPCM(wave.Index, file.Stream, outStream);

            // Create header and write it
            outStream.Seek(0, SeekOrigin.Begin);
            WaveHeader header = new WaveHeader();
            header.FileSize = (int)outStream.Length;
            header.SamplesPerSecond = wave.SamplesPerSecond;
            header.Write(new BinaryWriter(outStream));
        }
    }
}