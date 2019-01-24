using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace GPApp.Dal.Logs
{
    internal class DbContextExtensions
    {
        public static LoggerFactory GetProvider()
        {
            return new LoggerFactory(new SqlLoggerProvider[1]
            {
                    new SqlLoggerProvider()
            });
        }

        public class SqlLoggerProvider : ILoggerProvider, IDisposable
        {
            private IList<string> CategoriasValidas = new List<string>()
                {
                  LoggerCategory<DbLoggerCategory.Model>.Name,
                  LoggerCategory<DbLoggerCategory.Database.Command>.Name,
                  LoggerCategory<DbLoggerCategory.Model.Validation>.Name
                };

            public static ILoggerProvider Create()
            {
                return new SqlLoggerProvider();
            }

            public ILogger CreateLogger(string categoryName)
            {
                if (CategoriasValidas.Contains(categoryName))
                    return new SqlLogger();
                return new NullLogger();
            }

            public void Dispose()
            {
            }
        }

        internal class NullLogger : ILogger
        {
            public IDisposable BeginScope<TState>(TState state)
            {
                return null;
            }

            public bool IsEnabled(LogLevel logLevel)
            {
                return true;
            }

            public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
            {
            }
        }

        public class SqlLogger : ILogger
        {
            public IDisposable BeginScope<TState>(TState state)
            {
                return null;
            }

            public bool IsEnabled(LogLevel logLevel)
            {
                return true;
            }

            public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
            {
                var mensagem = formatter(state, exception);
                Console.WriteLine("");
                Console.WriteLine(mensagem);
                Console.WriteLine("");
            }
        }
    }
}