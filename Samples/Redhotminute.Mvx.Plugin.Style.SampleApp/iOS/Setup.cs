using System;
using MvvmCross.Core.ViewModels;
using MvvmCross.iOS.Platform;
using MvvmCross.iOS.Views.Presenters;
using MvvmCross.Platform.IoC;
using MvvmCross.Platform.Platform;
using MvvmCross.Platform.Plugins;
using Redhotminute.Mvx.Plugin.Style.Plugin;
using UIKit;

namespace Redhotminute.Mvx.Plugin.Style.SampleApp.iOS
{
    public class Setup : MvxIosSetup
    {
        public Setup(MvxApplicationDelegate applicationDelegate, UIWindow window)
            : base(applicationDelegate, window)
        {
        }
        
        public Setup(MvxApplicationDelegate applicationDelegate, IMvxIosViewPresenter presenter)
            : base(applicationDelegate, presenter)
        {
        }
		protected override IMvxPluginConfiguration GetPluginConfiguration(Type plugin) {
		    if (plugin == typeof(Redhotminute.Mvx.Plugin.Style.Touch.Plugin.Plugin)) {
                return new RedhotminuteStyleConfiguration()
                {
                    FontSizeFactor = 1.0f,
                    LineHeightFactor = 1.0f
				};
			}
			return base.GetPluginConfiguration(plugin);
		}

		protected override IMvxIocOptions CreateIocOptions() {
			return new MvxIocOptions() {
				PropertyInjectorOptions = MvxPropertyInjectorOptions.MvxInject
			};
		}

        protected override IMvxApplication CreateApp()
        {
            return new App();
        }
        
        protected override IMvxTrace CreateDebugTrace()
        {
            return new DebugTrace();
        }
    }
}