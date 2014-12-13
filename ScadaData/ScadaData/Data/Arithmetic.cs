/*
 * Copyright 2014 Mikhail Shiryaev
 * 
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 * 
 *     http://www.apache.org/licenses/LICENSE-2.0
 * 
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 * 
 * 
 * Product  : Rapid SCADA
 * Module   : ScadaData
 * Summary  : Auxiliary math calculations
 * 
 * Author   : Mikhail Shiryaev
 * Created  : 2005
 * Modified : 2013
 */

using System;
using System.Globalization;

namespace Scada.Data
{
    /// <summary>
    /// Auxiliary math calculations
    /// <para>��������������� �������������� �������</para>
    /// </summary>
    public static class Arithmetic
    {
        /// <summary>
        /// ������ ������� ������� � Delphi
        /// </summary>
        private static readonly DateTime DelphiTimeBegin = new DateTime(1899, 12, 30);

        /// <summary>
        /// �������� ���, ������ � ������� �� ������������� �������� ������� ������� Delphi
        /// </summary>
        public static void DecodeTime(double time, out int hour, out int min, out int sec)
        {
            const double hh = 1.0 / 24;                  // 1 ���
            const double mm = 1.0 / 24 / 60;             // 1 ���
            const double ms = 1.0 / 24 / 60 / 60 / 1000; // 1 ��

            if (time < 0)
                time = -time;

            time += ms;
            time -= Math.Truncate(time); // (int)time �������� ����������� ��� ����� time > int.MaxValue
            hour = (int)(time * 24);
            time -= hour * hh;
            min = (int)(time * 24 * 60);
            time -= min * mm;
            sec = (int)(time * 24 * 60 * 60);
        }

        /// <summary>
        /// ������������� ���� � ����� � ������ DateTime �� ������������� �������� ������� ������� Delphi
        /// </summary>
        public static DateTime DecodeDateTime(double dateTime)
        {
            return DelphiTimeBegin.AddDays(dateTime);
        }

        /// <summary>
        /// ������������ ���� � ����� � ������������ �������� ������� ������� Delphi
        /// </summary>
        public static double EncodeDateTime(DateTime dateTime)
        {
            return (dateTime - DelphiTimeBegin).TotalDays;
        }

        /// <summary>
        /// ������� ���� �� ����� ����� (��� ����������) ������� ������ ��� �������
        /// </summary>
        public static DateTime ExtractDate(string fileName)
        {
            try
            {
                return DateTime.ParseExact(fileName.Substring(1, 6), "yyMMdd", CultureInfo.CurrentCulture);
            }
            catch
            {
                return DateTime.MinValue;
            }
        }
    }
}
