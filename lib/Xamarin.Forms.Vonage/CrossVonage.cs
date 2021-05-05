using System;
using System.ComponentModel;

namespace Xamarin.Forms.Vonage
{
    public static class CrossVonage
    {
        private static Lazy<IVonageService> _lazyInstance;

        static CrossVonage()
        {
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void Init<TServiceImpl>() where TServiceImpl: IVonageService, new()
            => _lazyInstance ??= new Lazy<IVonageService>(() => new TServiceImpl());

        public static IVonageService Current
            => _lazyInstance?.Value
                ?? throw new InvalidOperationException("You must call PlatformVonage.Init(...) in platform specific code before using this property.");

    }
}
