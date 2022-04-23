﻿using Automation.Core.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Core.Components
{
    public abstract class FluentBase: IFluent
    {
        public FluentBase(ILogger logger)
        {
            Logger = logger;
        }
        public ILogger Logger { get; }
          
        public T ChangeContext<T>()
        {
            var instance = Create<T>(null);
            Logger.Debug($"Instance of [{GetType()?.FullName}] created");
            return instance;
        }
        public T ChangeContext<T>(ILogger logger)
        {
            return Create<T>(logger);   
        }

        public abstract T ChangeContext<T>(string application);


        public abstract T ChangeContext<T>(string application, ILogger logger);
   

        internal abstract T Create<T>(ILogger logger);
    }
}
