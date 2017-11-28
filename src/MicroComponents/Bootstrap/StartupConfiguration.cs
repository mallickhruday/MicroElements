﻿using System;
using MicroComponents.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace MicroComponents.Bootstrap
{
    /// <summary>
    /// Параметры запуска приложения.
    /// </summary>
    public class StartupConfiguration : IStartupConfiguration
    {
        /// <summary>
        /// Параметры командной строки.
        /// </summary>
        public CommandLineArgs CommandLineArgs { get; set; } = CommandLineArgs.Null;

        /// <summary>
        /// Путь к папке с конфигурациями (абсолютный или относительный).
        /// Если путь задан, то будет считана конфигурация из этой папки.
        /// </summary>
        public string ConfigurationPath { get; set; }

        /// <summary>
        /// Configuration profile.
        /// Can be hierarchical. For example: 'Profile/SubProfile'
        /// </summary>
        public string Profile { get; set; }

        /// <summary>
        /// Путь к папке логов.
        /// </summary>
        public string LogsPath { get; set; }

        /// <summary>
        /// Идентификатор запущенного приложения.
        /// </summary>
        public string InstanceId { get; set; }

        /// <summary>
        /// Wildcard patterns for assembly loading.
        /// <para>Use something like "YourApp.*.dll"</para>
        /// <para>Default: { "*.dll", "*.exe" }</para>
        /// </summary>
        public string[] AssemblyScanPatterns { get; set; } = { "*.dll", "*.exe" };

        /// <summary>
        /// If <c>true</c> dumps all configuration values to Logger.
        /// </summary>
        public bool DumpConfigurationToLog { get; set; } = true;

        public Action<ModulesOptions> ConfigureModules = options => { };
        public ModulesOptions Modules { get; set; } = new ModulesOptions();

        #region Dynamic

        /// <summary>
        /// Коллекция сервисов <see cref="IServiceCollection"/> используется для конфигурирования контейнера.
        /// </summary>
        public IServiceCollection ServiceCollection { get; set; }


        public IExternalBuilder ExternalBuilder { get; set; }

        public IConfigurationBuilder ConfigurationBuilder { get; set; }

        /// <summary>
        /// Действие, позволяющее добавить свою логику конфигурации в начало конфигурирования конфигурации.
        /// </summary>
        public Func<IConfigurationBuilder, IConfigurationBuilder> BeginConfiguration { get; set; }

        /// <summary>
        /// Действие, позволяющее добавить свою логику конфигурации в конец конфигурирования конфигурации.
        /// </summary>
        public Func<IConfigurationBuilder, IConfigurationBuilder> EndConfiguration { get; set; }



        /// <summary>
        /// Получение сконфигурированой фабрики логирования. Если не задано, то конфигурируется по умолчанию.
        /// </summary>
        public Func<ILoggerFactory> ConfigureLogging { get; set; }



        #endregion
    }

    public class ModulesOptions
    {
        public bool AutoDiscoverModules { get; set; } = false;
        public bool AutoRegisterModules { get; set; } = true;
        public Type[] ModuleTypes { get; set; } = new Type[0];
    }
}