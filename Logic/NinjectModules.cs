using Ninject.Modules;

namespace Logic
{
    public class DesignTimeModule : NinjectModule
    {
        public override void Load()
        {
            //Bind<IUnitOfWork>().To<DesignTimeContext>();
        }
    }

    public class RunTimeModule : NinjectModule
    {
        public override void Load()
        {
            //Bind<IUnitOfWork>().To<MyContext>();
        }
    }
}

