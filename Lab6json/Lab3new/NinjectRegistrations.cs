using Ninject.Modules;
using Ninject.Web.Common;

namespace Lab3new
{
    public class NinjectRegistrations : NinjectModule
    {
        public override void Load()
        {
            Bind<TelephoneDll.IPhoneDictionary>().To<TelephoneDll.TelephoneDictionary>().InRequestScope();

            // InTransientScope() - по умолчанию - новый для каждого внедрения
            // InSingletonScope() - паттерн Singleton - один на все вызовы
            // InThreadScope() - новый экземпляр на каждый поток
            // InRequestScope() - новый экземпляр на каждый запрос
        }
    }
}