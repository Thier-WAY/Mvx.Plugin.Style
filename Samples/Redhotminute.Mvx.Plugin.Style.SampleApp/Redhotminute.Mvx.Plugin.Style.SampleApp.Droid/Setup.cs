using System.Linq;
using System.Reflection;
using MvvmCross.Binding;
using MvvmCross.IoC;
using MvvmCross.Platforms.Android.Core;
using Redhotminute.Mvx.Plugin.Style.Droid.BindingSetup;
using Redhotminute.Mvx.Plugin.Style.Plugin;

namespace Redhotminute.Mvx.Plugin.Style.SampleApp.Droid
{
    public class Setup : MvxAndroidSetup<App>
    {
        public override Assembly ExecutableAssembly => ViewAssemblies?.FirstOrDefault() ?? GetType().Assembly;
    

		protected override MvvmCross.Plugin.IMvxPluginConfiguration GetPluginConfiguration(System.Type plugin) {
			if (plugin == typeof(Redhotminute.Mvx.Plugin.Style.Droid.Plugin.Plugin)) {
                return new RedhotminuteStyleConfiguration() {
					FontSizeFactor = 1.0f,
					LineHeightFactor = 1.0f
				};
			}

			return base.GetPluginConfiguration(plugin);
		}

        protected override MvxBindingBuilder CreateBindingBuilder()
        {
            var bindingBuilder = new MvxAndroidStyleBindingBuilder();
            return bindingBuilder;
        }

        protected override IMvxIocOptions CreateIocOptions() {
			return new MvxIocOptions() {
				PropertyInjectorOptions = MvxPropertyInjectorOptions.MvxInject
			};
		}

    }
}
