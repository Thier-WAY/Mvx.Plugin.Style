using Android.Content;
using MvvmCross.Droid.Platform;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform.Platform;
using Redhotminute.Mvx.Plugin.Style.Droid;
using MvvmCross.Platform.IoC;
using Redhotminute.Mvx.Plugin.Style.Droid.BindingSetup;
using Redhotminute.Mvx.Plugin.Style.Plugin;
using MvvmCross.Binding;

namespace Redhotminute.Mvx.Plugin.Style.SampleApp.Droid
{
    public class Setup : MvxAndroidSetup
    {
        public Setup(Context applicationContext) : base(applicationContext)
        {
        }

        protected override IMvxApplication CreateApp()
        {
            return new App();
        }

        protected override IMvxTrace CreateDebugTrace()
        {
            return new DebugTrace();
        }

		protected override MvvmCross.Platform.Plugins.IMvxPluginConfiguration GetPluginConfiguration(System.Type plugin) {
			if (plugin == typeof(Style.Droid.Plugin.Plugin)) {
				return new RedhotminuteStyleConfiguration() {
					FontSizeFactor = 1.0f,
					LineHeightFactor = 1.0f
				};
			}

			return base.GetPluginConfiguration(plugin);
		}
        /*
		protected override MvvmCross.Binding.Droid.MvxAndroidBindingBuilder CreateBindingBuilder() {
			var bindingBuilder = new MvxAndroidStyleBindingBuilder();
			return bindingBuilder;
		}
        */
        protected override MvxBindingBuilder CreateBindingBuilder() => new MvxAndroidStyleBindingBuilder();

        protected override IMvxIocOptions CreateIocOptions() {
			return new MvxIocOptions() {
				PropertyInjectorOptions = MvxPropertyInjectorOptions.MvxInject
			};
		}

    }
}