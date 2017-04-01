﻿/*
 * Copyright 2017 Mikhail Shiryaev
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
 * Module   : Scheme Editor
 * Summary  : Common data of Scheme Editor
 * 
 * Author   : Mikhail Shiryaev
 * Created  : 2017
 * Modified : 2017
 */

using System.Text;
using Utils;

namespace Scada.Scheme.Editor
{
    /// <summary>
    /// Common data of Scheme Editor
    /// <para>Общие данные Редактора схем</para>
    /// </summary>
    public sealed class AppData
    {
        /// <summary>
        /// Имя файла журнала приложения без директории
        /// </summary>
        public const string LogFileName = "ScadaSchemeEditor.log";

        private static readonly AppData appDataInstance; // экземпляр объекта AppData


        /// <summary>
        /// Статический конструктор
        /// </summary>
        static AppData()
        {
            appDataInstance = new AppData();
        }

        /// <summary>
        /// Конструктор, ограничивающий создание объекта из других классов
        /// </summary>
        private AppData()
        {
            AppDirs = new AppDirs();
            Log = new Log(Log.Formats.Full);
        }


        /// <summary>
        /// Получить директории приложения
        /// </summary>
        public AppDirs AppDirs { get; private set; }

        /// <summary>
        /// Получить журнал приложения
        /// </summary>
        public Log Log { get; private set; }


        /// <summary>
        /// Инициализировать общие данные веб-приложения
        /// </summary>
        public void Init(string exeDir)
        {
            // инициализация директорий приложения
            AppDirs.Init(exeDir);

            // настройка журнала приложения
            Log.FileName = AppDirs.LogDir + LogFileName;
            Log.Encoding = Encoding.UTF8;
            Log.WriteBreak();
            Log.WriteAction(Localization.UseRussian ?
                "Инициализация общих данных Редактора схем" :
                "Initialize common data of Scheme Editor");
        }

        /// <summary>
        /// Завершить работу приложения
        /// </summary>
        public void FinalizeApp()
        {
            Log.WriteBreak();
        }

        /// <summary>
        /// Получить общие данные приложения
        /// </summary>
        public static AppData GetAppData()
        {
            return appDataInstance;
        }
    }
}